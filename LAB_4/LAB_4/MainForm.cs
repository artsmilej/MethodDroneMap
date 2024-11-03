using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace DroneMapApp
{
    public partial class MainForm : Form
    {
        private GMapOverlay enemiesOverlay; 
        private GMapOverlay droneOverlay;
        private GMapMarker startPointMarker;
        private GMapMarker endPointMarker;
        private Label lblDistance;

        public MainForm()
        {
            InitializeComponent();

            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl.Position = new PointLatLng(48.3794, 31.1656);
            gMapControl.MinZoom = 5;
            gMapControl.MaxZoom = 100;
            gMapControl.Zoom = 6;

            enemiesOverlay = new GMapOverlay("enemies");
            gMapControl.Overlays.Add(enemiesOverlay);

            droneOverlay = new GMapOverlay("drone");
            gMapControl.Overlays.Add(droneOverlay);

            gMapControl.MouseClick += new MouseEventHandler(gMapControl_MouseClick);

            lblDistance = new Label
            {
                Location = new Point(400, 620),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular),
                Text = "Відстань: 0 км"
            };
            this.Controls.Add(lblDistance);
        }

        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PointLatLng point = gMapControl.FromLocalToLatLng(e.X, e.Y);
                AddEnemy(point);
            }
        }

        private void AddEnemy(PointLatLng point)
        {
            GMapMarker enemyMarker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            enemiesOverlay.Markers.Add(enemyMarker);
        }

        private void AddStartPoint(PointLatLng point)
        {
            if (startPointMarker != null)
            {
                droneOverlay.Markers.Remove(startPointMarker);
            }

            startPointMarker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);
            droneOverlay.Markers.Add(startPointMarker);
        }

        private void AddEndPoint(PointLatLng point)
        {
            if (endPointMarker != null)
            {
                droneOverlay.Markers.Remove(endPointMarker);
            }

            endPointMarker = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
            droneOverlay.Markers.Add(endPointMarker);

            if (startPointMarker != null)
            {
                double distance = DistanceCalculator.CalculateDistance(startPointMarker.Position, endPointMarker.Position);
                lblDistance.Text = $"Відстань: {distance:F2} км";
            }

            if (double.TryParse(txtRadius.Text, out double radius) && radius > 0)
            {
                RemoveEnemiesInRadius(endPointMarker.Position, radius);
                DrawImpactRadius(endPointMarker.Position, radius);
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть дійсний радіус ураження.", "Помилка");
            }
        }

        private void RemoveEnemiesInRadius(PointLatLng center, double radius)
        {
            List<GMapMarker> markersToRemove = new List<GMapMarker>();

            foreach (var enemy in enemiesOverlay.Markers)
            {
                double distance = DistanceCalculator.CalculateDistance(center, enemy.Position);

                if (distance <= radius)
                {
                    markersToRemove.Add(enemy);
                }
            }

            foreach (var marker in markersToRemove)
            {
                enemiesOverlay.Markers.Remove(marker);
            }
        }

        private void DrawImpactRadius(PointLatLng center, double radius)
        {
            droneOverlay.Polygons.Clear();

            GMapPolygon impactArea = new GMapPolygon(GetCirclePoints(center, radius), "ImpactArea")
            {
                Fill = new SolidBrush(Color.FromArgb(50, Color.Red)),
                Stroke = new Pen(Color.Red, 2)
            };

            droneOverlay.Polygons.Add(impactArea);
        }

        private List<PointLatLng> GetCirclePoints(PointLatLng center, double radius)
        {
            int numPoints = 100;
            List<PointLatLng> points = new List<PointLatLng>();

            for (int i = 0; i < numPoints; i++)
            {
                double angle = 2 * Math.PI * i / numPoints;
                double lat = center.Lat + (radius / 111.0) * Math.Sin(angle);
                double lng = center.Lng + (radius / (111.0 * Math.Cos(center.Lat * Math.PI / 180.0))) * Math.Cos(angle);
                points.Add(new PointLatLng(lat, lng));
            }

            return points;
        }

        private void btnSetStartPoint_Click(object sender, EventArgs e)
        {
            PointLatLng point = gMapControl.Position;
            AddStartPoint(point);
        }

        private void btnSetEndPoint_Click(object sender, EventArgs e)
        {
            PointLatLng point = gMapControl.Position;
            AddEndPoint(point);
        }
    }
}
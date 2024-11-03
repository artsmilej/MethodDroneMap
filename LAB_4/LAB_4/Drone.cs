using GMap.NET;

namespace DroneMapApp
{
    public class Drone
    {
        public PointLatLng StartPoint { get; set; }
        public PointLatLng EndPoint { get; set; }
        public double Radius { get; set; }

        public Drone(PointLatLng start, PointLatLng end, double radius)
        {
            StartPoint = start;
            EndPoint = end;
            Radius = radius;
        }
    }
}
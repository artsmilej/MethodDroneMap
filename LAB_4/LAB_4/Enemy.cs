using GMap.NET.WindowsForms.Markers;

namespace DroneMapApp
{
    public class Enemy
    {
        public GMarkerGoogle Marker { get; set; }

        public Enemy(GMarkerGoogle marker)
        {
            Marker = marker;
        }
    }
}
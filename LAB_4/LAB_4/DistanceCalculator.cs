using GMap.NET;

namespace DroneMapApp
{
    public static class DistanceCalculator
    {
        public static double CalculateDistance(PointLatLng point1, PointLatLng point2)
        {
            return GMap.NET.MapProviders.GoogleMapProvider.Instance.Projection.GetDistance(point1, point2);
        }
    }
}
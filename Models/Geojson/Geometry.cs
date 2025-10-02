namespace GeojsonAPI.Models.Geojson
{
    public class Geometry
    {
        public required string Type { get; set; }
        public required double[] Coordinates { get; set; } = new Double[2];
    }
}

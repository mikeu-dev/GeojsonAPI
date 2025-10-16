namespace GeojsonAPI.DTO.GeoJSON
{
    public class GeoJSONUploadResponse
    {
        public int ImportedCount { get; set; }
        public string FileName { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}

namespace GeojsonAPI
{
    public class Settings
    {
        public required string ConnectionString { get; set; }
        public string DatabaseName { get; set; } = string.Empty;
    }
}

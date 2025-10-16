
using GeojsonAPI.Models.GeoJSON;
using GeojsonAPI.Repository;
using Newtonsoft.Json;

namespace GeojsonAPI.Service.GeoJSON
{
    public class GeoJSONService
    {
        private readonly GeoJSONRepository _repo;

        public GeoJSONService(GeoJSONRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Feature> GetAll() => _repo.GetAll();

        public Feature? GetById(string id) => _repo.GetById(id);

        public Feature Create(Feature feature) => _repo.Add(feature);

        public bool Delete(string id) => _repo.Delete(id);

        // 🔹 Upload GeoJSON file handler
        public int ImportFromGeojsonFile(Stream fileStream)
        {
            using var reader = new StreamReader(fileStream);
            var json = reader.ReadToEnd();

            var collection = JsonConvert.DeserializeObject<FeatureCollection>(json);

            if (collection?.Features == null)
                throw new Exception("Format GeoJSON tidak valid");

            foreach (var feature in collection.Features)
            {
                _repo.Add(feature);
            }

            return collection.Features.Count;
        }
    }
}

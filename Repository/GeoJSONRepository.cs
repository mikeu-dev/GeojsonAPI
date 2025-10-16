using GeojsonAPI.Models.GeoJSON;
using System.Xml.Linq;

namespace GeojsonAPI.Repository
{
    public class GeoJSONRepository
    {
        private readonly List<Feature> _features = new();

        public IEnumerable<Feature> GetAll() => _features;

        public Feature? GetById(string id) =>
            _features.FirstOrDefault(f => f.Id == id);

        public Feature Add(Feature feature)
        {
            _features.Add(feature);
            return feature;
        }

        public bool Delete(string id)
        {
            var feature = GetById(id);
            if (feature == null) return false;
            _features.Remove(feature);
            return true;
        }
    }
}

# GeojsonAPI

GeojsonAPI is a .NET 8 Web API for handling and serving GeoJSON data. It provides endpoints to manage geographic features, collections, and geometries in compliance with the GeoJSON specification.

## Features

- Parse and serialize GeoJSON objects (Feature, FeatureCollection, Geometry)
- CRUD operations for GeoJSON features
- Extensible model structure for geographic data
- Built with modern .NET 8 practices

## Usage

You can interact with the API using tools like [Postman](https://www.postman.com/) or `curl`. Example endpoints:

- `GET /api/features` - List all features
- `POST /api/features` - Add a new feature
- `GET /api/features/{id}` - Get a feature by ID

## Project Structure

- `Models/Geojson/Feature.cs` - GeoJSON Feature model
- `Models/Geojson/FeatureCollection.cs` - GeoJSON FeatureCollection model
- `Models/Geojson/Geometry.cs` - GeoJSON Geometry model
- `Models/Geojson/Properties.cs` - Properties for GeoJSON features

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements.

## License

This project is licensed under the MIT License.

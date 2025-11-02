# GeoJSONAPI

GeoJSONAPI is an ASP .NET Core Web API designed for handling and serving GeoJSON data. It provides endpoints to manage geographic features, collections, and geometries, fully compliant with the GeoJSON specification.

## Features

* Parse and serialize GeoJSON objects (Feature, FeatureCollection, Geometry)
* CRUD operations for GeoJSON features
* Extensible model structure for geographic data
* Built using modern .NET 8 practices

## Authentication (JWT)

GeoJSONAPI uses **JWT (JSON Web Token)** to secure specific endpoints. The workflow is as follows:

1. **Register**: Create a new user

   ```http
   POST /api/Auth/register
   ```
2. **Login**: Obtain an access token

   ```http
   POST /api/Auth/login
   ```

   **Response**

   ```json
   {
   	"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
   }
   ```
3. **Access protected endpoints**: Include the token in the Authorization header

   ```text
   Authorization: Bearer <token>
   ```

   **Example using curl**:

   ```curl
   curl -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
    https://localhost:5182/api/GeoJSON
   ```

## Usage

You can interact with the API using tools such as [Postman](https://www.postman.com/) or `curl`. Example endpoints include:

* `POST /api/Auth/register` - Register a new user
* `POST /api/Auth/login` - User login
* `POST /api/GeoJSON/upload` - Upload a GeoJSON file
* `GET /api/GeoJSON` - Retrieve GeoJSON data

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements.

## License

This project is licensed under the MIT License.

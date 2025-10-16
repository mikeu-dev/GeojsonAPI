# GeojsonAPI

GeojsonAPI is a .NET 8 Web API for handling and serving GeoJSON data. It provides endpoints to manage geographic features, collections, and geometries in compliance with the GeoJSON specification.

## Features

- Parse and serialize GeoJSON objects (Feature, FeatureCollection, Geometry)
- CRUD operations for GeoJSON features
- Extensible model structure for geographic data
- Built with modern .NET 8 practices

## Authentication (JWT)

GeojsonAPI menggunakan **JWT (JSON Web Token)** untuk mengamankan endpoint tertentu.  
Alur penggunaannya:

1. **Register**: Daftar pengguna baru
	```http
	POST /api/Auth/register
	```
2. **Login**: Untuk mendapatkan token
	```http
	POST /api/Auth/login
	```
	**Response**
	```json
	{
		"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
	}
	```
3. **Mengakses endpoint terproteksi**: Sertakan token di header Authorization
	```text
	Authorization: Bearer <token>
	```
	**Contoh menggunakan curl**:
	```curl
	curl -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
     https://localhost:5182/api/GeoJSON
	```

## Usage

You can interact with the API using tools like [Postman](https://www.postman.com/) or `curl`. Example endpoints:

- `POST /api/Auth/register` - Register
- `POST /api/Auth/login` - Login
- `POST /api/GeoJSON/upload` - Upload GeoJSON File
- `GET /api/GeoJSON` - Get GeoJSON

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements.

## License

This project is licensed under the MIT License.

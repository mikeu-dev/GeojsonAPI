using GeojsonAPI.DTO.Common;
using GeojsonAPI.DTO.GeoJSON;
using GeojsonAPI.Service.GeoJSON;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeojsonAPI.Controllers.GeoJSON
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GeojsonController : ControllerBase
    {
        private readonly GeoJSONService _service;

        public GeojsonController(GeoJSONService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public ActionResult<ApiResponse<GeoJSONUploadResponse>> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new ApiResponse<string>(false, "File tidak boleh kosong"));

            if (!file.FileName.EndsWith(".geojson", StringComparison.OrdinalIgnoreCase))
                return BadRequest(new ApiResponse<string>(false, "File harus berformat .geojson"));

            try
            {
                using var stream = file.OpenReadStream();
                var count = _service.ImportFromGeojsonFile(stream);

                var response = new GeoJSONUploadResponse
                {
                    FileName = file.FileName,
                    ImportedCount = count
                };

                return Ok(new ApiResponse<GeoJSONUploadResponse>(true, "Upload berhasil", response));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(false, $"Gagal memproses file: {ex.Message}"));
            }
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<object>>> GetAll()
        {
            var data = _service.GetAll();
            return Ok(new ApiResponse<IEnumerable<object>>(true, "Berhasil mengambil data", data));
        }
    }
}

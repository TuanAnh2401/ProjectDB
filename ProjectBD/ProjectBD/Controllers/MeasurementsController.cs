using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectBD.Helper;
using ProjectBD.Model;
using ProjectBD.Model.SideModel;

namespace ProjectBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly DataContext _context;

        public MeasurementsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostMeasurements([FromBody] List<Measurement> measurements)
        {
            LoggerHelper.Log(JsonConvert.SerializeObject(measurements, Formatting.Indented).ToString(), "PostMeasurements_input");
            var response = new Response();
            if (measurements == null || !measurements.Any())
            {
                response = PaginationHelper.Message("Không có phép đo nào được cung cấp");
                return BadRequest(response);
            }

            try
            {
                _context.Measurements.AddRange(measurements);
                await _context.SaveChangesAsync();
                response = PaginationHelper.Paginate(measurements, "Thêm thành công");
                return Ok(response);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(JsonConvert.SerializeObject(ex.Message, Formatting.Indented).ToString(), "PostMeasurements_output  -- ERROR");
                response = PaginationHelper.Message("Lỗi"+ ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMeasurements()
        {
            var response = new Response();
            try
            {
                var measurements = await _context.Measurements.ToListAsync();
                response = PaginationHelper.Paginate(measurements, "Lấy thành công");
                return Ok(response);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(JsonConvert.SerializeObject(ex.Message, Formatting.Indented).ToString(), "GetAllMeasurements_output -- ERROR");
                response = PaginationHelper.Message("Lỗi: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        [HttpGet("search/{kg}")]
        public async Task<IActionResult> SearchMeasurementsByKg(int kg)
        {
            var response = new Response();
            try
            {
                var measurements = await _context.Measurements.Where(m => m.kg == kg).ToListAsync();
                if (!measurements.Any())
                {
                    response = PaginationHelper.Message("Không tìm thấy phép đo nào với giá trị kg này");
                    return NotFound(response);
                }

                response = PaginationHelper.Paginate(measurements, "Lấy thành công");
                return Ok(response);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(JsonConvert.SerializeObject(ex.Message, Formatting.Indented).ToString(), "SearchMeasurementsByKg_output -- ERROR");
                response = PaginationHelper.Message("Lỗi: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}

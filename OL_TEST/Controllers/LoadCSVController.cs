using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using OL_TEST.Models;
using OL_TEST.DTOs;
using System.Globalization;
using Services.Service;
using Services.Interfaces;

namespace OL_TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoadCSVController : Controller
    {
        private readonly ILoadCSV _loadCSVService;

        public LoadCSVController(ILoadCSV loadCSVService)
        {
            _loadCSVService = loadCSVService;
        }
        [HttpPost("load-csv")]
        public async Task<IActionResult> CargarCSV(IFormFile file, [FromQuery] string type)
        {
            var response= await _loadCSVService.LoadCSVFile<object>(file, type);
            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

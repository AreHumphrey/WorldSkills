using Backend.Infrastructure.ExportFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IExportFileFactory _exportFileFactory;
        public FilesController(IExportFileFactory exportFileFactory) 
        {
            _exportFileFactory = exportFileFactory;
        }

        [Authorize]
        [HttpGet("SMP/Download/{champId}&{compCode}")]
        public async Task<IActionResult> ExportSMP(string champId, string compCode) 
        {
            var exportSMP = _exportFileFactory.GetInstance("SMP");
            Stream responseContent = await exportSMP.Download(compCode, champId);
            if (responseContent == null) 
            {
                return NotFound("Файл не найден");
            }

            return File(responseContent, "application/octet-stream", "SMP.pdf");
        }

        [Authorize]
        [HttpGet("Infrastructure/Download/{champId}&{compCode}")]
        public async Task<IActionResult> ExportInfrustructure(string champId, string compCode)
        {
            var competenceInfrustructure = _exportFileFactory.GetInstance("Infrastructure");
            Stream responseContent = await competenceInfrustructure.Download(compCode, champId);
            if (responseContent == null)
            {
                return NotFound("Файл не найден");
            }

            return File(responseContent, "application/octet-stream", "Infrastructure.xlsx");
        }
    }
}

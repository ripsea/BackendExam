using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace BackendExam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyOfficeACPDController : ControllerBase
    {
        private readonly ApplicationDbContext _repoContext;

        public MyOfficeACPDController(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MyOfficeACPDDto dto)
        {
            string keyId = string.Empty;
            string jsonString = JsonSerializer.Serialize(dto);
            _repoContext?.MyOffice_ACPD?
                .FromSql($"EXECUTE dbo.CreateMyoffice_ACPD {jsonString},{keyId} output");
            
            return Ok(keyId);
        }

        [HttpGet]
        public IActionResult Get([FromBody] string sid)
        {
            string result = string.Empty;
            string jsonString = JsonSerializer.Serialize(new { ACPD_SID=sid });
            _repoContext?.MyOffice_ACPD?
                .FromSql($"EXECUTE dbo.GetMyoffice_ACPD {jsonString},{result} output");
            return Ok();
        }

    }
}

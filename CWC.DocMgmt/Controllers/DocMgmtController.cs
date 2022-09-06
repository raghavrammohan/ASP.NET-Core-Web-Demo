using Microsoft.AspNetCore.Mvc;

namespace CWC.DocMgmt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocMgmtController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<DocMgmtController> _logger;

        public DocMgmtController(ILogger<DocMgmtController> logger)
        {
            _logger = logger;
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace CWC.DocGeneration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocGenerationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<DocGenerationController> _logger;

        public DocGenerationController(ILogger<DocGenerationController> logger)
        {
            _logger = logger;
        }      
    }
}
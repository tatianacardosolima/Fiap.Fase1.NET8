using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Fase1.NET8.Controllers
{
    [ApiController]
    [Route("custom-logger")]
    public class CustomLoggerController: ControllerBase
    {
        private readonly ILogger<CustomLoggerController> _logger;

        public CustomLoggerController(ILogger<CustomLoggerController> logger)
        {
                _logger = logger;

        }

        [HttpPost("add-customlogger")]
        public IActionResult AddCustomLogger()
        {
            _logger.LogInformation("Teste de LogInformation 1");
            _logger.LogError("Teste de LogError 1");

            return Ok();

        }
    }
}

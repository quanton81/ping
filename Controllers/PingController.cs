using Microsoft.AspNetCore.Mvc;

namespace ping.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    private readonly ILogger<PingController> _logger;

    public PingController(ILogger<PingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Ping")]
    public OkObjectResult Get()
    {
        return Ok("ok");
    }
}
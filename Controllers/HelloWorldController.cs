using Microsoft.AspNetCore.Mvc;

namespace curso.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    ILogger<HelloWorldController> _logger; 
    public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger)
    {
        this.helloWorldService = helloWorldService;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Get del hello world");
        return Ok(helloWorldService.getHelloWorld());
    }
}

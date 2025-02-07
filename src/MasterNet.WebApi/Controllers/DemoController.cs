using Microsoft.AspNetCore.Mvc;

namespace Master.WebApi.Controllers;

[ApiController]
[Route("Demo")]
public class DemoController : ControllerBase
{
    [HttpGet("getstring")]
    public string GetNombre()
    {
        return "Jerson.com";
    }
}
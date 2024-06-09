using Dotnet_4.APIs;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_4.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MorsControllerBase : ControllerBase
{
    protected readonly IMorsService _service;

    public MorsControllerBase(IMorsService service)
    {
        _service = service;
    }

    [HttpPost("{Id}/create-mor")]
    public async Task<string> CreateMor([FromBody()] string data)
    {
        return await _service.CreateMor(data);
    }

    [HttpGet("{Id}/get-mor")]
    public async Task<string> GetMor([FromQuery()] string data)
    {
        return await _service.GetMor(data);
    }
}

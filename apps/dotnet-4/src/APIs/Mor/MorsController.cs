using Dotnet_4.APIs;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_4.APIs;

[ApiController()]
public class MorsController : MorsControllerBase
{
    public MorsController(IMorsService service)
        : base(service) { }
}

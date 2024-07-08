using Microsoft.AspNetCore.Mvc;

namespace DotnetTestCurrent.APIs;

[ApiController()]
public class AdrressesController : AdrressesControllerBase
{
    public AdrressesController(IAdrressesService service)
        : base(service) { }
}

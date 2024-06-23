using Microsoft.AspNetCore.Mvc;

namespace DotnetTestCurrent.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}

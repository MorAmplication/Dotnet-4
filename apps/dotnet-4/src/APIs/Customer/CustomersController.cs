using Microsoft.AspNetCore.Mvc;

namespace Dotnet_4.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}

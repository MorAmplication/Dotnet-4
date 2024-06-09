using Microsoft.AspNetCore.Mvc;

namespace Dotnet_4.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}

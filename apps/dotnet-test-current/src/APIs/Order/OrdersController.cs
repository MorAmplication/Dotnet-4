using Microsoft.AspNetCore.Mvc;

namespace DotnetTestCurrent.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}

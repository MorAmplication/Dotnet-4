using DotnetTestCurrent.Infrastructure;

namespace DotnetTestCurrent.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(DotnetTestCurrentDbContext context)
        : base(context) { }
}

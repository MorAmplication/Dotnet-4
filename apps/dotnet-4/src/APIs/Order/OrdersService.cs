using Dotnet_4.Infrastructure;

namespace Dotnet_4.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(Dotnet_4DbContext context)
        : base(context) { }
}

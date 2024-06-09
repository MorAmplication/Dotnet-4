using Dotnet_4.Infrastructure;

namespace Dotnet_4.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(Dotnet_4DbContext context)
        : base(context) { }
}

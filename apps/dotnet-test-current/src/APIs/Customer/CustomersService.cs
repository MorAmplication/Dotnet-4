using DotnetTestCurrent.Infrastructure;

namespace DotnetTestCurrent.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(DotnetTestCurrentDbContext context)
        : base(context) { }
}

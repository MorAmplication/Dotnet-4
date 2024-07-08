using DotnetTestCurrent.Infrastructure;

namespace DotnetTestCurrent.APIs;

public class AdrressesService : AdrressesServiceBase
{
    public AdrressesService(DotnetTestCurrentDbContext context)
        : base(context) { }
}

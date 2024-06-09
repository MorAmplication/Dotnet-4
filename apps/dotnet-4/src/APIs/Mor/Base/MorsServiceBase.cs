using Dotnet_4.APIs;
using Dotnet_4.Infrastructure;
using Dotnet_4.Infrastructure.Models;

namespace Dotnet_4.APIs;

public abstract class MorsServiceBase : IMorsService
{
    protected readonly Dotnet_4DbContext _context;

    public MorsServiceBase(Dotnet_4DbContext context)
    {
        _context = context;
    }

    public async Task<string> CreateMor(string data)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetMor(string data)
    {
        throw new NotImplementedException();
    }
}

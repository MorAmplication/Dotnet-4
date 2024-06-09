using Dotnet_4.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_4.APIs;

public class MorsService : MorsServiceBase
{
    public MorsService(Dotnet_4DbContext context)
        : base(context) { }
}

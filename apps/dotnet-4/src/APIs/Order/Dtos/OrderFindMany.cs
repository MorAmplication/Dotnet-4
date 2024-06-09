using Dotnet_4.APIs.Common;
using Dotnet_4.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_4.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class OrderFindMany : FindManyInput<Order, OrderWhereInput> { }

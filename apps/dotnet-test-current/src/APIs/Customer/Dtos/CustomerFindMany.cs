using DotnetTestCurrent.APIs.Common;
using DotnetTestCurrent.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTestCurrent.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CustomerFindMany : FindManyInput<Customer, CustomerWhereInput> { }

using DotnetTestCurrent.APIs.Common;
using DotnetTestCurrent.APIs.Dtos;

namespace DotnetTestCurrent.APIs;

public interface IOrdersService
{
    /// <summary>
    /// Create one Order
    /// </summary>
    public Task<OrderDto> CreateOrder(OrderCreateInput orderDto);

    /// <summary>
    /// Delete one Order
    /// </summary>
    public Task DeleteOrder(OrderIdDto idDto);

    /// <summary>
    /// Find many Orders
    /// </summary>
    public Task<List<OrderDto>> Orders(OrderFindMany findManyArgs);

    /// <summary>
    /// Get one Order
    /// </summary>
    public Task<OrderDto> Order(OrderIdDto idDto);

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    public Task<CustomerDto> GetCustomer(OrderIdDto idDto);

    /// <summary>
    /// Meta data about Order records
    /// </summary>
    public Task<MetadataDto> OrdersMeta(OrderFindMany findManyArgs);

    /// <summary>
    /// Update one Order
    /// </summary>
    public Task UpdateOrder(OrderIdDto idDto, OrderUpdateInput updateDto);
}

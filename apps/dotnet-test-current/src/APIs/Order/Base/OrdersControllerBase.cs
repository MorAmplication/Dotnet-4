using DotnetTestCurrent.APIs;
using DotnetTestCurrent.APIs.Common;
using DotnetTestCurrent.APIs.Dtos;
using DotnetTestCurrent.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTestCurrent.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OrdersControllerBase : ControllerBase
{
    protected readonly IOrdersService _service;

    public OrdersControllerBase(IOrdersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Order
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<OrderDto>> CreateOrder(OrderCreateInput input)
    {
        var order = await _service.CreateOrder(input);

        return CreatedAtAction(nameof(Order), new { id = order.Id }, order);
    }

    /// <summary>
    /// Delete one Order
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOrder([FromRoute()] OrderIdDto idDto)
    {
        try
        {
            await _service.DeleteOrder(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Orders
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<OrderDto>>> Orders([FromQuery()] OrderFindMany filter)
    {
        return Ok(await _service.Orders(filter));
    }

    /// <summary>
    /// Get one Order
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<OrderDto>> Order([FromRoute()] OrderIdDto idDto)
    {
        try
        {
            return await _service.Order(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    [HttpGet("{Id}/customers")]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomer([FromRoute()] OrderIdDto idDto)
    {
        var customer = await _service.GetCustomer(idDto);
        return Ok(customer);
    }

    /// <summary>
    /// Meta data about Order records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> OrdersMeta([FromQuery()] OrderFindMany filter)
    {
        return Ok(await _service.OrdersMeta(filter));
    }

    /// <summary>
    /// Update one Order
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateOrder(
        [FromRoute()] OrderIdDto idDto,
        [FromQuery()] OrderUpdateInput orderUpdateDto
    )
    {
        try
        {
            await _service.UpdateOrder(idDto, orderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

using Dotnet_4.APIs;
using Dotnet_4.APIs.Common;
using Dotnet_4.APIs.Dtos;
using Dotnet_4.APIs.Errors;
using Dotnet_4.APIs.Extensions;
using Dotnet_4.Infrastructure;
using Dotnet_4.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_4.APIs;

public abstract class OrdersServiceBase : IOrdersService
{
    protected readonly Dotnet_4DbContext _context;

    public OrdersServiceBase(Dotnet_4DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Order
    /// </summary>
    public async Task<OrderDto> CreateOrder(OrderCreateInput createDto)
    {
        var order = new Order { CreatedAt = createDto.CreatedAt, UpdatedAt = createDto.UpdatedAt };

        if (createDto.Id != null)
        {
            order.Id = createDto.Id;
        }
        if (createDto.Customer != null)
        {
            order.Customer = await _context
                .Customers.Where(customer => createDto.Customer.Id == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Order>(order.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Order
    /// </summary>
    public async Task DeleteOrder(OrderIdDto idDto)
    {
        var order = await _context.Orders.FindAsync(idDto.Id);
        if (order == null)
        {
            throw new NotFoundException();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Orders
    /// </summary>
    public async Task<List<OrderDto>> Orders(OrderFindMany findManyArgs)
    {
        var orders = await _context
            .Orders.Include(x => x.Customer)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return orders.ConvertAll(order => order.ToDto());
    }

    /// <summary>
    /// Get one Order
    /// </summary>
    public async Task<OrderDto> Order(OrderIdDto idDto)
    {
        var orders = await this.Orders(
            new OrderFindMany { Where = new OrderWhereInput { Id = idDto.Id } }
        );
        var order = orders.FirstOrDefault();
        if (order == null)
        {
            throw new NotFoundException();
        }

        return order;
    }

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    public async Task<CustomerDto> GetCustomer(OrderIdDto idDto)
    {
        var order = await _context
            .Orders.Where(order => order.Id == idDto.Id)
            .Include(order => order.Customer)
            .FirstOrDefaultAsync();
        if (order == null)
        {
            throw new NotFoundException();
        }
        return order.Customer.ToDto();
    }

    /// <summary>
    /// Update one Order
    /// </summary>
    public async Task UpdateOrder(OrderIdDto idDto, OrderUpdateInput updateDto)
    {
        var order = updateDto.ToModel(idDto);

        _context.Entry(order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Orders.Any(e => e.Id == order.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}

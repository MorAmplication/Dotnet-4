using DotnetTestCurrent.APIs;
using DotnetTestCurrent.APIs.Common;
using DotnetTestCurrent.APIs.Dtos;
using DotnetTestCurrent.APIs.Errors;
using DotnetTestCurrent.APIs.Extensions;
using DotnetTestCurrent.Infrastructure;
using DotnetTestCurrent.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetTestCurrent.APIs;

public abstract class AdrressesServiceBase : IAdrressesService
{
    protected readonly DotnetTestCurrentDbContext _context;

    public AdrressesServiceBase(DotnetTestCurrentDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Meta data about adrress records
    /// </summary>
    public async Task<MetadataDto> AdrressesMeta(AdrressFindManyArgs findManyArgs)
    {
        var count = await _context.Adrresses.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Create one adrress
    /// </summary>
    public async Task<Adrress> CreateAdrress(AdrressCreateInput createDto)
    {
        var adrress = new AdrressDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            adrress.Id = createDto.Id;
        }

        _context.Adrresses.Add(adrress);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AdrressDbModel>(adrress.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one adrress
    /// </summary>
    public async Task DeleteAdrress(AdrressWhereUniqueInput uniqueId)
    {
        var adrress = await _context.Adrresses.FindAsync(uniqueId.Id);
        if (adrress == null)
        {
            throw new NotFoundException();
        }

        _context.Adrresses.Remove(adrress);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many adrresses
    /// </summary>
    public async Task<List<Adrress>> Adrresses(AdrressFindManyArgs findManyArgs)
    {
        var adrresses = await _context
            .Adrresses.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return adrresses.ConvertAll(adrress => adrress.ToDto());
    }

    /// <summary>
    /// Get one adrress
    /// </summary>
    public async Task<Adrress> Adrress(AdrressWhereUniqueInput uniqueId)
    {
        var adrresses = await this.adrresses(
            new AdrressFindManyArgs { Where = new AdrressWhereInput { Id = uniqueId.Id } }
        );
        var adrress = adrresses.FirstOrDefault();
        if (adrress == null)
        {
            throw new NotFoundException();
        }

        return adrress;
    }

    /// <summary>
    /// Update one adrress
    /// </summary>
    public async Task UpdateAdrress(AdrressWhereUniqueInput uniqueId, AdrressUpdateInput updateDto)
    {
        var adrress = updateDto.ToModel(uniqueId);

        _context.Entry(adrress).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Adrresses.Any(e => e.Id == adrress.Id))
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

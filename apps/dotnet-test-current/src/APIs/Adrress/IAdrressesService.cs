using DotnetTestCurrent.APIs.Common;
using DotnetTestCurrent.APIs.Dtos;

namespace DotnetTestCurrent.APIs;

public interface IAdrressesService
{
    /// <summary>
    /// Meta data about adrress records
    /// </summary>
    public Task<MetadataDto> AdrressesMeta(AdrressFindManyArgs findManyArgs);

    /// <summary>
    /// Create one adrress
    /// </summary>
    public Task<Adrress> CreateAdrress(AdrressCreateInput adrress);

    /// <summary>
    /// Delete one adrress
    /// </summary>
    public Task DeleteAdrress(AdrressWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many adrresses
    /// </summary>
    public Task<List<Adrress>> Adrresses(AdrressFindManyArgs findManyArgs);

    /// <summary>
    /// Get one adrress
    /// </summary>
    public Task<Adrress> Adrress(AdrressWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one adrress
    /// </summary>
    public Task UpdateAdrress(AdrressWhereUniqueInput uniqueId, AdrressUpdateInput updateDto);
}

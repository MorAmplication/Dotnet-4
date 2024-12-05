using DotnetTestCurrent.APIs.Dtos;
using DotnetTestCurrent.Infrastructure.Models;

namespace DotnetTestCurrent.APIs.Extensions;

public static class AdrressesExtensions
{
    public static Adrress ToDto(this AdrressDbModel model)
    {
        return new Adrress
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AdrressDbModel ToModel(
        this AdrressUpdateInput updateDto,
        AdrressWhereUniqueInput uniqueId
    )
    {
        var adrress = new AdrressDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            adrress.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            adrress.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return adrress;
    }
}

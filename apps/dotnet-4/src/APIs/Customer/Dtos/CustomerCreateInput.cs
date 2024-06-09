namespace Dotnet_4.APIs.Dtos;

public class CustomerCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<OrderIdDto>? Orders { get; set; }
}

namespace Dotnet_4.APIs;

public interface IMorsService
{
    public Task<string> CreateMor(string data);
    public Task<string> GetMor(string data);
}

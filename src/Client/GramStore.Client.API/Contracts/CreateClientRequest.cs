namespace GramStore.Clients.API.Contracts
{
    public record CreateClientRequest(
        string Name, 
        long TelegramId, 
        string? PhoneNumber, 
        string? Email);
}

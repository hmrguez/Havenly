namespace Havenly.Application.Authentication;

public record RegisterRequest(string Username, string Email, string Password, string ContactInfo);
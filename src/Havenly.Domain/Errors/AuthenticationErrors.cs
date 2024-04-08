namespace Domain.Errors;

public static class AuthenticationErrors
{
    public class DuplicateUserException(string message) : Exception(message);

    public class InvalidCredentialsException(string message) : Exception(message);
}
namespace Havenly.Api;

public class LogErrorFilter : IErrorFilter
{
    private readonly ILogger<LogErrorFilter> _logger;

    public LogErrorFilter(ILogger<LogErrorFilter> logger)
    {
        _logger = logger;
    }

    public IError OnError(IError error)
    {
        _logger.LogError(error.Exception, "An error occurred while processing a GraphQL request.");
        return error;
    }
}
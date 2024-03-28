using DIsample;
using Microsoft.Extensions.Logging;

namespace DIsample;

public class LoggingMessageWriter(
    ILogger<LoggingMessageWriter> logger) : IMessageWriter
{
    public void Write(string message) =>
        logger.LogInformation("Info: {Msg}", message);
}
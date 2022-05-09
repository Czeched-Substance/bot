using Discord;

namespace ConsoleApp1.Logger
{
    public interface ILogger
    {
        public Task Log(LogMessage message);
    }
}
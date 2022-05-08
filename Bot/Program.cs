using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace CzechedSubstance
{
    class Program
    {
        private static void Main(string[] args)
            => new Program().RunAsyncTask().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task RunAsyncTask()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            // Not the best solution, but considering the fact, it's a private repo, 
            // I don't think it's a huge problem for now.
            var token = "token";
            
            // More secure way to do this would be storing the token in a config or an EnvironmentVariable
            // And then using .gitignore file

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block task until the program is closed
            await Task.Delay(-1);
            
            // The bot is ready
        }

        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }
    }
}


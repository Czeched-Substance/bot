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
            
            // Fair enough I guess, .gitignore
            var token = File.ReadAllText("token.txt");

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


using System.Threading.Tasks;
using ConsoleApp1.Commands;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ConsoleApp1
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
            _client.SlashCommandExecuted += SlashCommandHandler;
            _client.Ready += Client_Ready;
            
            // Fair enough I guess, .gitignore
            var token = File.ReadAllText("token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block task until the program is closed
            await Task.Delay(-1);
            
            // The bot is ready
        }

        private async Task SlashCommandHandler(SocketSlashCommand command)
        {
            switch (command.Data.Name)
            {
                case "sendRules":
                    RulesCommand rulesCommand = new RulesCommand();
                    await rulesCommand.HandleRulesCommand(command);
                    break;
            }
        }

        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }
    }
}


using ConsoleApp1.Logger;
using Discord.Interactions;
using Discord.WebSocket;
using Discord;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Discord.Commands;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    public class Program
    {
        private DiscordSocketClient _client;        
        
        public static Task Main() => new Program().MainAsync();
        
        public async Task MainAsync()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("config.json")
                .Build();
            
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) => services
                    // Register config
                    .AddSingleton(config)
                    // DiscordSocketClient
                    .AddSingleton(x => new DiscordSocketClient(new DiscordSocketConfig
                    {
                        GatewayIntents = GatewayIntents.AllUnprivileged,
                        LogGatewayIntentWarnings = false,
                        AlwaysDownloadUsers = true,
                        LogLevel = LogSeverity.Debug
                    }))
                    
			        // Register Logger
                    .AddTransient<ConsoleLogger>()
                    // Slash command Handler
                    .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()))
                    
                    // Required to subscribe to the various client events used in conjunction with Interactions
                    .AddSingleton<InteractionHandler>()
                    // Adding the prefix Command Service
                    .AddSingleton(x => new CommandService(new CommandServiceConfig
                    {
                        LogLevel = LogSeverity.Debug,
                        DefaultRunMode = Discord.Commands.RunMode.Async
                    })))
                .Build();

            await RunAsync(host);
        }

        public async Task RunAsync(IHost host)
        {
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var commands = provider.GetRequiredService<InteractionService>();
            _client = provider.GetRequiredService<DiscordSocketClient>();
            var config = provider.GetRequiredService<IConfigurationRoot>();

            await provider.GetRequiredService<InteractionHandler>().InitializeAsync();
            
            // Client log + Slash commands log
            _client.Log += _ => provider.GetRequiredService<ConsoleLogger>().Log(_);
            commands.Log += _ => provider.GetRequiredService<ConsoleLogger>().Log(_);

            _client.Ready += async () =>
            {
                if (IsDebug())
                    await commands.RegisterCommandsToGuildAsync(UInt64.Parse(config["guild_debug"]), true);
                else
                    await commands.RegisterCommandsGloballyAsync(true);
            };


            await _client.LoginAsync(TokenType.Bot, config["token"]);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}


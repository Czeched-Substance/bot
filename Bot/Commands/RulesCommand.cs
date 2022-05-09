
using System.Net.Mime;
using ConsoleApp1.ColorUtils;
using Discord;
using Discord.WebSocket;

namespace ConsoleApp1.Commands;

public class RulesCommand
{
    private String[] rules =
    {
        "1.", 
        "2.",
        "3."
    };
    
    private EmbedBuilder SimpleEmbedBuilder()
    {
        var embed = new EmbedBuilder()
        {
            Title = "Obecná pravidla serveru",
        };

        for(int i = 0; i < rules.Length; i++)
        {
            embed.WithDescription(rules[i]);
        }
        
        embed.WithColor(ColorUtil.setColor(12,200,12));

        return embed;
    }

    public async Task HandleRulesCommand(SocketSlashCommand command)
    {
        await command.RespondAsync(embed: SimpleEmbedBuilder().Build());
    }
}
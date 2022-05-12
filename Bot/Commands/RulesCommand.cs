using ConsoleApp1.ColorUtils;
using ConsoleApp1.Logger;
using Discord;
using Discord.Interactions;

namespace ConsoleApp1.Commands;

public class RulesCommand : InteractionModuleBase<SocketInteractionContext>
{
    public InteractionService Commands { get; set; }
    private static Logger.Logger _logger;
    private int index = 1;
    
    public RulesCommand(ConsoleLogger logger)
    {
        _logger = logger;
    }
    
    private String[] rules =
    {
        "#Uživateli je zakázáno jakýmkoliv způsobem urážet, ponižovat či zesměšňovat jiné členy naší komunity - pamatujte na základy slušného chování a respekt k ostatním.",
        "#Je striktně zakázáno šíření toxikomanie v jakékoliv formě, tzn. podávání informací o tom, jak pěstovat, prodávat, kupovat, distribuovat a nebo vyrábět substance. Tohle pravidlo se vztahuje i na soukromé zprávy",
        "#Je zakázáno rozesílat jakýkoliv nevhodný obsah mimo NSFW místnosti, stejně tak je striktně zakázáno sířit osobní údaje ostatních členů.",
        "#Vstup na server je zakázán osobám mladším 15 let.",
        "#Vše, co se píše na serveru je nutné brát s nadsázkou, tudíž žádný obsah nelze použít jako důkazní materiál. Na serveru působí externí Harm Reduction profesionálové, kteří jsou zde přítomní pro snížení rizika užívání drog a šíření osvěty a neručí za jimi neprodukovaný obsah případně se vyskytující na tomto serveru",
        "#Je přísně zakázáno obcházet jakýkoliv trest, ať už pomocí více účtů, proxy či VPN. Pokud má člen jakýkoliv aktivní trest, musí si trest odpykat.",
        "V neposlední řadě se zamyslete nad tím, co píšete, i když to není zmíněné v pravidlech. Vaše nepřiměřené chování může mít negativní dopad na psychiku ostatních členů, včetně posílání rad, které jsou hlouposti, zlehčování některých situací apod.",
        "Jakožto moderátoři si vyhrazujeme právo takové zprávy mazat, případně upozornit na jejich nepravdivé podklady, potrestat vás a také vás ze serveru zabanovat.",
        "Berte v potaz, že ctíme zákony České a Slovenské republiky, ToS Discordu a tak se vám reakce může zdát nepřiměřená situaci.",
    };
    
    private EmbedBuilder SimpleEmbedBuilder()
    {
        var redCross   = Emote.Parse("<a:ne:974371979874410507>");
        var greenCheck = Emote.Parse("<a:ano:974371973775888425>");

        var embed = new EmbedBuilder()
        {
            Title = $"Obecná pravidla serveru",
            Color = ColorUtil.setColor("#ff3e3d")
        };
        
        foreach (var message in rules)
        {
            String mess = message.StartsWith('#') ? message.Replace("#", "") : message;
            Emote emote = message.StartsWith('#') ? redCross : greenCheck;

            embed.AddField("\u200b", $"{emote}\n**{index++} » **{mess}", false);
        }
        
        return embed;
    }

    [SlashCommand("rules", "A simple command, that generates Embed with rules.")]
    public async Task HandleRulesCommand()
    {
        await _logger.Log(new LogMessage(LogSeverity.Info, "[Rules], User " + Context.User.Username + " has generated rules.", null));
        await RespondAsync(embed: SimpleEmbedBuilder().Build());
        // In case you wanted to send just a message
        //await Context.Channel.SendMessageAsync(embed: SimpleEmbedBuilder().Build());
    }
}
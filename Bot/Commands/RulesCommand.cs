﻿using ConsoleApp1.ColorUtils;
using ConsoleApp1.Logger;
using Discord;
using Discord.Interactions;

namespace ConsoleApp1.Commands;

public class RulesCommand : InteractionModuleBase<SocketInteractionContext>
{
    public InteractionService Commands { get; set; }
    private static Logger.Logger _logger;
    
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
        "#Vše, co se píše na serveru je nutné brát s nadsázkou, tudíž žádný obsah nelze použít jako důkazní materiál. Na serveru působí externí Harm Reduction profesionálové, kteří s porušováním zákonů nemají nic společného.",
        "#Je přísně zakázáno obcházet jakýkoliv trest, ať už pomocí více účtů, proxy či VPN. Pokud má člen jakýkoliv aktivní trest, musí si trest odpykat.",
        "V neposlední řadě se zamyslete nad tím, co píšete, i když to není zmíněné v pravidlech. Vaše nepřiměřené chování může mít negativní dopad na psychiku ostatních členů, včetně posílání rad, které jsou hlouposti, zlehčování některých situací apod.",
        "Jakožto moderátoři si vyhrazujeme právo takové zprávy mazat, případně upozornit na jejich nepravdivé podklady, potrestat vás a také vás ze serveru zabanovat.",
        "Berte v potaz, že ctíme zákony České a Slovenské republiky, ToS Discordu a tak se vám může reakce může zdát nepřiměřená situaci.",
    };
    
    private EmbedBuilder SimpleEmbedBuilder()
    {
<<<<<<< Updated upstream
        var redCross = Emote.Parse("<a:syCross:783519674671169566>");
        var greenCheck = Emote.Parse("<a:syVerifyCircle:845517382084329472>");
        var readRules = Emote.Parse("<a:ReadTheRules:884641162785349662>");
=======
        var redCross   = Emote.Parse("<a:ne:974371979874410507>");
        var greenCheck = Emote.Parse("<a:ano:974371973775888425>");
>>>>>>> Stashed changes
        
        var embed = new EmbedBuilder()
        {
            Title = $"Obecná pravidla serveru",
            Color = ColorUtil.setColor("#ff3e3d")
        };

        for(int i = 0; i < rules.Length; i++)
        {
            Emote emote = (rules[i].StartsWith("#") ? redCross : greenCheck);
            string message = (rules[i].StartsWith("#") ? rules[i].Replace("#", "") : rules[i]);
            
            embed.AddField("\u200b", $"{emote}\n**{i + 1} » **{message}", false);
        }

        return embed;
    }

    [SlashCommand("rulesgen", "A simple command, that generates Embed with rules.")]
    public async Task HandleRulesCommand()
    {
<<<<<<< Updated upstream
        await _logger.Log(new LogMessage(LogSeverity.Info, "[RulesCommand], User: " + Context.User.Username + "has generated rules.", null));
=======
        await _logger.Log(new LogMessage(LogSeverity.Info, "[Rules]", "User " + Context.User.Username + " has generated rules."));
>>>>>>> Stashed changes
        await RespondAsync(embed: SimpleEmbedBuilder().Build());
        // In case you wanted to send just a message
        // await Context.Channel.SendMessageAsync(embed: SimpleEmbedBuilder().Build());
    }
}
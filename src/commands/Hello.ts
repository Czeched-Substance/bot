import { BaseCommandInteraction, Client } from 'discord.js';
import { Command } from '../Command';

export const Hello: Command = {
    name: 'hello',
    description: 'Greets user',
    type: 'CHAT_INPUT',
    run: async (_client: Client, interaction: BaseCommandInteraction) => {
        const content = 'Hello there!';

        await interaction.followUp({
            ephemeral: true,
            content,
        });
    },
};

import config from './config';
import { Client, Intents } from 'discord.js';
import ready from './listeners/ready';
import interactionCreate from './listeners/interactionCreate';

const client = new Client({ intents: [Intents.FLAGS.GUILDS] });

// register listeners
ready(client);
interactionCreate(client);

// start bot
client.login(config.token);

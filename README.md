JavaScript Discord bot for our CzechedSubstance community

# Prerequisities
- Node

# Installation
- run `npm i` in root directory, this will install all necessary dependencies
- copy `.env.Development` file and save it as `.env` and change TOKEN to your token

# Running bot
- run `npm start` which start the bot (executes `/src/index.ts`)

# Development
- you most probably shouldn't change anythin else than files inside `src/` folder
- `./src/Command.ts` - interface for commands you'll be using
- to add new command add new file to `src/commands/` folder and register it inside `src/Commands.ts` file
- for every new feature please create new branch for it and when you think you are ready to publish open Pull Request on github!

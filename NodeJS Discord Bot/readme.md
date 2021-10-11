# What is this?
This is a sample bot that uses DiscordJS, axios, and the youtube-search API wrapper library in order to run.
Requires 'bot' and 'applications.commands' scopes in Discord Developer Portals' OAuth2 page, as well as the
'Send Messages', 'Read Message History' and 'Use Slash Commands' bot permissions.

# How do I install this?
- Install the most recent version of NodeJS.
- (Optional) Using 'Node.js command prompt', run 'npm install -g nodemon'
- Clone the repo, then open your Visual Studio terminal and type 'npm install'; this should install Discord.js and all appropriate dependencies into a node_modules folder, and create a package-lock.json file.

# How do I run it?
If using VSCode:
1. Open Terminal (top left of window)
2. Make sure directory is same as the index.js file
3. Type 'node index.js' OR 'npm run dev' if nodemon is installed globally.

# It's not running - why?
I've taken out the client token - you will need to make your own Discord bot application on the Discord Developer Portal:
https://discord.com/developers/
Simply place the token you generate (on the 'Bot' tab) into the end of the index.js file.

# What are the commands?
'cat'
- Displays a cat
- Argument 1: [Boolean] 'gif' (optional)
- Description: Returns a cat gif if true (optional).

'definition'
- Finds a definition of a word
- Argument 1: [String] 'word'
- Description: The word to search for.
- Argument 2: [Boolean] 'phonetics' (optional)
- Description: Include phonetics information (optional).

'crypto'
- Returns the price of a cryptocurrency (in USD) from CoinCap.io
- Argument 1: [String] 'name'
- Description: Name or symbol of cryptocurrency.

'weather'
- Returns the current temperature and humidity for a city.
- Argument 1: [String] 'city'
- Description: City name.
- Argument 2: [String] 'statecode'
- Description: The state code of your city (eg: CA for Canada, UK for United Kingdon, etc.)

'video'
- Searches for a YouTube video with the provided title; returns the first video link
- Argument 1: [String] title
- Description: Title of the video

All API sources are referred to in the code comments; additionally, references are placed when a command is used.
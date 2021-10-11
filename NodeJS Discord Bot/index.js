// Import discord.js requirements
const { Client, Intents, Constants } = require('discord.js')


// Import axios for potential API calls
const axios = require('axios');

// Weather app API key
const weatherApiKey = '8cf41c00c764044c04f3c2b62a4e8693';

// CoinCap API key
const coinCapApiKey = '394e9cd4-19bd-4321-94b9-cc2e3e27d78c';

// YouTube API key
const youtubeApiKey = 'AIzaSyDXSsiJ9E8bmJTp94a6Yd4epaE66du3mRA';
// using the youtube-search wrapper via npm
// Source: https://www.npmjs.com/package/youtube-search
var youtubeSearch = require('youtube-search');
var youtubeSearchOpts = {
  maxResults: 1,
  key: youtubeApiKey
};


const client = new Client({
  intents: [Intents.FLAGS.GUILDS, Intents.FLAGS.GUILD_MESSAGES],
});

// the 'ready' event will occur when the bot has loggged in
client.on('ready', () => {
  console.log(`Logged in as ${client.user.tag}!`)

  // Checks to see if the bot is in a 'guild' for the purposes of slash commands
  // If in a guild, the slash commands will refresh instantly; if not, regular
  // comands are active and will be cached every hour. Guild ID = server ID.
  const guildId = '896536020089200720'
  const guild = client.guilds.cache.get(guildId)

  if (guild){
    commands = guild.commands
    console.log(`Guild commands active`)
  }else{
    commands = client.application?.commands
    console.log(`Regular commands active`)
  }

  // Weather command (uses OpenWeatherMap API)
  // Source: https://openweathermap.org/api
  commands?.create({
    name: 'weather',
    description: 'Returns the current temperature and humidity for a city',
    options: [
      {
        name: 'city',
        description: 'City name.',
        required: true,
        type: Constants.ApplicationCommandOptionTypes.STRING
      },
      {
        name: 'statecode',
        description: 'The state code of your city (eg: CA for Canada, UK for United Kingdon, etc.)',
        required: true,
        type: Constants.ApplicationCommandOptionTypes.STRING
      }
    ]
  })

  // Cryptocurrency price command (uses CoinCap.io's API)
  // Source: https://docs.coincap.io/
  commands?.create({
    name: 'crypto',
    description: 'Returns the price of a cryptocurrency (in USD) from CoinCap.io',
    options: [
      {
        name: 'name',
        description: 'Name or symbol of cryptocurrency.',
        required: true,
        type: Constants.ApplicationCommandOptionTypes.STRING
      }
    ]
  })

  // Fetches a cat picture
  // Source: https://cataas.com/
  commands?.create({
    name: 'cat',
    description: 'Returns a cat picture :)',
    options: [
      {
        name: 'gif',
        description: 'Returns a cat gif if true (optional).',
        required: false,
        type: Constants.ApplicationCommandOptionTypes.BOOLEAN
      }
    ]
  })

  // Searches for a youtube video using the text provided
  // Source: https://developers.google.com/youtube/v3/getting-started?authuser=1
  commands?.create({
    name: 'video',
    description: 'Searches for a YouTube video with the provided title; returns the first video link',
    options: [
      {
        name: 'title',
        description: 'Title of the video',
        required: true,
        type: Constants.ApplicationCommandOptionTypes.STRING
      }
    ]
  })

  // Fetches a cat picture
  // Source: https://dictionaryapi.dev/
  commands?.create({
    name: 'definition',
    description: 'Finds a definition of a word',
    options: [
      {
        name: 'word',
        description: 'The word to search for.',
        required: true,
        type: Constants.ApplicationCommandOptionTypes.STRING
      },
      {
        name: 'phonetics',
        description: 'Include phonetics information (optional).',
        required: false,
        type: Constants.ApplicationCommandOptionTypes.BOOLEAN
      }
    ]
  })
});

// Used to see if any interactions are made with the bot
client.on('interactionCreate', async (interaction) => {
  if (!interaction.isCommand()){
    return
  }
  const { commandName, options } = interaction


  // Handles slash commands
  switch(commandName){
    case 'weather':
      const city = titleCase(options.getString('city'))
      const stateCode = options.getString('statecode').toUpperCase();
      var error = false;
      var weatherGetRequest
      try{
        weatherGetRequest = await axios.get('https://api.openweathermap.org/data/2.5/weather?q='+city+','+stateCode+'&appid='+weatherApiKey);
      }catch{
        error = true;
      }
      
      if(!error){
        // Base temperature is in Kelvin
        var temperature = Math.round(weatherGetRequest.data.main.temp - 273);
        interaction.reply({
          content: `The temperature in ${weatherGetRequest.data.name}, ${weatherGetRequest.data.sys.country} is ${temperature}°C [humidity: ${weatherGetRequest.data.main.humidity}%].
          
          > Retrieved from: https://openweathermap.org/`,
          ephemeral: false,
        })
      }else{
        interaction.reply({
          content: `The city or state code name was invalid. \nPlease refer the ISO 3166 for country codes: https://www.iso.org/obp/ui/#search\n(remember to search by Country Code)`,
          ephemeral: true,
        })
      }
      break;
    case 'crypto':
      const crypto = titleCase(options.getString('name'))

      // Config used to place API key in Bearer Token
      // Uses a free API key for more reliable requests
      // See https://stackoverflow.com/questions/40988238/sending-the-bearer-token-with-axios for more info
      const config = {
        headers: { Authorization: `Bearer ${coinCapApiKey}` }
      };

      var error = false;
      var cryptoGetRequest;
      var cryptoName;
      var price;

      try{
        cryptoGetRequest = await axios.get(`https://api.coincap.io/v2/assets?search=${crypto}&limit=1`, config);
        
        // This is the price
        req = cryptoGetRequest.data.data[0].priceUsd
        cryptoName = cryptoGetRequest.data.data[0].name
        price = parseFloat(cryptoGetRequest.data.data[0].priceUsd).toFixed(2)
        
      }catch{
        error = true;
      }

      if(!error){        
        interaction.reply({
          content: `The price of ${cryptoName} is $${price} USD.\n > Retrieved from: https://coincap.io/`,
          ephemeral: false,
        })
      }else{
        interaction.reply({
          content: `That cryptocurrency name is invalid, please try again`,
          ephemeral: true,
        })
      }

      break;
    case 'cat':
      const gif = options.getBoolean('gif')
      var error = false;
      var catGetRequest;
      var baseUrl = 'https://cataas.com';
      var additionalUrl;

      try{
        if(gif){
          catGetRequest = await axios.get(`https://cataas.com/cat/gif?json=true`);    
        }else{
          catGetRequest = await axios.get(`https://cataas.com/cat?json=true`);  
        }
        additionalUrl = catGetRequest.data.url;   
      }catch{
        error = true;
      }

      if(!error){        
        interaction.reply({
          content: baseUrl + additionalUrl +"\n > Retrieved from: https://cataas.com",
          ephemeral: false,
        })
      }else{
        interaction.reply({
          content: `There was an error`,
          ephemeral: true,
        })
      }

      break;
    case 'definition':
      const word = options.getString('word')
      const phonetics = options.getBoolean('phonetics')
      var definitionString ="Definitions:";
      var phoneticString = "";
      var defGetRequest;
      var error = false;

      try{
        defGetRequest = await axios.get(`https://api.dictionaryapi.dev/api/v2/entries/en/${word}`);   
      }catch{
        error = true;
      }

      if(!error){        
        console.log(defGetRequest.data)
        let req = defGetRequest.data[0].meanings[0]
        let definitions = Object.values(req)[1]
        if(phonetics){
          phoneticString+="*"+defGetRequest.data[0].phonetic+"*\n";
          let phoneticReq = defGetRequest.data[0].phonetics[0]
          let phoneticsAudio = Object.values(phoneticReq)[1]
          phoneticString += "Audio: https:"+ phoneticsAudio+"\n";
        }
        definitions.forEach((entry) =>{
          definitionString += "\n*"+entry.definition+"*";
        })

        interaction.reply({
          content: phoneticString+definitionString+"\n > Retrieved from: https://dictionaryapi.dev/",
          ephemeral: false,
        })
      }else{
        interaction.reply({
          content: `There is no definition for that word, please try again.`,
          ephemeral: true,
        })
      }
      break;
    case 'video':
      const title = options.getString('title')
      var error = false;
      youtubeSearch(title, youtubeSearchOpts, function(err, results) {
        if(err){
          error = true;
          console.log(err);
        } else{          
          try{
            console.log(results[0].link);
            interaction.reply({
              content: results[0].link + '\n > Retrieved from: https://developers.google.com/youtube/v3/getting-started?authuser=1 (using wrapper: https://www.npmjs.com/package/youtube-search)',
              ephemeral: false,
            })
          }catch{
            error = true;
          }
        }
      });

      if (error){
        interaction.reply({
          content: `There was an error, please try again.`,
          ephemeral: true,
        })
      }
      break;
    default:
      break;
  }
})

// the 'messageCreate' event will occur when a message is entered into a channel
client.on('messageCreate', async message => {

  // Logs message data
  console.log(message);
  
  // If the message author is NOT a bot, do something
  if (!message.author.bot){
    // Blanking this out for lack of assignment necessity;
    // might return to this code upon personal Discord bot development
    // await message.reply("> " + message.content);
  } 
    
})

// Logs in the bot to the channel
client.login("[INSERT CLIENT TOKEN HERE]");


// Just a simple titleCase function; capitalizes first letter and lowercases everything else
function titleCase(string){
  return string[0].toUpperCase() + string.slice(1).toLowerCase();
}
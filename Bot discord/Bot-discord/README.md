# Discord bot
> Final version

## Install

```bash  
We will installed the voice pilote (sound of bot) and opuss or opusscript to bind the program and ytdl for youtube :

  voice channel : `npm install ffmpeg` 
  if it does not works, Tuto : https://www.youtube.com/watch?v=xcdTIDHm4KM
  
  opusscript : `npm install opusscript`
  if it's necessary : `node_opus` 
  
  ytdl : Follow the instructions on this page`https://www.npmjs.com/package/ytdl-core` 
```
## Usage

Edit the config.js file to connected the bot with Google and discord thanks to an API. Then selected a prefix to give the bot's instructions:

```js
exports.TOKEN = ''; // Your token here

exports.PREFIX = 'm!'; // Your preferred prefix here

exports.GOOGLE_API_KEY = ''; // Your youtube/google API key here
```


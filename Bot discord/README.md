# Discord bot
Projects did for my High School years with the goal of develop a music bot in javascript for a Discord server

## Music bot
> Simple music bot with a full-blown queue system

## Install

```bash
Download node js : https://nodejs.org/en/download/
After open the terminal (cmd), now we will installed discord language to program the bot :
  - `npm init`
  - `npm install discord.js`
Then, we will installed the voice pilote (sound of bot) and opuss or opusscript to bind the program and ytdl for youtube :
  - voice channel : `npm install ffmpeg` + if it does not works, Tuto : https://www.youtube.com/watch?v=xcdTIDHm4KM
  - opusscript : `npm install opusscript` + `node_opus` if it's necessary
  - ytdl : Follow the instructions on this page`https://www.npmjs.com/package/ytdl-core` 
 As extra :
 How did a playlist : https://discord.js.org/#/docs/commando/master/general/welcome
```
## Usage

Edit the config.js file to connected the bot with Google and discord thanks to an API. Then selected a prefix to give the bot's instructions:

```js
exports.TOKEN = ''; // Your token here

exports.PREFIX = 'm!'; // Your preferred prefix here

exports.GOOGLE_API_KEY = ''; // Your youtube/google API key here
```

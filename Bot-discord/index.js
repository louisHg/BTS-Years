const Discord = require("discord.js"); // librairie qui fait tourner discord
const clients = new Discord.Client();  // création d'une variable clients qui est directement exporté
const weather = require('weather-js'); // librairie qui permet de lire les nombreuses contstantes permettant de lire et d'afficher la météo
const { TOKEN, PREFIX, GOOGLE_API_KEY } = require('./config'); //module d'export du dossier config.js content le jeton,la clef et le prefix (!)
const { Client, Util } = require('discord.js'); //création d'une seconde constante qui est Client et Util provenant de discord.js
const YouTube = require('simple-youtube-api'); //librairie permettant de chercher une musique sur youtube et de l'envoyer dans les différent channels discord
const ytdl = require('ytdl-core'); //librairie youtube qui envoie les données de discord et qui permet de l'appliquer au sein du serveur



const client = new Client({ disableEveryone: true }); //constante crée  pour et repondre à l'utlisateur qui veut que la bot joue une musique
const youtube = new YouTube(GOOGLE_API_KEY); //constante qui prend les informations de la vidéo youtube (sert nottament pour la queue etc)
const queue = new Map(); //redéfinit le nom de map sous le nom de queue

client.on('warn', console.warn); //
client.on('error', console.error);
client.on('ready', () => console.log('Yo this ready!'));
client.on('disconnect', () => console.log('I just disconnected, making sure you know, I will reconnect now...'));
client.on('reconnecting', () => console.log('I am reconnecting now!'));

client.on('message', async msg => { 
	if (msg.author.bot) return undefined;
	if (!msg.content.startsWith(PREFIX)) return undefined;

	const args = msg.content.split(' ');
	const searchString = args.slice(1).join(' ');
	const url = args[1] ? args[1].replace(/<(.+)>/g, '$1') : '';
	const serverQueue = queue.get(msg.guild.id);

	let command = msg.content.toLowerCase().split(' ')[0];
	command = command.slice(PREFIX.length)

	if (command === 'play') {
		const voiceChannel = msg.member.voiceChannel;
		if (!voiceChannel) return msg.channel.send('I\'m sorry but you need to be in a voice channel to play music!');
		const permissions = voiceChannel.permissionsFor(msg.client.user);
		if (!permissions.has('CONNECT')) {
			return msg.channel.send('I cannot connect to your voice channel, make sure I have the proper permissions!');
		}
		if (!permissions.has('SPEAK')) {
			return msg.channel.send('I cannot speak in this voice channel, make sure I have the proper permissions!');
		}

		if (url.match(/^https?:\/\/(www.youtube.com|youtube.com)\/playlist(.*)$/)) {
			const playlist = await youtube.getPlaylist(url);
			const videos = await playlist.getVideos();
			for (const video of Object.values(videos)) {
				const video2 = await youtube.getVideoByID(video.id); 
				await handleVideo(video2, msg, voiceChannel, true); 
			}
			return msg.channel.send(`✅ Playlist: **${playlist.title}** has been added to the queue!`);
		} else {
			try {
				var video = await youtube.getVideo(url);
			} catch (error) {
				try {
					var videos = await youtube.searchVideos(searchString, 10);
					let index = 0;
					msg.channel.send(`
__**Song selection:**__

${videos.map(video2 => `**${++index} -** ${video2.title}`).join('\n')}

Please provide a value to select one of the search results ranging from 1-10.
					`);
					
					try {
						var response = await msg.channel.awaitMessages(msg2 => msg2.content > 0 && msg2.content < 11, {
							maxMatches: 1,
							time: 10000,
							errors: ['time']
						});
					} catch (err) {
						console.error(err);
						return msg.channel.send('No or invalid value entered, cancelling video selection.');
					}
					const videoIndex = parseInt(response.first().content);
					var video = await youtube.getVideoByID(videos[videoIndex - 1].id);
				} catch (err) {
					console.error(err);
					return msg.channel.send('🆘 I could not obtain any search results.');
				}
			}
			return handleVideo(video, msg, voiceChannel);
		}
	} else if (command === 'skip') {
		if (!msg.member.voiceChannel) return msg.channel.send('You are not in a voice channel!');
		if (!serverQueue) return msg.channel.send('There is nothing playing that I could skip for you.');
		serverQueue.connection.dispatcher.end('Skip command has been used!');
		return undefined;
	} else if (command === 'stop') {
		if (!msg.member.voiceChannel) return msg.channel.send('You are not in a voice channel!');
		if (!serverQueue) return msg.channel.send('There is nothing playing that I could stop for you.');
		serverQueue.songs = [];
		serverQueue.connection.dispatcher.end('Stop command has been used!');
		return undefined;
	} else if (command === 'volume') {
		if (!msg.member.voiceChannel) return msg.channel.send('You are not in a voice channel!');
		if (!serverQueue) return msg.channel.send('There is nothing playing.');
		if (!args[1]) return msg.channel.send(`The current volume is: **${serverQueue.volume}**`);
		serverQueue.volume = args[1];
		serverQueue.connection.dispatcher.setVolumeLogarithmic(args[1] / 5);
		return msg.channel.send(`I set the volume to: **${args[1]}**`);
	} else if (command === 'np') {
		if (!serverQueue) return msg.channel.send('There is nothing playing.');
		return msg.channel.send(`🎶 Now playing: **${serverQueue.songs[0].title}**`);
	} else if (command === 'queue') {
		if (!serverQueue) return msg.channel.send('There is nothing playing.');
		return msg.channel.send(`
__**Song queue:**__

${serverQueue.songs.map(song => `**-** ${song.title}`).join('\n')}

**Now playing:** ${serverQueue.songs[0].title}
		`);
	} else if (command === 'pause') {
		if (serverQueue && serverQueue.playing) {
			serverQueue.playing = false;
			serverQueue.connection.dispatcher.pause();
			return msg.channel.send('⏸ Paused the music for you!');
		}
		return msg.channel.send('There is nothing playing.');
	} else if (command === 'resume') {
		if (serverQueue && !serverQueue.playing) {
			serverQueue.playing = true;
			serverQueue.connection.dispatcher.resume();
			return msg.channel.send('▶ Resumed the music for you!');
		}
		return msg.channel.send('There is nothing playing.');
	}

	return undefined;
});

async function handleVideo(video, msg, voiceChannel, playlist = false) {
	const serverQueue = queue.get(msg.guild.id);
	console.log(video);
	const song = {
		id: video.id,
		title: Util.escapeMarkdown(video.title),
		url: `https://www.youtube.com/watch?v=${video.id}`
	};
	if (!serverQueue) {
		const queueConstruct = {
			textChannel: msg.channel,
			voiceChannel: voiceChannel,
			connection: null,
			songs: [],
			volume: 5,
			playing: true
		};
		queue.set(msg.guild.id, queueConstruct);

		queueConstruct.songs.push(song);

		try {
			var connection = await voiceChannel.join();
			queueConstruct.connection = connection;
			play(msg.guild, queueConstruct.songs[0]);
		} catch (error) {
			console.error(`I could not join the voice channel: ${error}`);
			queue.delete(msg.guild.id);
			return msg.channel.send(`I could not join the voice channel: ${error}`);
		}
	} else {
		serverQueue.songs.push(song);
		console.log(serverQueue.songs);
		if (playlist) return undefined;
		else return msg.channel.send(`✅ **${song.title}** has been added to the queue!`);
	}
	return undefined;
}

function play(guild, song) {
	const serverQueue = queue.get(guild.id);

	if (!song) {
		serverQueue.voiceChannel.leave();
		queue.delete(guild.id);
		return;
	}
	console.log(serverQueue.songs);

	const dispatcher = serverQueue.connection.playStream(ytdl(song.url))
		.on('end', reason => {
			if (reason === 'Stream is not generating quickly enough.') console.log('Song ended.');
			else console.log(reason);
			serverQueue.songs.shift();
			play(guild, serverQueue.songs[0]);
		})
		.on('error', error => console.error(error));
	dispatcher.setVolumeLogarithmic(serverQueue.volume / 5);

	serverQueue.textChannel.send(`🎶 Start playing: **${song.title}**`);
}


clients.commands = new Discord.Collection();

  

clients.on("ready", () => {
    console.log("Ready");console.log(clients.user);clients.user.setActivity();console.log(clients.user);
});


clients.on('message', message =>{

	let msg = message.content.toUpperCase(); // This variable takes the message, and turns it all into uppercase so it isn't case sensitive
    let sender = message.author;  //This variable takes the message, and finds who the author is.
    let cont = message.content.slice(PREFIX.length).split(" "); // This variable slices off the PREFIX, then puts the rest in an array based off
	let args = cont.slice(1); // This slices off the command in cont, only Leaving the argument


    if (msg.startsWith(PREFIX + 'PURGE')){ // This time we have to use startsWith, since we will be adding a number to the end of the command
		async function purge(){
			message.delete(); //let's delete command message (he doen't interfere with the message)

			if (message.member.roles.find("name", "clients-commander")){ //This checks to see if they don't have it
				message.channel.send('You need \`clients-commander\` role to use this command.');
				return; // This returns the code and reset this
			}

			if (isNaN(args[0])) { //IsNaN => We want to check if the argument is anumber
				message.channel.send('Please use a nomber as your argument. \n Usage ' + PREFIX +'purge <amount>') //if don't cancel the script and return
				return;
			}

			const fetched = await message.channel.fetchMessages({limit: args[0]}); // This grabs the last number(args) of messages in channel.
			console.log(fetched.size + 'message found, deleting...'); //lets post into console how many messages we are deleting

			message.channel.bulkDelete(fetched) //for delete message
				.catch(error => message.channel.send('Error: ${error}')); // it is for find a error into the post in the channel
        }
        purge();
    }
	if (msg.startsWith(PREFIX + 'WEATHER')) {

        weather.find({search: args.join(" "), degreeType: 'C°'}, function(err, result) {
			if (err) message.channel.send(err);

			if (result.length === 0) {
				message.channel.send(`**Please enter a valid location.**`)
				return;
			}
			
			var current = result[0].current; //location JSON inmput
			var location = result[0].location; //IDEM
			var nombre = current.temperature-32; //Var for had Fahrenheit => Celcius
			
			const embed = new Discord.RichEmbed()
				.setDescription(`**${current.skytext}**`)
				.setAuthor(`Météo pour ${current.observationpoint}`) // shearch location of weather
				.setThumbnail(current.imageUrl)
				.setColor(0x00AE86)
				.addField('fuseau horaire',`UTC${location.timezone}`, true)
				.addField(`Unité de température`,"C°")
				.addField(`Temperature`,`${nombre*5/9} Degré `, true)
				.addField(`Les vents `,current.winddisplay, true)
				.addField('Humidité', `${current.humidity}%`, true)

				message.channel.send({embed});
        });
	}
	



});

clients.on('ready',() => {
	console.log('clients Lauched...')
})
clients.login(TOKEN);
client.login(TOKEN);
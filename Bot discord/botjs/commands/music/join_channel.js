const commando = require('discord.js-commando');
const YTDL = require('ytdl-core');

function Play(connection, message)
{
    var server =  servers [message.guild.id];
    server.dipatcher = connection.playStream(YTDL(server.queue[0], {filter: "audioonly"}));
    server.queue.shift();
    server.dipatcher.on("end", function(){
        if(server.queue[0])
        {
            Play(connection,message);
        }
        else
        {
            connection.disconnect();
        }
    });
}

class JoinChannelCommand extends commando.Command
{
    constructor(client)
    {
        super(client,{
            name: 'join',
            group: 'music',
            memberName: 'join',
            description: 'Rejoins un channel avec !join'
        });
    }

    async run(message, args)
    {
        if(message.member.voiceChannel)
        {
            console.log("5");
            if(!message.guild.voiceConnection)
            {
                console.log("8");
                if(!servers[message.guild.id])
                {
                    servers[message.guild.id] = {queue: []};console.log("4");
                }
                console.log("6");
                message.member.voiceChannel.join().then(console.log("1"))
                    .then(connection =>{
                        var server = servers[message.guild.id];console.log("2");
                        message.reply("Succesfully joined!");console.log("3");
                        server.queue.push(args);
                        Play(connection, message);
                    })

            }
        }
        else
        {
            message.reply("You must be in a voiceChannel to summon me!");
        }
    }
}

module.exports = JoinChannelCommand;



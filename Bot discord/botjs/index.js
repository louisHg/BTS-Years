const Commando = require('discord.js-commando');
const discord = require('discord.js');
const bot = new Commando.Client();
const TOKEN ='NTU4NzQ3NDkwOTg0MjYzNzQx.D3j5Cw.KxHioWyOpihtE9BgdJT3hJ9x4pg'

bot.registry.registerGroup('simple', 'Simple');
bot.registry.registerGroup('music', 'Music');
bot.registry.registerGroup('team', 'Team');
bot.registry.registerDefaults();
bot.registry.registerCommandsIn(__dirname +'/commands');

global.currentTeamMembers = [];
global.servers = {};

bot.on('ready',function(){
    console.log("Ready");
})

bot.on("guildMemberAdd", function(Member)
{
    Member.send("Bienvenue dans notre monde");
});


bot.on('message', function(message){
    if(message.content == 'salut')
    {
        message.channel.sendMessage('salut'+ message.author + ',ça va');
    }
    if(message.content == 'join')
    {
        message.member.send('Bienvenue dans notre monde');
    }
    else if(message.content == "STOP")
    {
        var teamInfo = new discord.RichEmbed()
            .setTitle("Current Team Members")
        for(var i = 0; i< currentTeamMembers.length; i++)
        {
            teamInfo.addField("Member "+ (i+1).toString(),currentTeamMembers[i].username);
        }
        message.channel.send(teamInfo);
    }
});

bot.login(TOKEN);
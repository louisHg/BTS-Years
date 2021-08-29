const commando = require('discord.js-commando');
const discord = require('discord.js');

class InfoAboutMeCommand extends commando.Command
{
    constructor(client)
    {
        super(client,{
            name: 'info',
            group: 'simple',
            memberName: 'info',
            description: 'Apprend-en un peu plus sur moi avec !info'
        });
    }

    async run(message, args)
    {
        var myInfo = new discord.RichEmbed()
            .setTitle("DRAW MY LIFE")
            .addField("Hey", "Je suis Timy de la Normandie", true)
            .addField("Mais ", "Fais attention à ne pas faire de bétise", false)
            .setColor("#110000")
            .setThumbnail(message.author.avatarURL)
            .setURL("https://www.youtube.com")
            .setFooter("Merci d'avoir lu")
        
        message.channel.sendEmbed(myInfo);
    }   
}

module.exports = InfoAboutMeCommand;
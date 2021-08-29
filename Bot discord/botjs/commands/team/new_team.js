const commando = require('discord.js-commando');

class NewTeamCommand extends commando.Command
{
    constructor(client)
    {
        super(client,{
            name: 'new_team',
            group: 'team',
            memberName: 'new_team',
            description: "Réinitialise l'équipes avec !new_team"
        });
    }

    async run(message, args)
    {
        currentTeamMembers = []
        message.reply("L'équipe actuelle a été réinitialisée");
    }
}

module.exports = NewTeamCommand;
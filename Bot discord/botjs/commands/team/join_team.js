const commando = require('discord.js-commando');

class JoinTeamCommand extends commando.Command
{
    constructor(client)
    {
        super(client,{
            name: 'join_team',
            group: 'team',
            memberName: 'join_team',
            description: "permet de s'inscire à une team participant à un événement avec !join_team et arrête avec STOP"
        });
    }

    async run(message, args)
    {
        currentTeamMembers.push(message.author);
    }
}

module.exports = JoinTeamCommand;
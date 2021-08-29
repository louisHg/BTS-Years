const commando = require('discord.js-commando');

class DiceRollCommand extends commando.Command
{
    constructor(client)
    {
        super(client,{
            name: 'dés',
            group: 'simple',
            memberName: 'dés',
            description: 'lance le dés avec !dés'
        });
    }

    async run(message, args)
    {
        var DiceRoll = Math.floor(Math.random()*6) + 1;
        message.reply("ton dés est tombé sur le numéro " + DiceRoll)
    }
}

module.exports = DiceRollCommand;
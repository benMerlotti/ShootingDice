using ShootingDice;

List<CreativeTaunt> taunts = new List<CreativeTaunt>
{
    new CreativeTaunt { Id = 1, Taunt = "Is that the best you can do? My grandma rolls better than that!" },
    new CreativeTaunt { Id = 2, Taunt = "You’ve got the dice, but I’ve got the skills. Better luck next time!" },
    new CreativeTaunt { Id = 3, Taunt = "I hope you brought your A-game, because I’m about to crush it!" },
    new CreativeTaunt { Id = 4, Taunt = "Is it even possible to roll lower than that? Seriously?" },
    new CreativeTaunt { Id = 5, Taunt = "Did you forget how to roll, or is that just your 'strategy'?" },
    new CreativeTaunt { Id = 6, Taunt = "Oh, so that’s your roll? Guess I’ll take it easy then!" },
    new CreativeTaunt { Id = 7, Taunt = "What’s the matter? Afraid to roll higher? Too bad!" },
    new CreativeTaunt { Id = 8, Taunt = "I could teach you how to roll... but you might not be ready!" },
    new CreativeTaunt { Id = 9, Taunt = "I’m sorry, I didn’t know we were playing ‘Let’s Lose’!" },
    new CreativeTaunt { Id = 10, Taunt = "Did you bring those dice from a yard sale or something?" },
    new CreativeTaunt { Id = 11, Taunt = "I’ve seen better rolls from a broken toaster!" },
    new CreativeTaunt { Id = 12, Taunt = "Keep rolling like that and you’ll need a miracle!" },
    new CreativeTaunt { Id = 13, Taunt = "Is it possible to roll worse than that? I think you’ve just set a record!" },
    new CreativeTaunt { Id = 14, Taunt = "Hope you didn’t bet on that roll, it’s a guaranteed loss!" },
    new CreativeTaunt { Id = 15, Taunt = "That roll was so weak, even a baby could do better!" }
};


Player player1 = new Player();
player1.Name = "Bob";

Player player2 = new Player();
player2.Name = "Sue";

player2.Play(player1);

Console.WriteLine("-------------------");

Player player3 = new Player();
player3.Name = "Wilma";

player3.Play(player2);

Console.WriteLine("-------------------");

Player large = new LargeDicePlayer();
large.Name = "Bigun Rollsalot";

player1.Play(large);

Console.WriteLine("-------------------");

Player smack = new SmackTalkingPlayer("You are done!");
smack.Name = "Mister Smack";

Console.WriteLine("-------------------");

Player oneUp = new OneHigherPlayer();
oneUp.Name = "One Upper";

Console.WriteLine("-------------------");

Player human = new HumanPlayer();
human.Name = "Ben";
human.Play(player1);

Console.WriteLine("-------------------");

Player creative = new CreativeSmackTalkingPlayer(taunts);
creative.Name = "Creative Asshole";
creative.Play(player1);

Console.WriteLine("-------------------");

Player sore = new SoreLoserPlayer();
sore.Name = "Mister Sore";
sore.Play(player2);

Console.WriteLine("-------------------");

List<Player> players = new List<Player>() {
    player1, player2, player3, large, smack, oneUp, human, creative, sore
};

PlayMany(players);

static void PlayMany(List<Player> players)
{
    Console.WriteLine();
    Console.WriteLine("Let's play a bunch of times, shall we?");

    // We "order" the players by a random number
    // This has the effect of shuffling them randomly
    Random randomNumberGenerator = new Random();
    List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

    // We are going to match players against each other
    // This means we need an even number of players
    int maxIndex = shuffledPlayers.Count;
    if (maxIndex % 2 != 0)
    {
        maxIndex = maxIndex - 1;
    }

    // Loop over the players 2 at a time
    for (int i = 0; i < maxIndex; i += 2)
    {
        Console.WriteLine("-------------------");

        // Make adjacent players play noe another
        Player player1 = shuffledPlayers[i];
        Player player2 = shuffledPlayers[i + 1];
        player1.Play(player2);
    }
}
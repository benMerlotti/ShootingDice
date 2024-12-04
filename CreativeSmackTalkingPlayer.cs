namespace ShootingDice;
// A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
public class CreativeSmackTalkingPlayer : Player
{

    public List<CreativeTaunt> Taunts { get; set; }
    public CreativeSmackTalkingPlayer(List<CreativeTaunt> taunts)
    {
        // Initialize the Taunts list if it is not passed in as a parameter
        Taunts = taunts;
    }
    public override void Play(Player other)
    {
        // Randomly select a taunt from the list
        Random random = new Random();
        var taunt = Taunts[random.Next(Taunts.Count)];

        // Output the taunt
        Console.WriteLine($"{Name} shouts: \"{taunt.Taunt}\"");

        // Call the base class Play method to roll the dice and compare results
        base.Play(other);
    }
}
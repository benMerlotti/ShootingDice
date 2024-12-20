namespace ShootingDice;
// TODO: Complete this class

// Override the Play method to make a Player who always roles one higher than the other player
public class OneHigherPlayer : Player
{
    public override void Play(Player other)
    {
        int otherRoll = other.Roll();

        int myRoll = otherRoll + 1;

        if (myRoll > DiceSize)
        {
            myRoll = DiceSize; // Set to maximum possible roll
        }

        Console.WriteLine($"{other.Name} rolls a {otherRoll}");
        Console.WriteLine($"{Name} rolls a {myRoll}");
        if (myRoll > otherRoll)
        {
            Console.WriteLine($"{Name} Wins!");
        }
        else if (myRoll < otherRoll)
        {
            Console.WriteLine($"{other.Name} Wins!");
        }
        else
        {
            // if the rolls are equal it's a tie
            Console.WriteLine("It's a tie");
        }
    }
}

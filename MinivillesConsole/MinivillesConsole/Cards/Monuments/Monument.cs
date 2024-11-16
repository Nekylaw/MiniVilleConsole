namespace Minivilles_Console.Cards.Monuments;

public class Monument : Card
{
    public bool IsActive;
    public Monument()
    {
        this.Type = "Monument";
        this.AnyRound = false;
        this.Stackable = false;
    }
}
namespace Minivilles_Console.Cards.Buildings;

public class Building : Card
{
    public int Payout;
    public int[] Activation;

    public Building()
    {
        this.Type = "Building";
        this.Stackable = true;
    }
}
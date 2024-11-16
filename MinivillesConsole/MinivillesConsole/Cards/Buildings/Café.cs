namespace Minivilles_Console.Cards.Buildings;

public class Café : Building
{
    public Café()
    {
        this.Name = "Café";
        this.Cost = 2;
        this.Activation = [3];
        this.AnyRound = true;
        this.Payout = 1;
    }
}
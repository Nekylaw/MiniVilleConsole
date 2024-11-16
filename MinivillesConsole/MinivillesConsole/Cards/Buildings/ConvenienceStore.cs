namespace Minivilles_Console.Cards.Buildings;

public class ConvenienceStore : Building
{
    public ConvenienceStore()
    {
        this.Name = "Convenience Store";
        this.Cost = 2;
        this.Activation = [4];
        this.AnyRound = false;
        this.Payout = 3;
    }
}
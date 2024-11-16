namespace Minivilles_Console.Cards.Buildings;

public class Bakery : Building
{
    public Bakery()
    {
        this.Name = "Bakery";
        this.Cost = 1;
        this.Activation = [2,3];
        this.AnyRound = false;
        this.Payout = 1;
    }
}
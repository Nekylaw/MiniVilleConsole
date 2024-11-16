namespace Minivilles_Console.Cards.Buildings;

public class Ranch : Building
{
    public Ranch()
    {
        this.Name = "Ranch";
        this.Cost = 1;
        this.Activation = [2];
        this.AnyRound = true;
        this.Payout = 1;
    }
}
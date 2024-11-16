namespace Minivilles_Console.Cards.Buildings;

public class Forest : Building
{
    public Forest()
    {
        this.Name = "Forest";
        this.Cost = 3;
        this.Activation = [5];
        this.AnyRound = true;
        this.Payout = 1;
    }
}
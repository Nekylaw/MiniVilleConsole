using System.Runtime.CompilerServices;

namespace Minivilles_Console.Cards.Buildings;

public class WheatField : Building
{
    public WheatField()
    {
        this.Name = "Wheat Field";
        this.Cost = 1;
        this.Activation = [1];
        this.AnyRound = true;
        this.Payout = 1;
    }
}
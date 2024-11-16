using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinivillesConsole
{
    public class Player
    {
        public string name { get; private set; }
        public int coins { get; set; }
        public bool canRollTwoDice { get; private set; }
        public bool canReroll { get; set; }
        public List<Cards> cardsOwned { get; private set; }
        public List<int> Dices { get; private set; }

        public Player(string name)
        {
            this.name = name;
            coins = 3;
            canRollTwoDice = false;
            canReroll = false;
            cardsOwned = new List<Cards>();
            Dices = new List<int> { 0, 0 };
        }

        public void BuyCard(Cards card)
        {
            if (coins >= card.cost && card.cardsLeftStore > 0)
            {
                coins -= card.cost;
                cardsOwned.Add(card);
                card.cardsLeftStore--;

                if (card.name == "train station")
                {
                    canRollTwoDice = true;
                }

                if (card.name == "radio tower")
                {
                    canReroll = true;
                }
            }
        }

        public void ActivateCards(Player opponent, int diceValue)
        {
            foreach (var card in cardsOwned)
            {
                if (card.diceValue1 == diceValue || card.diceValue2 == diceValue)
                {
                    card.Effect(this, opponent);
                }
            }
        }

        public void DisplayCards()
        {
            foreach (var card in cardsOwned)
            {
                Console.WriteLine($"- {card.name} ({card.color}) : {card.gainValue} gain(s) [Activation : {card.diceValue1}, {card.diceValue2}]");
            }
        }
    }
}

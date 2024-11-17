using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinivillesConsole
{
    
    public class Player
    {   
        //public List<Cards> unlockedMonuments = new List<Cards>();
        public string name;
        public int coins;
        public bool canRollTwoDice;
        public bool canReroll;
        public List<Cards> cardsOwned;
        public List<int> Dices;

        public Player(string name)
        {
            this.name = name;
            coins = 3;
            //canRollTwoDice = false;
            //canReroll = false;
            cardsOwned = new List<Cards>();
            Dices = new List<int> { 0, 0 };
        }

        public bool BuyCard(Cards card)
        {
            if (coins >= card.cost && card.cardsLeftStore > 0)
            {
                coins -= card.cost;
                card.cardsLeftStore--;
                cardsOwned.Add(card);

                Console.WriteLine($"{name} a acheté {card.name}.");
                return true;
            }
            else
            {
                if (coins < card.cost)
                    Console.WriteLine($"{name} n'a pas assez de pièces pour acheter {card.name}.");
                else if (card.cardsLeftStore <= 0)
                    Console.WriteLine($"{card.name} est en rupture de stock.");

                return false;
            }
        }

        public void ActivateCards(Player opponent, int diceValue)
        {
            foreach (var card in cardsOwned)
            {
                if (card.diceValue1 == diceValue || card.diceValue2 == diceValue)
                {
                    if (card.color == "blue" || card.color == "green")
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

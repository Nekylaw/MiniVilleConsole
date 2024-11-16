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
        public string name { get; }
        public int coins { get; private set; }
        public List<Cards> Cards { get; }
        public bool canRollTwoDice { get; private set; }
        public bool canReroll { get; private set; }

        public Player(string name)
        {
            this.name = name;
            coins = 3;
            Cards = new List<Cards>
            {
                new Cards("Champs de blé", "Bleu", 1, "Recevez 1 pièce", 1),
            new Cards("Boulangerie", "Vert", new[] { 2, 3 }, "Recevez 2 pièces", 1)
            };
            canRollTwoDice = false;
            canReroll = false;
        }

        public void AddCard(Cards card)
        {
            Cards.Add(card);


            if (card.name == "train station")
            {
                canRollTwoDice = true;
            }
            if (card.name == "radio tower")
            {
                canReroll = true;
            }
        }

        public void AddCoins(int amount)
        {
            coins += amount;
        }

        public void SubtractCoins(int amount)
        {
            coins = Math.Max(0, coins - amount);
        }

        public void ActivateCards(Player opponent, int diceSum)
        {
            foreach (var card in Cards)
            {
                if (card.IsActivated(diceSum) && (card.Color == "Bleu" || card.Color == "Vert"))
                {
                    ApplyCardEffect(this, opponent, card);
                }
            }

            if (name == "Joueur")
            {
                foreach (var card in opponent.Cards)
                {
                    if (card.IsActivated(diceSum) && (card.Color == "Bleu" || card.Color == "Rouge"))
                    {
                        ApplyCardEffect(opponent, this, card);
                    }
                }
            }
        }

        private void ApplyCardEffect(Player owner, Player opponent, Card card)
        {
            if (card.Name == "Café" || card.Name == "Restaurant")
            {
                int amount = card.Name == "Café" ? 1 : 2;
                int transfer = Math.Min(opponent.coins, amount);
                opponent.SubtractCoins(transfer);
                owner.AddCoins(transfer);
                Console.WriteLine($"{owner.name} active {card.Name} et prend {transfer} pièces à {opponent.name}.");
            }
            else
            {
                int amount = int.Parse(card.Effect.Split(' ')[1]);
                owner.AddCoins(amount);
                Console.WriteLine($"{owner.name} active {card.Name} et gagne {amount} pièces.");
            }
        }

        public override string ToString()
        {
            string cards = string.Join(", ", Cards);
            return $"Player 1: {coins} pièces, Cartes: {cards}";
        }
    }
}

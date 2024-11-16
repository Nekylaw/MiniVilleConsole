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
        public string Name { get; }
        public int Coins { get; private set; }
        public List<Card> Cards { get; }

        public Player(string name)
        {
            Name = name;
            Coins = 3;
            Cards = new List<Card>
            {
                new Card("Champs de blé", "Bleu", 1, "Recevez 1 pièce", 1),
            new Card("Boulangerie", "Vert", new[] { 2, 3 }, "Recevez 2 pièces", 1)
            };
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
        }

        public void SubtractCoins(int amount)
        {
            Coins = Math.Max(0, Coins - amount);
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

            if (Name == "Joueur")
            {
                foreach (var card in opponent.Cards)
                {
                    if (card.IsActivated(diceSum) && (card.Color == "Bleu" || card.Color == "Rouge"))
                    {
                        ApplyCardEffect(opponent, this, card);
                    }
                }
            }

        public override string ToString()
        {
            string cards = string.Join(", ", Cards);
            return $"Player 1: {Coins} pièces, Cartes: {cards}";
        }
    }

}

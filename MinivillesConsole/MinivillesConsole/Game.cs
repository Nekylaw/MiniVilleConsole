 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinivillesConsole
{
    internal class Game
    {
        private List<Player> players = new();
        private int currentPlayerIndex = 0;
        private Dice dice = new Dice();
        private Random r = new Random();
        Pile shop = new Pile();

        public void Run()
        {
            players.Add(new Player("Player"));
            players.Add(new Player("AI"));

            Console.WriteLine("Début de la partie de Miniville !");

            while (players[0].coins < 20 && players[1].coins < 20)
            {
                PlayTurn();
                currentPlayerIndex++;
            }
            foreach (var player in players)
            {
                if(player.coins >= 20)
                {
                    Console.WriteLine($"Joueur {player.name} a gagné en atteignant 20 pièces!");
                }
            }
        }

        private void PlayTurn()
        {
            Player activePlayer = players[currentPlayerIndex];
            Player otherPlayer = players[(currentPlayerIndex + 1) % players.Count];

            Console.WriteLine($"C'est au tour de {activePlayer.name}. Ses cartes sont: ");
            activePlayer.DisplayCards();
            int diceRoll = 0;
            int n = 1;
            if (activePlayer.canRollTwoDice)
            {
                if (activePlayer.name == "AI")
                {
                    n = r.Next(1,3);
                }
                else
                {
                    Console.Write("Voulez-vous lancer 1 ou 2 dés? (1/2)");
                    n = int.Parse(Console.ReadLine());
                    Console.Write("Appuyez sur n'importe quel touche pour lancer les dés.");
                    Console.ReadLine();
                }
            }
            for (int i = 0; i <= n; i++)
            {
                diceRoll += dice.Throw();
            }

            Console.WriteLine($"{activePlayer.name} a obtenu {diceRoll}");

            otherPlayer.ActivateCards(activePlayer, diceRoll);

            activePlayer.ActivateCards(otherPlayer, diceRoll);

            Console.WriteLine("il est temps d'acheter une carte");
            string choice;
            if (activePlayer.name == "AI")
            {
                var cles = shop.decksByName.Keys;
                choice = cles[r.Next(0, cles.Length-1)];
            }
            else
            {
                Console.WriteLine("vous pouvez acheter:");
                shop.DisplayCards();
                choice = Console.ReadLine();
            }
            while (!activePlayer.BuyCard(shop.decksByName[choice]))
            {
                if (activePlayer.name == "AI")
                {
                    var cles = shop.decksByName.Keys;
                    choice = cles[r.Next(0, cles.Length - 1)];
                }
                else
                {
                    Console.WriteLine("vous pouvez acheter:");
                    shop.DisplayCards();
                    choice = Console.ReadLine();
                }
            }
            Console.WriteLine($"{activePlayer.name} a acheté {shop.decksByName[choice]}. Il reste {shop.decksByName[choice].cardsLeftStore}");

            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }
    }
}

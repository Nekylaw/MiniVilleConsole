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
            Thread.Sleep(1000);

            while (players[0].coins < 20 && players[1].coins < 20)
            {
                PlayTurn(players[currentPlayerIndex]);
                currentPlayerIndex = (currentPlayerIndex == 1) ? 0 : 1;
            }
            foreach (var player in players)
            {
                if(player.coins >= 20)
                {
                    Console.WriteLine($"Joueur {player.name} a gagné en atteignant 20 pièces!");
                }
            }
        }

        private void PlayTurn(Player ActivePlayer)
        {
            Player activePlayer = ActivePlayer;
            Player otherPlayer = (currentPlayerIndex == 1) ? players[0] : players[1];

            Console.WriteLine($"C'est au tour de {activePlayer.name}. Il détient {activePlayer.coins} et ses cartes sont: ");
            activePlayer.DisplayCards();
            activePlayer.DisplayCards();
            int diceRoll = 0;
            int n = 1;
            if (activePlayer.name == "AI")
            {
                n = r.Next(1,3);
            }
            else
            {
                Console.Write("Voulez-vous lancer 1 ou 2 dés? (1/2)");
                n = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i <= n; i++)
            {
                diceRoll += dice.Throw();
            }

            Console.WriteLine($"{activePlayer.name} a obtenu {diceRoll}");
            Thread.Sleep(500);

            otherPlayer.ActivateCards(activePlayer, diceRoll);

            activePlayer.ActivateCards(otherPlayer, diceRoll);

            Console.WriteLine("il est temps d'acheter une carte");
            Thread.Sleep(100);
            string choice;
            if (activePlayer.name == "AI")
            {
                //prends une clé aléatoire
                choice = shop.decksByName.ElementAt(r.Next(0, shop.decksByName.Count)).Key;
            }
            else
            {
                Console.WriteLine($"vous avez {activePlayer.coins} pièces et pouvez acheter:");
                shop.displayCards();
                choice = Console.ReadLine();
            }
            while (!activePlayer.BuyCard(shop.decksByName[choice]))
            {
                if (activePlayer.name == "AI")
                {
                    choice = shop.decksByName.ElementAt(r.Next(0, shop.decksByName.Count)).Key;
                }
                else
                {
                    Console.WriteLine("vous pouvez acheter:");
                    shop.displayCards();
                    choice = Console.ReadLine();
                }
            }
            Console.WriteLine($"{activePlayer.name} a acheté {shop.decksByName[choice].name}. Il reste {shop.decksByName[choice].cardsLeftStore}");
            Thread.Sleep(500);
        }
    }
}

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

        /// <summary>
        /// start a game
        /// </summary>
        public void Run()
        {
            //initialize all players
            players.Add(new Player("Player"));
            players.Add(new Player("AI"));

            Console.WriteLine("Début de la partie de Miniville !");
            Thread.Sleep(1000);

            //game loop
            while (players[0].coins < 20 && players[1].coins < 20)
            {
                Console.Clear();
                PlayTurn(players[currentPlayerIndex]);
                currentPlayerIndex = (currentPlayerIndex == 1) ? 0 : 1;
            }
            //display the end of the game
            foreach (var player in players)
            {
                if(player.coins >= 20)
                {
                    Console.WriteLine($"Joueur {player.name} a gagné en atteignant 20 pièces!");
                }
            }
        }

        /// <summary>
        /// start and play a round for a player
        /// </summary>
        /// <param name="ActivePlayer"> the player who rolls the dice </param>
        private void PlayTurn(Player ActivePlayer)
        {
            Player activePlayer = ActivePlayer;
            Player otherPlayer = (currentPlayerIndex == 1) ? players[0] : players[1];
            
            //display whose playing and which cards he's handling
            Console.WriteLine($"C'est au tour de {activePlayer.name}. Il détient {activePlayer.coins} pièces  et ses cartes sont: ");
            Thread.Sleep(1000);
            activePlayer.DisplayCards();
            Thread.Sleep(1000);
            
            int diceRoll = 0;
            int n = 1;
            //AI decides if she wants to roll 1 or 2 dices
            if (activePlayer.name == "AI")
            {
                n = r.Next(1,3);
            }
            //player decides if he wants to roll 2 dices
            else
            {
                Console.Write("Voulez-vous lancer 1 ou 2 dés? (1/2)");
                n = int.Parse(Console.ReadLine());
            }

            //dices being rolled
            for (int i = 1; i <= n; i++)
            {
                diceRoll += dice.Throw();
            }
            Console.WriteLine($"{activePlayer.name} a obtenu {diceRoll}");
            Thread.Sleep(500);

            //activate the card's effects based on the dices
            otherPlayer.ActivateCards(activePlayer, diceRoll);
            activePlayer.ActivateCards(otherPlayer, diceRoll);

            Console.WriteLine("il est temps d'acheter une carte");
            Thread.Sleep(100);
            string choice;
            // purchase cards
            if (activePlayer.name == "AI")
            {
                //prends une clé aléatoire
                choice = shop.decksByName.ElementAt(r.Next(0, shop.decksByName.Count)).Key;
                if (activePlayer.coins == 0)
                    choice = "/";
            }
            else
            {
                Console.WriteLine($"vous avez {activePlayer.coins} pièces et pouvez acheter:");
                shop.displayCards();
                choice = Console.ReadLine();
            }

            // if player decides to not buy anything
            if (choice != "/")
            {
                //while it is not a valid answer, we ask which card the player wants
                while (!activePlayer.BuyCard(shop.decksByName[choice]))
                {
                    if (activePlayer.name == "AI")
                    {
                        choice = shop.decksByName.ElementAt(r.Next(0, shop.decksByName.Count)).Key;
                        if (activePlayer.coins == 0)
                            choice = "/";
                    }
                    else
                    {
                        shop.displayCards();
                        choice = Console.ReadLine();
                    }
                    // if player decides to not buy anything
                    if (choice == "/") break;
                }
            }
            
            // if it is AI's turn, we stop the display for reading
            if (activePlayer.name == "AI")
                Thread.Sleep(7000);
        }
    }
}

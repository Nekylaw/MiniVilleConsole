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
                while(!int.TryParse(Console.ReadLine(), out n) || n<1 ||n>2)
                {
                    Console.WriteLine("saisie invalide. Veuillez réessayer.");
                }

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

            //display shop and ask the player to buy
            shop.displayCards();
            string choice = purchaseChoice(activePlayer);
            if (choice != "/")
            {
                while (!activePlayer.BuyCard(shop.decksByName[choice]))
                {
                    choice = purchaseChoice(activePlayer);
                    if (choice == "/")
                    {
                        Console.Write("FFFFFFFFFFFFFF");
                        break;
                    }
                }
            }

            // wait for the player to read
            Console.WriteLine("Appuyez sur Entrée pour continuer.");
            Console.ReadLine();
        }

        /// <summary>
        /// return a valid choice of card to buy
        /// </summary>
        /// <param name="activePlayer">the player deciding which card to buy</param>
        /// <returns></returns>
        private string purchaseChoice(Player activePlayer)
        {
            string choice;
            if (activePlayer.name == "AI")
            {
                choice = shop.decksByName.ElementAt(r.Next(0, shop.decksByName.Count - 1)).Key;
                if (activePlayer.coins == 0)
                {
                    choice = "/";
                }
            }
            else
            {
                choice = Console.ReadLine();
                while (!shop.decksByName.Keys.Contains(choice) && choice != "/")
                {
                    Console.WriteLine("mauvaise saisie. Veuillez réessayer");
                    choice = Console.ReadLine();
                }
            }
            return choice;
        }
    }
}

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
        //Cards shop = new Cards()

        public void Run()
        {
            players.Add(new Player("Player"));
            players.Add(new Player("AI"));

            Console.WriteLine("Début de la partie de Miniville !");
            while (players[0].unlockedMonuments.Count <4 && players[1].unlockedMonuments.Count < 4)
            {
                PlayTurn();
                currentPlayerIndex++;
            }
            foreach (var player in players)
            {
                if(player.unlockedMonuments.Count == 4)
                {
                    Console.WriteLine($"Joueur {player.name} a gagné en construisant ses 4 monuments!");
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
            //reste reroll a ajouter
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
                //carte aléatoire mais faut m'expliquer le shop
                // choice = prends clé aléatoire dans dict du shop
            }
            else
            {
                Console.WriteLine("vous pouvez acheter:");
                //Dans classe shop mettre display qui prends en paramètre le joueur
                //choice = int.Parse(Console.WriteLine());

                //BuyCard devrait être bool et return true ou false si transaction réussie et tant que transaction échouée, demander quelle carte on veut
                
            }
            //activePlayer.BuyCard(/*dict shop*/)

            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }
    }
}

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

        private void Run()
        {
            Console.WriteLine("Début de la partie de Miniville !");
            PlayTurn();
        }

        private void PlayTurn()
        {
            //faut faire action de IA encore
            Player activePlayer = players[currentPlayerIndex];
            Player otherPlayer = players[(currentPlayerIndex + 1) % players.Count];

            Console.WriteLine($"C'est au tour de {activePlayer.name} ");
            int diceRoll = 0;
            int n = 1;
            if (activePlayer.canRollTwoDice)
            {
                Console.Write("Voulez-vous lancer 1 ou 2 dés? (1/2)");
                n = int.Parse(Console.ReadLine());
            }
            Console.Write("Appuyez sur n'importe quel touche pour lancer les dés.");
            Console.ReadLine();
            for (int i = 0; i <= n; i++)
            {
                diceRoll += dice.Throw();
            }

            Console.WriteLine($"{activePlayer.name} a obtenu {diceRoll}");

            otherPlayer.ActivateCards(activePlayer, diceRoll);

            activePlayer.ActivateCards(otherPlayer, diceRoll);

            // acheter cartes

            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }
    }
}

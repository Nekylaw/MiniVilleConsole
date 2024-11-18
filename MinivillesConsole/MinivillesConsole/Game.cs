namespace MinivillesConsole
{
    internal class Game
    {
        private readonly List<Player> _players = new();
        private int _currentPlayerIndex;
        private readonly Dice _dice = new Dice();
        private readonly Random _r = new Random();
        private readonly Pile _shop = new Pile();

        /// <summary>
        /// start a game
        /// </summary>
        public void Run()
        {
            //initialize all players
            _players.Add(new Player("Player"));
            _players.Add(new Player("AI"));

            Console.WriteLine("Début de la partie de Minivilles !");
            Thread.Sleep(1000);

            //game loop
            while (_players[0].Coins < 20 && _players[1].Coins < 20)
            {
                Console.Clear();
                PlayTurn(_players[_currentPlayerIndex]);
                _currentPlayerIndex = (_currentPlayerIndex == 1) ? 0 : 1;
            }
            //display the end of the game
            foreach (var player in _players)
            {
                if(player.Coins >= 20)
                {
                    Console.WriteLine($"Joueur {player.Name} a gagné en atteignant 20 pièces!");
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
            Player otherPlayer = (_currentPlayerIndex == 1) ? _players[0] : _players[1];
            
            //display whose playing and which cards he's handling
            Console.WriteLine($"C'est au tour de {activePlayer.Name}. Il détient {activePlayer.Coins} pièce(s) et ses cartes sont: ");
            Thread.Sleep(1000);
            activePlayer.DisplayCards();
            Thread.Sleep(1000);
            
            int diceRoll = 0;
            int n;
            //AI decides if she wants to roll 1 or 2 dices
            if (activePlayer.Name == "AI")
            {
                n = _r.Next(1,3);
            }
            //player decides if he wants to roll 2 dices
            else
            {
                Console.Write("Voulez-vous lancer 1 ou 2 dés? (1/2)");
                while(!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Saisie invalide. Veuillez réessayer.");
                }
            }

            //dices being rolled
            for (int i = 1; i <= n; i++)
            {
                diceRoll += _dice.Throw();
            }
            Console.WriteLine($"{activePlayer.Name} a obtenu un {diceRoll}");
            Thread.Sleep(500);

            //activate the card's effects based on the dices
            otherPlayer.ActivateCards(activePlayer, diceRoll, false);
            activePlayer.ActivateCards(otherPlayer, diceRoll, true);

            Console.WriteLine("Il est temps d'acheter une carte!");
            Thread.Sleep(100);

            //display shop and ask the player to buy
            _shop.DisplayCards();
            string choice = PurchaseChoice(activePlayer);
            if (choice != "/")
            {
                while (!activePlayer.BuyCard(_shop.DecksByName[choice]))
                {
                    choice = PurchaseChoice(activePlayer);
                    if (choice == "/")
                    {
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
        private string PurchaseChoice(Player activePlayer)
        {
            string choice;
            if (activePlayer.Name == "AI")
            {
                choice = _shop.DecksByName.ElementAt(_r.Next(0, _shop.DecksByName.Count - 1)).Key;
                if (activePlayer.Coins == 0)
                {
                    choice = "/";
                }
            }
            else
            {
                choice = Console.ReadLine();
                while (!_shop.DecksByName.Keys.Contains(choice) && choice != "/")
                {
                    Console.WriteLine("Mauvaise saisie. Veuillez réessayer");
                    choice = Console.ReadLine();
                }
            }
            return choice;
        }
    }
}

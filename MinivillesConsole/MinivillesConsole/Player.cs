namespace MinivillesConsole
{
    
    public class Player
    {   
        //Attributs de la classe player
        public readonly string Name;                 //Nom du joueur
        public int Coins;                   //Nombre de pieces que le joueur possède
        public bool CanRollTwoDice;         //Indique si le joueur peut lancer 2 dés
        public bool CanReroll;              //Indique si le joueur peut relancer ses dés
        public readonly List<Cards> CardsOwned;      //Liste des cartes possédées par le joueur

        public Player(string name)
        {
            this.Name = name;   //Nom du joueur
            Coins = 3;          //La partie commence avec 3 pièces
            //Liste des cartes avec 2 cartes attribuées en début de partie
            CardsOwned =
            [
                new Cards("CB", "champs de blé", 1, 1, "harvest", "blue", 1, 0),
                new Cards("BO", "boulangerie", 1, 1, "shop", "green", 2, 3)
            ];
        }

        public bool BuyCard(Cards card)
        {
            if (Coins >= card.Cost && card.CardsLeftStore > 0) //Vérifie si le joueur peut acheter sa carte
            {
                Coins -= card.Cost;         //Retire le coût en pieces de la carte du porte monnaie du joueur
                card.CardsLeftStore--;      //Réduit le stock de la carte
                CardsOwned.Add(card);       //Ajoute la carte pour le joueur
                
                Console.WriteLine($"{Name} a acheté {card.Name}. Il en reste {card.CardsLeftStore}.");
                return true;                //Achat réussi
            }
            else
            {
                //On gère les cas où l'achat n'est pas possible
                if (Coins < card.Cost)
                    Console.WriteLine($"{Name} n'a pas assez de pièces pour acheter {card.Name}.");
                else if (card.CardsLeftStore <= 0)
                    Console.WriteLine($"{card.Name} est en rupture de stock.");

                return false;
            }
        }

        public void ActivateCards(Player opponent, int diceValue, bool hasItsTurn)
        {
            foreach (var card in CardsOwned)    //Parcours les cartes du joueur
            {
                //Vérifie si la carte est activées par le dé
                if (card.DiceValue1 == diceValue || card.DiceValue2 == diceValue)
                {
                    //Si la carte est bleue ou verte son effet se déclenche
                    if (card.Color == "blue" || (card.Color == "green" && hasItsTurn))
                        card.Effect(this, opponent);
                }
            }
        }

        public void DisplayCards()
        {
            //Montre au joueur toutes les cartes qu'il possède
            foreach (var card in CardsOwned)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"- {card.Name} ({card.Color}) : {card.GainValue} gain(s) [Activation : {card.DiceValue1}, {card.DiceValue2}]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

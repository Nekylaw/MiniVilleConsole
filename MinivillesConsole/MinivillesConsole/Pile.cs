namespace MinivillesConsole
{
    public class Pile : Cards
    {

        public readonly Dictionary<string, Cards> DecksByName;
        public Pile() : base("","", 0, 0, "", "", 0, 0)
        {
            DecksByName = new Dictionary<string, Cards>();
            InitializeDeck();
        }
        
        public void DisplayCards()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Achetez une carte en saisissant la commande associée:");
            foreach (var cardType in DecksByName.Keys)
            {
                Cards card = DecksByName[cardType];
                Console.Write($"-'{cardType}': Achète un.e {card.Name} pour {card.Cost} pièce(s) [{(card.Color == "green"? "Durant votre tour uniquement" : "Peu importe le tour")}");
                Console.Write($", {(card.Color == "red"? "volez" : "gagnez")} {card.GainValue} pièce(s)");
                switch (card.Id)
                {
                    case "FR":
                        Console.Write(" pour chaque ferme que vous possédez");
                        break;
                    case "FM":
                        Console.Write(" pour chaque forêt et mine que vous possédez");
                        break;
                    case "MA":
                        Console.Write(" pour chaque champs de blé et verger que vous possédez");
                        break;
                }
                Console.WriteLine($" sur un {card.DiceValue1}{(card.DiceValue2 != 0? $" ou un {card.DiceValue2}" : "")}] ({card.CardsLeftStore} restants)");
            }
            Console.WriteLine("-'/': Passer la phase d'achat");
            Console.ForegroundColor= ConsoleColor.White;
        }

        private void InitializeDeck()
        {
            List<Cards> allCards = new List<Cards>
            {
                new Cards("CB","champs de blé", 1, 1, "harvest", "blue", 1, 0),
                new Cards("FO","forêt", 3, 1, "natural", "blue", 5, 0),
                new Cards("MI","mine", 6, 5, "natural", "blue", 9, 0),
                new Cards("FE","ferme", 2, 1, "breeding", "blue", 2, 0),
                new Cards("VE","verger", 3, 3, "harvest", "blue", 10, 0),
                new Cards("BO","boulangerie", 1, 1, "shop", "green", 2, 3),
                new Cards("SU","supérette", 2, 3, "shop", "green", 4, 0),
                new Cards("FR","fromagerie", 5, 3, "factory", "green", 7, 0),
                new Cards("FM","fabrique de meubles", 3, 3, "factory", "green", 8, 0),
                new Cards("MA","marché", 5, 2, "grocery", "green", 11, 12),
                new Cards("CA","café", 2, 1, "restaurant", "red", 3, 0),
                new Cards("RE","restaurant", 3, 2, "restaurant", "red", 9, 10)
                /*new Cards("BC","business center", 8, 0, "establishment", "purple", 6, 0, 6), //EXCEPTION : échange d'établissement avec un joueur
                new Cards("TE","television", 7, 5, "establishment", "purple", 6, 0, 6),
                new Cards("ST","stadium", 6, 2, "establishment", "purple", 6, 0,6),*/
            };

            // Regrouper les cartes par couleur
            foreach (Cards card in allCards)
                DecksByName[card.Id] = card;
        }
    }
}
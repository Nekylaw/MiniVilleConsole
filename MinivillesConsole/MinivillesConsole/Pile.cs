    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinivillesConsole
{
    public class Pile : Cards
    {

        public Dictionary<string, Cards> decksByName;
        public Pile() : base("","", 0, 0, "", "", 0, 0, 6)
        {
            decksByName = new Dictionary<string, Cards>();
            initializeDeck();
        }



        public void displayCards()
        {
            Console.WriteLine("Achetez une carte en saisissant la commande associée:");
            foreach (var cardType in decksByName.Keys)
            {
                Console.WriteLine($"-'{cardType}': Achète un.e {decksByName[cardType].name} pour {decksByName[cardType].cost} pièces ({decksByName[cardType].cardsLeftStore} restants)");
            }
            Console.WriteLine("-'/': Passer la phase d'achat");
        }

        public void initializeDeck()
        {
            List<Cards> allCards = new List<Cards>
            {
                new Cards("WF","champs de ble", 1, 1, "harvest", "blue", 1, 0, 6),
                new Cards("FO","foret", 3, 1, "natural", "blue", 5, 0, 6),
                new Cards("MI","mine", 6, 5, "natural", "blue", 9, 0, 6),
                new Cards("FA","ferme", 2, 1, "breeding", "blue", 2, 0, 6),
                new Cards("VE","verger", 3, 3, "harvest", "blue", 10, 0, 6),
                new Cards("BA","boulangerie", 1, 1, "shop", "green", 2, 3, 6),
                new Cards("ST","superette", 2, 3, "shop", "green", 4, 0, 6),
                new Cards("CH","usine a fromage", 5, 3, "factory", "green", 7, 0, 6),
                new Cards("FF","usine a meubles", 3, 3, "factory", "green", 8, 0, 6),
                new Cards("MA","marche", 5, 2, "grocery", "green", 11, 12, 6),
                new Cards("CO","cafe", 2, 1, "restaurant", "red", 3, 0, 6),
                new Cards("RE","restaurant", 3, 2, "restaurant", "red", 9, 10, 6)
                /*new Cards("BC","business center", 8, 0, "establishment", "purple", 6, 0, 6), //EXCEPTION : echange d'etablissement avec un joueur
                new Cards("TE","television", 7, 5, "establishment", "purple", 6, 0, 6),
                new Cards("ST","stadium", 6, 2, "establishment", "purple", 6, 0,6),*/
            };

            // Regrouper les cartes par couleur
            foreach (Cards card in allCards)
                decksByName[card.id] = card;
        }
    }
}

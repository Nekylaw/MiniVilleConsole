using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinivillesConsole
{
    public class Pile : Cards
    {

        public Dictionary<string, List<Cards>> decksByName;
        public Pile() : base("","", 0, 0, "", "", 0, 0, 6)
        {
            decksByName = new Dictionary<string, List<Cards>>();
            initializeDeck();
        }



        public void displayCards()
        {
            

        }

        public void initializeDeck()
        {
            List<Cards> allCards = new List<Cards>
            {
                new Cards("WF","wheat field", 1, 1, "harvest", "blue", 1, 0, 6),

                new Cards("FO","forest", 2, 1, "Naturel", "blue", 5, 0, 6),
                new Cards("MI","mine", 6, 5, "Naturel", "blue", 9, 0, 6),
                new Cards("FA","farm", 2, 1, "", "blue", 2, 0, 6),
                new Cards("VE","verger", 3, 3, "Recolte", "blue", 10, 0, 6),
                new Cards("BA","bakery", 1, 2, "shop", "green", 2, 3, 6),
                new Cards("ST","store", 2, 3, "shop", "green", 4, 0, 6),
                new Cards("CH","cheese factory", 5, 3, "factory", "green", 7, 0, 6),
                new Cards("FF","furtnitures factory", 3, 3, "factory", "green", 8, 0, 6),
                new Cards("MA"," market", 5, 2, "grocery", "green", 11, 12, 6),
                new Cards("CO","coffee", 2, 1, "restauration", "red", 3, 0, 6),
                new Cards("RE","restaurant", 3, 2, "restauration", "green", 9, 10, 6),
                new Cards("BC","buisness center", 8, 0, "", "purple", 6, 0, 6), //EXCEPTION : echange d'etablissement avec un joueur
                new Cards("TE","television", 7, 5, "etablissement", "purple", 6, 0, 6),
                new Cards("ST","stadium", 6, 2, "etablissement", "purple", 6, 0,6),
            };

            // Regrouper les cartes par couleur
            foreach (Cards card in allCards)
            {
                if (!decksByName.ContainsKey(card.id))
                {
                    decksByName[card.id] = new List<Cards>();
                }
                decksByName[card.id].Add(card);
            }

        }




    }
}

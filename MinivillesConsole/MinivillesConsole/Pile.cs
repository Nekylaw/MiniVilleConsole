using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinivillesConsole
{
    public class Pile : Cards
    {

        public Dictionary<string, List<Cards>> decksByColor;
        public Pile() : base("", 0,0, "", "", 0, 0)
        {
            decksByColor = new Dictionary<string, List<Cards>>();
            initializeDeck();
        }


        public void initializeDeck()
        {
            List<Cards> allCards = new List<Cards>
            {
                new Cards("wheat field", 1, 1, "harvest", "blue", 1, 0),
                new Cards("forest", 2, 1, "Naturel", "blue", 5, 0),
                new Cards("mine", 6, 5, "Naturel", "blue", 9, 0),
                new Cards("farm", 2, 1, "", "blue", 2, 0),
                new Cards("verger", 3, 3, "Recolte", "blue", 10, 0),
                new Cards("bakery", 1, 2, "shop", "green", 2, 3),
                new Cards("store", 2, 3, "shop", "green", 4, 0),
                new Cards("cheese factory", 5, 3, "factory", "green", 7, 0),
                new Cards("Fabrique de meubles", 3, 3, "Usine", "green", 8, 0),
                new Cards("market", 5, 2, "grocery", "green", 11, 12),
                new Cards("coffee", 2, 1, "restauration", "red", 3, 0),
                new Cards("restaurant", 3, 2, "restauration", "green", 9, 10),
                new Cards("buisness center", 8, 0, "", "purple", 6, 0), //EXCEPTION : echange d'etablissement avec un joueur
                new Cards("television", 7, 5, "etablissement", "purple", 6, 0),
                new Cards("stadium", 6, 2, "etablissement", "purple", 6, 0),
            };      

            // Regrouper les cartes par couleur
            foreach (Cards card in allCards)
            {
                if (!decksByColor.ContainsKey(card.color))
                {
                    decksByColor[card.color] = new List<Cards>();
                }
                decksByColor[card.color].Add(card);
            }
        }

    }
}

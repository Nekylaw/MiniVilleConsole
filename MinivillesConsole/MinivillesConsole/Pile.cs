﻿    using System;
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
            Console.WriteLine("Buy a card from the shop using one of the following commands of your choice:");
            foreach (var cardType in decksByName.Keys)
            {
                Console.WriteLine($"-'{cardType}': Buy a {decksByName[cardType].name} for {decksByName[cardType].cost} coins ({decksByName[cardType].cardsLeftStore} left)");
            }
            Console.WriteLine("-'/': Skip the buying phase");
        }

        public void initializeDeck()
        {
            List<Cards> allCards = new List<Cards>
            {
                new Cards("WF","wheat field", 1, 1, "harvest", "blue", 1, 0, 6),
                new Cards("FO","forest", 3, 1, "natural", "blue", 5, 0, 6),
                new Cards("MI","mine", 6, 5, "natural", "blue", 9, 0, 6),
                new Cards("FA","farm", 2, 1, "breeding", "blue", 2, 0, 6),
                new Cards("VE","verger", 3, 3, "harvest", "blue", 10, 0, 6),
                new Cards("BA","bakery", 1, 2, "shop", "green", 2, 3, 6),
                new Cards("ST","store", 2, 3, "shop", "green", 4, 0, 6),
                new Cards("CH","cheese factory", 5, 3, "factory", "green", 7, 0, 6),
                new Cards("FF","furnitures factory", 3, 3, "factory", "green", 8, 0, 6),
                new Cards("MA","market", 5, 2, "grocery", "green", 11, 12, 6),
                new Cards("CO","coffee", 2, 1, "restaurant", "red", 3, 0, 6),
                new Cards("RE","restaurant", 3, 2, "restaurant", "red", 9, 10, 6),
                new Cards("BC","business center", 8, 0, "establishment", "purple", 6, 0, 6), //EXCEPTION : echange d'etablissement avec un joueur
                new Cards("TE","television", 7, 5, "establishment", "purple", 6, 0, 6),
                new Cards("ST","stadium", 6, 2, "establishment", "purple", 6, 0,6),
            };

            // Regrouper les cartes par couleur
            foreach (Cards card in allCards)
                decksByName[card.id] = card;
        }
    }
}

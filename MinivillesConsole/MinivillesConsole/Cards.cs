using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinivillesConsole
{
    public class Cards
    {


        public int cost;
        public int gainValue;
        public string name;
        public string type;
        public string color;
        public int stackable;
        public int anyRound;
        public int diceValue1;
        public int diceValue2;
        public int cardsLeftStore = 6;




        #region
        Cards weatField = new Cards("wheat field", 1, 1, "harvest", "blue", 1, 0);
        Cards forest = new Cards("forest", 2, 1, "Naturel", "blue", 5, 0);
        Cards mine = new Cards("mine", 6, 5, "Naturel", "blue", 9, 0);
        Cards farm = new Cards("farm", 2, 1, "", "blue", 2, 0);
        Cards verger = new Cards("verger", 3, 3, "Recolte", "blue", 10, 0);
        Cards bakery = new Cards("bakery", 1, 2, "shop", "green", 2, 3);
        Cards shop = new Cards("store", 2, 3, "shop", "green", 4, 0);
        Cards cheeseFactory = new Cards("cheese factory", 5, 3, "factory", "green", 7, 0);
        Cards furnituresFactory = new Cards("Fabrique de meubles", 3, 3, "Usine", "green", 8, 0);
        Cards market = new Cards("market", 5, 2, "grocery", "green", 11, 12);
        Cards coffeeShop = new Cards("coffee", 2, 1, "restauration", "red", 3, 0);
        Cards restaurant = new Cards("restaurant", 3, 2, "restauration", "green", 9, 10);
        Cards buisnessCenter = new Cards("buisness center", 8, 0, "", "purple", 6, 0); //EXCEPTION : echange d'etablissement avec un joueur
        Cards tvChannel = new Cards("television", 7, 5, "etablissement", "purple", 6, 0);
        Cards stadium = new Cards("stadium", 6, 2, "etablissement", "purple", 6, 0);
        #endregion

        Cards trainStation = new Cards("train station", 4, 0, "Monument", "special", 0, 0);
        Cards parc = new Cards("park", 16, 0, "Monument", "special", 0, 0);
        Cards mall = new Cards("mall", 10, 1, "Monument", "special", 0, 0);
        Cards radio = new Cards("radio tower", 22, 0, "Monument", "special", 0, 0);

        public Cards(string name, int cost, int gainValue, string type, string color, int diceValue1, int diceValue2)
        {


        }



        List<Cards> unlockedMonuments = new List<Cards>();
        List<Cards> allBuildings = new List<Cards>();


        public List<Cards> listBuildings = new List<Cards>();



        //La fonction qui g�re les effets des cartes hors monuments

        //CardPlayed correspond � la carte jou� pendant le tour actuel (est d�finit dans la classe player)
        public void Effect(Player playerSendingEffect, Player playerReceivingEffect)
        {

            if (this.color == "Blue")
            {

                playerSendingEffect.coins += this.gainValue;
                playerReceivingEffect.coins += this.gainValue;

            }
            if (this.color == "Red")
            {
                playerSendingEffect.coins += this.gainValue;
                playerReceivingEffect.coins -= this.gainValue;

            }
            if (this.color == "Green")
            {
                if (this.name == "Store")
                {
                    playerSendingEffect.coins += this.gainValue;
                }
                if (this.name == "Market")
                {
                    playerSendingEffect.coins += this.gainValue;
                }
            }
            if (this.color == "Purple")
            {

                playerSendingEffect.coins += this.gainValue;
                playerReceivingEffect.coins -= this.gainValue;
                
            }

        }
        //G�re les effets des monuments
        public void monumentEffect(Player player)
        {

            foreach (var monument in unlockedMonuments)
            {
                if (monument.name == "train station")
                {
                    Console.WriteLine($"{player} peut lancer 2 dés.");
                }
                if (monument.name == "radio tower")
                {
                    player.canReroll = true;
                }
                if (monument.name == "mall")
                {
                    foreach (var card in player.cards)
                    {
                        if (card.info.type == "restauration" || card.info.type == "shop")
                        {
                            card.info.gainValue += 1;
                        }
                    }

                }
                if (monument.name == "park")
                {
                    if (player.dices[0].face == player.dices[1].face)
                    {
                        player.c0anReroll = true;
                    }
                }

            }

        }




    }
}

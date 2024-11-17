using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public string id;




        //#region
        //Cards weatField = new Cards("WF", "wheat field", 1, 1, "harvest", "blue", 1, 0, 6);
        //Cards forest = new Cards("FO", "forest", 2, 1, "Naturel", "blue", 5, 0, 6);
        //Cards mine = new Cards("MI","mine", 6, 5, "Naturel", "blue", 9, 0, 6);
        //Cards farm = new Cards("FA", "farm", 2, 1, "", "blue", 2, 0, 6);
        //Cards verger = new Cards("VE", "verger", 3, 3, "Recolte", "blue", 10, 0, 6);
        //Cards bakery = new Cards("BA", "bakery", 1, 2, "shop", "green", 2, 3, 6);
        //Cards shop = new Cards("ST","store", 2, 3, "shop", "green", 4, 0, 6);
        //Cards cheeseFactory = new Cards("CH","cheese factory", 5, 3, "factory", "green", 7, 0, 6);
        //Cards furnituresFactory = new Cards("FF","furnitures factory", 3, 3, "Usine", "green", 8, 0, 6);
        //Cards market = new Cards("MA","market", 5, 2, "grocery", "green", 11, 12, 6);
        //Cards coffeeShop = new Cards("CO","coffee", 2, 1, "restauration", "red", 3, 0, 6);
        //Cards restaurant = new Cards("RE","restaurant", 3, 2, "restauration", "green", 9, 6, 6);
        //Cards buisnessCenter = new Cards("BC","buisness center", 8, 0, "", "purple", 6, 0, 6); //EXCEPTION : echange d'etablissement avec un joueur
        //Cards tvChannel = new Cards("TE","television", 7, 5, "etablissement", "purple", 6, 0, 6);
        //Cards stadium = new Cards("ST","stadium", 6, 2, "etablissement", "purple", 6, 0, 6);
        //#endregion

        //Cards trainStation = new Cards("train station", 4, 0, "Monument", "special", 0, 0, 0);
        //Cards parc = new Cards("park", 16, 0, "Monument", "special", 0, 0, 0);
        //Cards mall = new Cards("mall", 10, 1, "Monument", "special", 0, 0, 0);
        //Cards radio = new Cards("radio tower", 22, 0, "Monument", "special", 0, 0, 0);

        public Cards(string Id, string Name, int Cost, int GainValue, string Type, string Color, int DiceValue1, int DiceValue2, int CardsLeftStore)
        {
            name = Name;
            cost = Cost;
            gainValue = GainValue;
            type = Type;
            color = Color;
            diceValue1 = DiceValue1;
            diceValue2 = DiceValue2;
            cardsLeftStore = CardsLeftStore;
            id = Id;

        }



      
        List<Cards> allBuildings = new List<Cards>();


        public List<Cards> listBuildings = new List<Cards>();



        //La fonction qui g�re les effets des cartes hors monuments

        //CardPlayed correspond � la carte jou� pendant le tour actuel (est d�finit dans la classe player)
        public void Effect(Player playerSendingEffect, Player playerReceivingEffect)
        {

            if (this.color == "Blue")
            {

                playerSendingEffect.coins += this.gainValue;

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
        //public void monumentEffect(Player player)
        //{

        //    foreach (var monument in player.unlockedMonuments)
        //    {
        //        if (monument.name == "train station")
        //        {
        //            Console.WriteLine($"{player} peut lancer 2 dés.");
        //        }
        //        if (monument.name == "radio tower")
        //        {
        //            player.canReroll = true;
        //        }
        //        if (monument.name == "mall")
        //        {
        //            foreach (var card in player.cardsOwned)
        //            {
        //                if (card.type == "restauration" || card.type == "shop")
        //                {
        //                    card.gainValue += 1;
        //                }
        //            }

        //        }
        //        if (monument.name == "park")
        //        {
        //            /*if (player.dices[0].face == player.dices[1].face) //faire le truc pour le doublon de dés 
        //            {
        //                player.canReroll = true;
        //            }*/
        //        }

        //    }

        //}




    }
}

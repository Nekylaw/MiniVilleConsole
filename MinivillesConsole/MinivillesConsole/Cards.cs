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

        //attributs associés à chaque carte du jeu
        public int cost;
        public int gainValue; //ce que la carte permet de gagner en pièces
        public string name;
        public string type;
        public string color;
        public int anyRound;
        public int diceValue1; //première valeur possible du dé pour déclencher l'effet de la carte
        public int diceValue2; //première valeur possible du dé pour déclencher l'effet de la carte
        public int cardsLeftStore = 6;
        public string id;



        
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

        //La fonction qui gère les effets des cartes hors monuments
        public void Effect(Player playerSendingEffect, Player playerReceivingEffect) //playerSendingEffect correspond au joueur qui lance les dés et playerReceivingEffect tous les autres joueurs 
        {
            //initalisation de l'effet des cartes en fonction de leur couleur : on ajoute des pièces au joueur actuel parfois au détriment d'autres joueurs
            if (this.color == "blue")
            {

                playerSendingEffect.coins += this.gainValue;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n {playerSendingEffect.name} reçoit {this.gainValue} pièces de {this.name}");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (this.color == "red")
            {
                playerSendingEffect.coins += this.gainValue;
                playerReceivingEffect.coins -= this.gainValue;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n {playerSendingEffect.name} reçoit {this.gainValue} pièces de {playerReceivingEffect.name} par le biais de {this.name}");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (this.color == "green")
            {
                if (this.type == "shop")
                {
                    playerSendingEffect.coins += this.gainValue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n {playerSendingEffect.name} reçoit {this.gainValue} pièces de {this.name}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else //cas spécial des cartes vertes qui ajoutent un nombre de pièces spécifiques pour certains types de cartes
                {
                    int gain = 0;
                    string researched = "";
                    switch (this.name) //condition sur le nom des cartes vertes spéciales
                    {
                        case "usine a fromage":
                            researched = "breeding";
                            break;
                        case "usine a meubles":
                            researched = "natural";
                            break;
                        case "marche":
                            researched = "harvest";
                            break;
                    }
                    foreach (var card in playerSendingEffect.cardsOwned) //on parcours la main du joueur qui vient de lancer les dés
                    {
                        if (card.type == researched) //si le joueur a des cartes au type affecté, on ajoute pour chacune d'entre elle le montant du gain de la carte verte spécial
                        {
                            gain += this.gainValue; 
                        }
                    }
                    playerSendingEffect.coins += gain;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n {playerSendingEffect.name} reçoit {gain} pièces de {this.name}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            

        }





    }
}

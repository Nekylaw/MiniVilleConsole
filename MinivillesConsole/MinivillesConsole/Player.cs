using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinivillesConsole
{
    
    public class Player
    {   
        //Attributs de la classe player
        public string name;                 //Nom du joueur
        public int coins;                   //Nombre de pieces que le joueur possède
        public bool canRollTwoDice;         //Indique si le joueur peut lancer 2 dés
        public bool canReroll;              //Indique si le joueur peut relancer ses dés
        public List<Cards> cardsOwned;      //Liste des cartes possedées par le joueur 
        public List<int> Dices;             //Liste des résultats des dés

        public Player(string name)
        {
            this.name = name;   //Nom du joueur
            coins = 3;          //La partie commence avec 3 îeces
            //Liste des cartes avec 2 cartes attrivuées en début de partie
            cardsOwned = new List<Cards> { new Cards("CB", "champs de ble", 1, 1, "harvest", "blue", 1, 0, 6),
                                           new Cards("BO", "boulangerie", 1, 1, "shop", "green", 2, 3, 6)        };
        }

        public bool BuyCard(Cards card)
        {
            if (coins >= card.cost && card.cardsLeftStore > 0) //Vérifie si le joueur peut acheter sa carte
            {
                coins -= card.cost;         //Retire le coût en pieces de la carte du porte monnaie du joueur
                card.cardsLeftStore--;      //Réduit le stock de la carte
                cardsOwned.Add(card);       //Ajoute la carte pour le joueur

                Console.WriteLine($"{name} a acheté {card.name}. Il en reste {card.cardsLeftStore}");
                return true;                //Achat réussi
            }
            else
            {
                //On gère les cas où l'achat n'est pas possible
                if (coins < card.cost)
                    Console.WriteLine($"{name} n'a pas assez de pièces pour acheter {card.name}.");
                else if (card.cardsLeftStore <= 0)
                    Console.WriteLine($"{card.name} est en rupture de stock.");

                return false;
            }
        }

        public void ActivateCards(Player opponent, int diceValue, bool hasItsTurn)
        {
            foreach (var card in cardsOwned)    //Parcours les cartes du joueur
            {
                //Vérifie si la carte est activées par le dé
                if (card.diceValue1 == diceValue || card.diceValue2 == diceValue)
                {
                    //Si la carte est bleue ou verte son effet se déclenche
                    if (card.color == "blue" || (card.color == "green" && hasItsTurn))
                        card.Effect(this, opponent);
                }
            }
        }

        public void DisplayCards()
        {
            //Montre au joueur toutes les cartes qu'il possède
            foreach (var card in cardsOwned)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"- {card.name} ({card.color}) : {card.gainValue} gain(s) [Activation : {card.diceValue1}, {card.diceValue2}]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

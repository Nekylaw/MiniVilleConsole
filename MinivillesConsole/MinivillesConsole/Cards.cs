namespace MinivillesConsole
{
    public class Cards
    {

        //attributs associés à chaque carte du jeu
        public readonly int Cost;
        public readonly int GainValue; //ce que la carte permet de gagner en pièces
        public readonly string Name;
        public readonly string Type;
        public readonly string Color;
        public int AnyRound;
        public readonly int DiceValue1; //première valeur possible du dé pour déclencher l'effet de la carte
        public readonly int DiceValue2; //première valeur possible du dé pour déclencher l'effet de la carte
        public int CardsLeftStore;
        public readonly string Id;



        
        public Cards(string Id, string Name, int Cost, int GainValue, string Type, string Color, int DiceValue1, int DiceValue2, int CardsLeftStore = 6)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.GainValue = GainValue;
            this.Type = Type;
            this.Color = Color;
            this.DiceValue1 = DiceValue1;
            this.DiceValue2 = DiceValue2;
            this.CardsLeftStore = CardsLeftStore;
            this.Id = Id;

        }

        //La fonction qui gère les effets des cartes hors monuments
        public void Effect(Player playerSendingEffect, Player otherPlayer) //playerSendingEffect correspond au joueur qui lance les dés et playerReceivingEffect tous les autres joueurs 
        {
            //initialisation de l'effet des cartes en fonction de leur couleur : on ajoute des pièces au joueur actuel parfois au détriment d'autres joueurs
            if (this.Color == "blue")
            {

                playerSendingEffect.Coins += this.GainValue;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n {playerSendingEffect.Name} reçoit {this.GainValue} pièce(s) de {this.Name}.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (this.Color == "red")
            {
                playerSendingEffect.Coins += this.GainValue;
                otherPlayer.Coins -= this.GainValue;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n {playerSendingEffect.Name} reçoit {this.GainValue} pièce(s) de {otherPlayer.Name} par le biais de {this.Name}.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (this.Color == "green")
            {
                if (this.Type == "shop")
                {
                    playerSendingEffect.Coins += this.GainValue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n {playerSendingEffect.Name} reçoit {this.GainValue} pièce(s) de {this.Name}.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else //cas spécial des cartes vertes qui ajoutent un nombre de pièces spécifiques pour certains types de cartes
                {
                    int gain = 0;
                    string researched = "";
                    switch (this.Name) //condition sur le nom des cartes vertes spéciales
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
                    foreach (var card in playerSendingEffect.CardsOwned) //on parcourt la main du joueur qui vient de lancer les dés
                    {
                        if (card.Type == researched) //si le joueur a des cartes au type affecté, on ajoute pour chacune d'entre elle le montant du gain de la carte verte spécial
                        {
                            gain += this.GainValue; 
                        }
                    }
                    playerSendingEffect.Coins += gain;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n {playerSendingEffect.Name} reçoit {gain} pièce(s) de {this.Name}.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            

        }





    }
}

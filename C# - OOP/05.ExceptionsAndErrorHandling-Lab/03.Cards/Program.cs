using System.Collections.ObjectModel;
using System.Drawing;

namespace _03.Cards
{
    public class Program
    {
        static void Main()
        {
            string[] deckCards = Console.ReadLine().Split(", ");
            List<Card> cards = new List<Card>();

            ChechCards(deckCards, cards);

            Console.WriteLine(String.Join(" ", cards));

        }

        private static void ChechCards(string[] deckCards, List<Card> cards)
        {
            for (int i = 0; i < deckCards.Length; i++)
            {
                try
                {
                    string[] tempPair = deckCards[i].Split(" ");

                    Card card = new Card(tempPair[0], tempPair[1]);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }

    public class Card
    {

        private readonly List<string> cardFacesList = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private readonly Dictionary<string, string> cardSiutsDT = new Dictionary<string, string> {
            { "S","\u2660"},
            { "H","\u2665"},
            { "D","\u2666"},
            { "C","\u2663"},
           };

        public Card(string cardFace, string cardSuit)
        {
            if (cardFacesList.Contains(cardFace)) this.CardFace = cardFace;
            else throw new ArgumentException("Invalid card!");

            if(cardSiutsDT.ContainsKey(cardSuit)) this.CardSuit = cardSiutsDT[cardSuit];
            else throw new ArgumentException("Invalid card!");
        }
        public string CardFace { get; }
        public string CardSuit { get; }

        public override string ToString()
        {
            return $"[{this.CardFace}{this.CardSuit}]";
        }


    }
}

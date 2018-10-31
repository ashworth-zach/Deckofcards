using System;
using System.Collections.Generic;

namespace deck
{
    public class Card
    {
        public string strVal;
        public string suit;
        public int val;

        public Card(string name, string suitType, int value)
        {
            strVal = name;
            suit = suitType;
            val = value;
        }
    }
    public class Deck{
        public List<Card> cards;
        public string[] suits = new string[4] {"hearts","diamonds","spades","clubs"};
        public string[] values = new string[13] {"Ace","two","three","four","five","six","seven","eight","nine","ten","Jack","Queen","King"};
        public Deck()
        {
            reset();
            shuffle();
            printdeck();
        }
        public Deck printdeck(){
            foreach(var x in cards){
                Console.WriteLine(x.strVal +" of "+x.suit);
            }
            return this;
        }
        public Deck reset(){
            cards = new List<Card>();
            foreach(var suitVal in suits){
                for(var i = 0;i<values.Length;i++){
                    // Card card=;
                    cards.Add(new Card(values[i],suitVal,i+1));
                }
            }
            return this;
        }
        public Deck shuffle()
        {
            Random random = new Random();
            for (int i = cards.Count; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j <= i-1
                Console.WriteLine(cards[j]+"print statement");
                // Swap.
                Card tmp = cards[j];
                cards[j] = cards[i - 1];
                cards[i - 1] = tmp;
            }
            return this;
        }
        public Card Deal()
        {
            if(cards.Count != 0)
            {
                Card tempCard = cards[0];
                cards.RemoveAt(0);
                return tempCard;
            }
            else
            {
                return null;   
            }
        }
        // {
        //     Random rand= new Random();
        //     int x=0;
        //     while(x<12){
        //         x=x+1;
        //         for(var i = 0;i<51;i++){
        //             Card temp = cards[i];
        //             Card randcard=cards[rand.Next(0,51)];
        //             cards[i]=randcard;
        //             randcard=temp;
        //         }
        //     }
        //     return this;
        // }
    }
    class Player{
        public string name;
        public List<Card> hand;
        public void Draw(Deck shuffledDeck)
        {
            hand.Add(shuffledDeck.Deal());
        }
        public Card Discard()
        {
            if(hand.Count != 0)
            {
                Card tempCard = hand[0];
                hand.RemoveAt(0);
                return tempCard;
            }
            else
            {
                return null;   
            }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck newdeck = new Deck();
            newdeck.reset();
            newdeck.printdeck();
            newdeck.shuffle();
            Console.WriteLine("HELLO");
            newdeck.printdeck();
            newdeck.Deal();
            Console.WriteLine("HELLO");

            newdeck.printdeck();


        }
    }
}}
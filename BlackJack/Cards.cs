namespace BlackJack
{
    public struct Cards
    {
        public Cards(string[] c)
        {
            Hand = c;
            AmountOfCards = 0;
        }

        public string[] Hand { get; set; }
        public int AmountOfCards { get; set; } 
    }
}
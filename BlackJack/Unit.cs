namespace BlackJack
{
    public class Unit
    {
        public Unit()
        {
            Score = 0;
            Status = true;
        }
        public int Score;
        public string Name;
        public bool Status;
        public int GlobalScore;
    }
}
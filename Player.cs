namespace BaseballReference
{
    class Player
    {
        //hits runs rbi walk strikeout AB stolen bases
        private string name;
        private int year;
        private int hits;
        public static int count;
        public Player(string name, int year, int hits)
        {
            //You can do this.name or just rename the passed in value to something else
            //This is a Data Shadowing issue
            this.name = name;
            this.year = year;
            this.hits = hits;
            IncCount();
        }
        public void SetHits(int value)
        {
            hits = value;
        }
        public int GetHits()
        {
            return hits;
        }

        public string GetName()
        {
           return name;
        }
        public void SetName(string value)
        {
           name = value;
        }
       public void SetYear(int val)
        {
           year = val;
        }
       public int GetYear()
        {
           return year;
        }
        public static void IncCount()
        {
           count++;
        }
       public static int GetCount()
        {
           return count;
        }
       public override string ToString()
        {
           return name;
        }
    }
}
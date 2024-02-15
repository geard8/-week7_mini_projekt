
namespace week7_mini_projekt
{
    abstract class Asset
    {
        public DateTime date; // date of Asset
        public float price; // cost of Asset
        public string name; // product name of Asset
        private string office; // office where Asset is.

        public Asset (DateTime date, float price, string name, string office)
        {
            this.date = date;
            this.price = price;
            this.name = name;
            Office = office;
        }

        public string Office
        {
            get { return office; }
            // set office as long as it is "Stockholm" or "Tokyo" or "Boston"
            set
            {
                if (value != "Stockholm" && value != "Tokyo" && value != "Boston") 
                { 
                    throw new ArgumentException("office and only be \"Stockholm\" or \"Tokyo\" or \"Boston\""); 
                }
                else { office = value; }

            }
        }
    }

    class Computer : Asset
    {
        public Computer(DateTime date, float price, string name, string office) : base(date, price, name, office) { }
    }
    class Phone : Asset
    {
        public Phone(DateTime date, float price, string name, string office) : base(date, price, name, office) { }
    }
}

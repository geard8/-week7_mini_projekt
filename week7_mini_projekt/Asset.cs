
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
            Price = price;
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

        public float Price
        {
            // get Price return price after converting its currency based on office
            get
            {

                // exchangeRates used to convert price based on office. Exchange rates based on google 2024-02-16
                var exchangeRates = new Dictionary<string, float>()
                {
                    { "Stockholm", (float)10.46 },
                    { "Tokyo", (float)150.20 },
                    { "Boston", 1 }
                };
                
                return price*exchangeRates[office]; 
            } 
            set { price = value; }
        }
    }

    class Computer(DateTime date, float price, string name, string office) : Asset(date, price, name, office) { }

    class Phone(DateTime date, float price, string name, string office) : Asset(date, price, name, office) { }
}

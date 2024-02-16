
using System.Collections.Generic;

namespace week7_mini_projekt
{
    abstract class Asset
    {
        public DateTime date; // date of Asset
        private float price; // cost of Asset, stored as dollar value
        public string name; // product name of Asset
        private string office; // office where Asset is.

        // exchangeRates used to convert price based on office. Exchange rates based on google 2024-02-16
        public static Dictionary<string, float> exchangeRates = new Dictionary<string, float>()
                {
                    { "Stockholm", (float)10.46 },
                    { "Tokyo", (float)150.20 },
                    { "Boston", 1 }
                };

        // exchangeRates used to convert price based on office. Exchange rates based on google 2024-02-16
        public static Dictionary<string, string> officeCurrency = new Dictionary<string, string>()
                {
                    { "Stockholm", "krona" },
                    { "Tokyo", "yen" },
                    { "Boston", "dollar" }
                };

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
                    throw new ArgumentException("Office and only be \"Stockholm\" or \"Tokyo\" or \"Boston\""); 
                }
                else { office = value; }

            }
        }

        public float Price
        {
            // get Price return price after converting its currency based on office
            get
            {
                return price*exchangeRates[office]; 
            } 
            set { price = value; }
        }

        // Return price in dollar
        public float GetdollarPrice()
        {
            return price;
        }

        public string GetCurrencyType()
        {
            return officeCurrency[office];
        }

    }

    class Computer(DateTime date, float price, string name, string office) : Asset(date, price, name, office) { }

    class Phone(DateTime date, float price, string name, string office) : Asset(date, price, name, office) { }
}

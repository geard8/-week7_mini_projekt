
namespace week7_mini_projekt
{
    abstract class Asset
    {
        public DateTime date; // date of Asset
        public float price; // cost of Asset
        public string name; // product name of Asset
        private string office; // office where Asset is.
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
}

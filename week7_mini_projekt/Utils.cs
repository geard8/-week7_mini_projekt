
using System.Diagnostics;
using System.Xml.Linq;
using week6_mini_projekt;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace week7_mini_projekt
{
    static internal class Utils
    {
        public static Asset UserCreateAsset()
        {
            bool isComputer; // isComputer true the new Asset is Computer if false it is a Phone
            string assetTypeName; // is computer or phone, used to write to console to user.
            DateTime newDate; // date of Asset
            float newPrice; // cost of Asset
            string newName; // product name of Asset
            string newOffice; // office where Asset is.
            int maxLength = 25; // max length for newCategory and newName

            Console.WriteLine("Add new Asset to the company");
            Console.WriteLine();

            // get user input for isComputer
            while (true)
            {
                // Ask user if it is a computer or phone where 1 for computer or 2 for phone.
                Console.Write("What kind of asset to create. Enter 1 for computer or 2 for phone: ");
                string assetTypeInput = Console.ReadLine();
                // set isComputer and assetTypeName if user input was 1 or 2 else it will give user feedback and to try again.
                if (assetTypeInput == "1") { isComputer = true; assetTypeName = "computer"; break; }
                else if (assetTypeInput == "2") { isComputer = false; assetTypeName = "phone"; break; }
                else { Display.DisplayColorMsg("Please only input 1 for computer or 2 for phone", "red"); }
            }

            Console.WriteLine(); // For better spacing and readability 

            // get user input for newDate
            while (true)
            {
                Console.Write($"Enter date when {assetTypeName} was purchased. Example 2009-05-08: ");
                string userStringDate = Console.ReadLine();
                try
                {
                    newDate = DateTime.ParseExact(userStringDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    break; // if setting newDate did not throw any expection, then break out of loop.
                }
                catch (Exception)
                {
                    Display.DisplayColorMsg("Invalid date, make sure you follow the format in the Example", "red");
                }
            }

            Console.WriteLine(); // For better spacing and readability 

            // get user input for newName 
            while (true)
            {
                Console.Write($"Enter {assetTypeName} Name: ");
                newName = Console.ReadLine();
                if (newName.Length > maxLength)
                {
                    Display.DisplayColorMsg("Too long can't be longer then " + maxLength + " characters", "red");
                }
                else if (newName.Trim().Length != 0) { break; }
                else
                {
                    Display.DisplayColorMsg("Name can not be empty", "red");
                }
            }

            Console.WriteLine(); // For better spacing and readability 

            // get user input for newOffice 
            while (true)
            {
                Console.WriteLine($"What office the {assetTypeName} is purchased for.");
                Console.Write($"Enter 1 for Stockholm, 2 for Tokyo or 3 for Boston: ");
                string assetOfficeInput = Console.ReadLine();
                // set newOffice if user input was 1, 2 or 3 else it will give user feedback and to try again.
                if (assetOfficeInput == "1") { newOffice = "Stockholm"; break; }
                else if (assetOfficeInput == "2") { newOffice = "Tokyo"; break; }
                else if (assetOfficeInput == "3") { newOffice = "Boston"; break; }
                else { Display.DisplayColorMsg("Please only input 1 for Stockholm, 2 for Tokyo or 3 for Boston", "red"); }
            }

            Console.WriteLine(); // For better spacing and readability 

            // get user input for newPrice.

            // askPriceString is string that will ask user for asset price. Default is string for price in dollar
            string askPriceString = $"What is what the {assetTypeName} purchased price in dollar: ";
            string useCurrency = "Boston"; // Currency to be used, default Boston.

            // if newOffice is not Boston, it is Stockholm or Tokyo and will give user option to use dollar or office local currency as price input.
            if (newOffice != "Boston")
            {
                // localCurrency is currency based on newOffice. yen for Tokyo or krona for Stockholm.
                string localCurrency = (newOffice == "Tokyo") ? "yen" : "krona";
                // Ask user for useing dollar or localCurrency.
                while (true)
                {
                    Console.Write($"Next is {assetTypeName} price, what currency do you wish to use. Enter 1 for dollar or 2 for {localCurrency}: ");
                    string userInputCurrency = Console.ReadLine();

                    // 1 is for dollar and useCurrency is Boston by default.
                    if (userInputCurrency == "1") { break; } 
                    // 2 is for setting useCurrency to "Tokyo" or "Stockholm" based on localCurrency.
                    else if (userInputCurrency == "2") { useCurrency = (localCurrency == "yen" ? "Tokyo" : "Stockholm"); break; }
                    // A invalid input from user, it will give user feedback and to try again.
                    else { Display.DisplayColorMsg($"Please only input 1 for dollar or 2 for {localCurrency}", "red"); }
                }
                Console.WriteLine(); // For better spacing and readability 
                askPriceString = $"What is what the {assetTypeName} purchased price in {localCurrency}: ";
            }
            while (true)
            {
                Console.Write(askPriceString);
                string newPriceStr = Console.ReadLine();
                if (!float.TryParse(newPriceStr, out newPrice))
                {
                    Display.DisplayColorMsg("Not a valid price. Exemple of valid price is: 31 or 43,99", "red");
                }
                else
                {
                    // set newPrice to converted value in dollar. If useCurrency is Boston newPrice will stay the same as dollar to dollar will not change value.
                    newPrice = newPrice / Asset.exchangeRates[useCurrency];
                    break;
                }
            }

            Console.WriteLine(); // For better spacing and readability

            if (assetTypeName == "computer")
            {
                return new Computer(newDate, newPrice, newName, newOffice);
            }
            else
            {
                return new Phone(newDate, newPrice, newName, newOffice);
            }
        }

        // Show a list of Asset based on listAsset to user.
        // listAsset a list of Asset.
        public static void ShowAsset(List<Asset> listAsset)
        {
            int padRightAmount = 27; // Amount of Right padding used when showing list of products
            var sortedListAsset = listAsset.OrderBy(x => x.Office).ThenBy(x => x.date); // sort listAsset by office then by date

            Console.WriteLine("Here is a list of all company asset");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine(
                "Type".PadRight(padRightAmount) +
                "Name".PadRight(padRightAmount) +
                "Office".PadRight(padRightAmount) +
                "Purchase Date".PadRight(padRightAmount) +
                "Price in dollar".PadRight(padRightAmount) +
                "Local currency".PadRight(padRightAmount) +
                "Price in local currency".PadRight(padRightAmount)
                );
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Asset asset in sortedListAsset)
            {
                string color = "green"; // used to what color a asset in list shall be, default green

                // if less then 3 months left on 3 years end of life time, show asses in red
                if (DateTime.Now.AddMonths(3).AddYears(-3) > asset.date) { color = "red"; }
                // if not less then 3 months but less then 6 month left on 3 years end of life time, show asses in yellow
                else if (DateTime.Now.AddMonths(6).AddYears(-3) > asset.date) { color = "yellow"; }

                // write out info for asset
                Display.DisplayColorMsg(
                asset.GetType().Name.PadRight(padRightAmount) +
                asset.name.PadRight(padRightAmount) +
                asset.Office.PadRight(padRightAmount) +
                asset.date.ToString("yyyy-MM-dd").PadRight(padRightAmount) +
                asset.GetdollarPrice().ToString("0.00").PadRight(padRightAmount) +
                asset.GetCurrencyType().PadRight(padRightAmount) +
                asset.Price.ToString("0.00").PadRight(padRightAmount)
                , color);
            }
        }
    }
}

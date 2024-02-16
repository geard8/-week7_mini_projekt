
using week6_mini_projekt;
using week7_mini_projekt;

// demo data for Computer and Phone to be used in list of Asset
Computer demo1 = new Computer(new DateTime(2021, 4, 13), (float)6990.99, "Big rig 9000", "Stockholm");
Computer demo2 = new Computer(new DateTime(2020, 10, 9), (float)6990.99, "Big rig 8000", "Tokyo");
Computer demo3 = new Computer(new DateTime(2022, 12, 23), (float)4990.99, "small rig 9000", "Boston");
Phone demo4 = new Phone(new DateTime(2022, 9, 22), (float)4390.99, "X 3030", "Stockholm");
Phone demo5 = new Phone(new DateTime(2021, 5, 28), (float)990.99, "Y 770", "Tokyo");
Phone demo6 = new Phone(new DateTime(2021, 7, 27), (float)749.99, "Z 6", "Boston");

// List of Asset. Start out with demo data and newly created Asset will be added.
List<Asset> listAsset = [demo1, demo2, demo3, demo4, demo5, demo6];

ConsoleKeyInfo cki; // used to store key pressed by the user

// Choice for user to add more Asset or quit program.
while (true)
{
    Utils.ShowAsset(listAsset); // Show all currenct company Asset
    while (true)
    {
        Console.WriteLine("Add new company asset - press \"A\" | To quit - press \"Q\"");
        cki = Console.ReadKey();
        Console.WriteLine();
        if (cki.Key == ConsoleKey.A || cki.Key == ConsoleKey.Q)
        {
            break;
        }
        else
        {
            Display.DisplayColorMsg("Not valid key, valid key are A or Q", "red");
        }
    }

    // If user pressed A then user can add a new Asset
    if (cki.Key == ConsoleKey.A)
    {
        listAsset.Add(Utils.UserCreateAsset());
    }
    else { break; }
}


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

Console.WriteLine("Hello, World!");

//Asset tempAsset = Utils.UserCreateAsset();

//Console.WriteLine(tempAsset.Office + tempAsset.Price + tempAsset.name + tempAsset.date);

Utils.ShowAsset(listAsset);

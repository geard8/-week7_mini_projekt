﻿
using week7_mini_projekt;

Computer demo1 = new Computer(new DateTime(2022, 3, 13), (float)6990.99, "Big rig 9000", "Stockholm");
Computer demo2 = new Computer(new DateTime(2021, 3, 9), (float)6990.99, "Big rig 9000", "Tokyo");
Computer demo3 = new Computer(new DateTime(2020, 3, 23), (float)4990.99, "small rig 9000", "Boston");
Phone demo4 = new Phone(new DateTime(2022, 3, 22), (float)6990.99, "X 3030", "Stockholm");
Phone demo5 = new Phone(new DateTime(2021, 6, 28), (float)6990.99, "Y 770", "Tokyo");
Phone demo6 = new Phone(new DateTime(2020, 6, 27), (float)6990.99, "Z 6", "Boston");

List<Asset> listAsset = [demo1, demo2, demo3, demo4, demo5, demo6];

Console.WriteLine("Hello, World!");

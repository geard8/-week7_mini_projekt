namespace week6_mini_projekt
{
    public static class Display
    {
        // DisplayColorMsg is used to write out text to consol with a selection pre defined amount of color ment to be used for diffrent purpose.
        public static void DisplayColorMsg(string msg, string color)
        {
            // red is ment to be used for misstakes or errors, ex something did not validate.
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
                Console.ResetColor();
            }

            // green is ment to be used to indicate something was done successfully.
            else if (color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            // blue is ment to be used to highlight something to draw attaction to it.
            else if (color == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            // yellow is ment for testing i shall not show up in public version unless something went wrong.
            else if (color == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            // If color is none above then give feedback that this color is not supported
            else
            {
                DisplayColorMsg("ERROR: Do not support color: " + color, "yellow");
            }
        }
    }
}

using static CSC160_ConsoleMenu.CIO;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> foo = new List<string> { "Hello,", "comma", "World", "!", "Hooray"};
            PromptForMenuSelection(foo, false);
        }
    }
}
namespace CodeReviews.Console.Calculator;
using Console = System.Console;

public static class UserInterface
{
    private static double _num1;
    private static double _num2;
    public static void Start()
    {
        bool endApp = false;
        Intro();

        while (!endApp)
        {
            _num1 = AskUserANumber();
            _num2 = AskUserANumber("second");
            Operator op = AskUserOperand();
            try
            {
                PrintResult(op);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            endApp = AskCloseApp();
        }
    }
    
    private static void Intro()
    {
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
    }

    private static double AskUserANumber(string amount = "first")
    {
        return AskUser.Ask<double>(
            [$"Type the {amount} number, and press ENTER"]);
    }

    private static Operator AskUserOperand()
    {
        return AskUser.Ask<Operator>(
            ["Choose an option from the following list",
                "\t+ - Add",
                "\t- - Subtract",
                "\t* - Multiply",
                "\t/ - Divide"]);
    }

    private static void PrintResult(Operator op)
    {
        Console.WriteLine($"Your result: {_num1} {op.GetSymbol()} {_num2} = {op.Result(_num1, _num2)}");
    }

    private static bool AskCloseApp()
    {
        Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
        return (Console.ReadLine() == "n");
    }
}
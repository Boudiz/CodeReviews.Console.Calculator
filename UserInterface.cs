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
            
            PrintResult(op);
            
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
        double num;
        bool isInvalidInput = false;
        do
        {
            if (isInvalidInput)
            {
                Console.WriteLine("This is not a valid input. Entre a double");
            }
            Console.WriteLine($"Type the {amount} number, and press ENTER");
            isInvalidInput = !double.TryParse(Console.ReadLine(), out num);
        } while (isInvalidInput);

        return num;
    }

    private static Operator AskUserOperand()
    {
        string? choice;
        bool isInvalidOption = false;
        do
        {
            if (isInvalidOption)
            {
                Console.WriteLine("Choose a correct option");
            }
            Console.WriteLine("Choose an option from the following list");
            Console.WriteLine("\t+ - Add");
            Console.WriteLine("\t- - Subtract");
            Console.WriteLine("\t* - Multiply");
            Console.WriteLine("\t/ - Divide");
            
            choice = Console.ReadLine();
            isInvalidOption = !new[] { "+", "-", "*", "/" }.Contains(choice);
        } while (isInvalidOption);

        if (choice == "/" && _num2 == 0)
        {
            Console.WriteLine("Cannot divide by zero");
            _num2 = AskUserANumber("second");
        }

        return new Operator(choice);
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
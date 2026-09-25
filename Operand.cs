using System.ComponentModel;
namespace CodeReviews.Console.Calculator;

public enum Operand
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class Operator(string? input)
{
    private Operand _operand = input?.ToUpper().Trim() switch
    {
        "+" => Operand.Addition,
        "-" => Operand.Subtraction,
        "*" => Operand.Multiplication,
        "/" => Operand.Division,
        _ => default
    };

    public double Result(double a, double b) => _operand switch
    {
        Operand.Addition => a + b,
        Operand.Subtraction => a - b,
        Operand.Multiplication => a * b,
        Operand.Division => b != 0 ? a / b : throw new DivideByZeroException("Can't divide by zero"),
        _ => throw new InvalidEnumArgumentException("Operand not recognized")
    };

    public string GetSymbol() => _operand switch
    {
        Operand.Addition => "+",
        Operand.Subtraction => "-",
        Operand.Multiplication => "*",
        Operand.Division => "/",
        _ => throw new InvalidEnumArgumentException("Operand not recognized")
    };

    public void Randomize(Random rnd)
    {
        var values = Enum.GetValues<Operand>();
        _operand = values[rnd.Next(values.Length - 1)];
    }
}

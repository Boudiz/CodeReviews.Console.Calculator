using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace CodeReviews.Console.Calculator;

public enum Operand
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class Operator : IParsable<Operator>
{
    private readonly Operand? _operand;
    
    public Operator(string? input)
    {
        _operand = input?.ToUpper().Trim() switch
        {
            "+" => Operand.Addition,
            "-" => Operand.Subtraction,
            "*" => Operand.Multiplication,
            "/" => Operand.Division,
            _ => null
        };
    }

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

    public static Operator Parse(string s, IFormatProvider? provider)
    {
        return TryParse(s, provider, out var result) ? result : throw new FormatException("Not a valid input Operator");
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Operator result)
    {
        var op = new Operator(s);

        if (op._operand == null)
        {
            result = null;
            return false;
        }

        result = op;
        return true;
    }
}

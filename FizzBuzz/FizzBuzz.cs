namespace FizzBuzz;

public interface IFizzBuzz
{
    public bool IsDivisible(int divident);
}

public abstract class FizzBuzzBase : IFizzBuzz
{
    protected int divisor;
    protected string _replacementString;

    public string replacementString
    {
        get { return _replacementString; }
    }

    public FizzBuzzBase(int divisor, string replacementString)
    {
        this.divisor = divisor;
        this._replacementString = replacementString;
    }
    public abstract bool IsDivisible(int divident);
}

public class Fizz : FizzBuzzBase
{
    private const int defaultDivisor = 3;
    private const string defaultReplacementString = "Fizz";

    public Fizz() : base(defaultDivisor, defaultReplacementString) {}

    public override bool IsDivisible(int divident)
    {
        return (divident % divisor == 0);
    }
}

public class Buzz : FizzBuzzBase
{
    private const int defaultDivisor = 5;
    private const string defaultReplacementString = "Buzz";

    public Buzz() : base(defaultDivisor, defaultReplacementString) {}

    public override bool IsDivisible(int divident)
    {
        return (divident % divisor == 0);
    }
}

using System.Reflection;
using FizzBuzz;

namespace FizzBuzz.Test;

public class UnitTest1
{
    private const string fieldNameDivisor = "divisor";
    private const string fieldNameRepstring = "_replacementString";

    private void TestFizzBuzzDivisible(IFizzBuzz testObj)
    {
        Type type = testObj.GetType();
        FieldInfo? fi = type.GetField(fieldNameDivisor, BindingFlags.NonPublic | BindingFlags.Instance);
        if (fi != null)
        {
            int testval = (int)fi.GetValue(testObj);
            Assert.False(testObj.IsDivisible(testval+1));
            Assert.True(testObj.IsDivisible(testval));
            Assert.True(testObj.IsDivisible(testval*2));
        }
    }

    private void TestFizzBuzzHasDivisor(IFizzBuzz testObj)
    {
        Type type = testObj.GetType();
        FieldInfo? fi = type.GetField(fieldNameDivisor, BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(fi);
    }

    private void TestFizzBuzzHasRepstring(IFizzBuzz testObj)
    {
        Type type = testObj.GetType();
        FieldInfo? fi = type.GetField(fieldNameRepstring, BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(fi);
    }

    [Fact]
    public void Test_Fizz_HasDivisor()
    {
        IFizzBuzz fizz = new Fizz();
        TestFizzBuzzHasDivisor(fizz);
    }

    [Fact]
    public void Test_Fizz_HasRepstring()
    {
        IFizzBuzz fizz = new Fizz();
        TestFizzBuzzHasRepstring(fizz);
    }

    [Fact]
    public void Test_Fizz_Divisible()
    {
        IFizzBuzz fizz = new Fizz();
        TestFizzBuzzDivisible(fizz);
    }

    [Fact]
    public void Test_Buzz_HasDivisor()
    {
        IFizzBuzz buzz = new Buzz();
        TestFizzBuzzHasDivisor(buzz);
    }

    [Fact]
    public void Test_Buzz_HasRepstring()
    {
        IFizzBuzz buzz = new Buzz();
        TestFizzBuzzHasRepstring(buzz);
    }

    [Fact]
    public void Test_Buzz_Divisible()
    {
        IFizzBuzz buzz = new Buzz();
        TestFizzBuzzDivisible(buzz);
    }

    [Fact]
    public void Test_FizzerBuzzer_NoReplacement()
    {
        IFizzBuzz fizz = new Fizz();
        IFizzBuzz buzz = new Buzz();
        int numFizz = (int)fizz.GetType().GetField(fieldNameDivisor, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(fizz);
        int numBuzz = (int)buzz.GetType().GetField(fieldNameDivisor, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(buzz);
        FizzerBuzzer fb = new FizzerBuzzer(new List<IFizzBuzz> {fizz, buzz});
        int testnum = numFizz*numBuzz + 1;
        Assert.Equal(testnum.ToString(), fb.FizzbuzzNumber(testnum));
    }

    [Fact]
    public void Test_FizzerBuzzer_SingleReplacement()
    {
        IFizzBuzz fizz = new Fizz();
        IFizzBuzz buzz = new Buzz();
        int numFizz = (int)fizz.GetType().GetField(fieldNameDivisor, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(fizz);
        int numBuzz = (int)buzz.GetType().GetField(fieldNameDivisor, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(buzz);
        FizzerBuzzer fb = new FizzerBuzzer(new List<IFizzBuzz> {fizz, buzz});
        Assert.Equal(fizz.GetReplacementString(), fb.FizzbuzzNumber(numFizz));
        Assert.Equal(buzz.GetReplacementString(), fb.FizzbuzzNumber(numBuzz));
    }

    [Fact]
    public void Test_FizzerBuzzer_DoubleReplacement()
    {
        IFizzBuzz fizz = new Fizz();
        IFizzBuzz buzz = new Buzz();
        int numFizz = (int)fizz.GetType().GetField(fieldNameDivisor, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(fizz);
        int numBuzz = (int)buzz.GetType().GetField(fieldNameDivisor, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(buzz);
        FizzerBuzzer fb = new FizzerBuzzer(new List<IFizzBuzz> {fizz, buzz});
        int testnum = numFizz*numBuzz;
        string result = fb.FizzbuzzNumber(testnum);
        Assert.Contains(fizz.GetReplacementString(), result);
        Assert.Contains(buzz.GetReplacementString(), result);
    }
}

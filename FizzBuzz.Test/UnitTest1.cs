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
}

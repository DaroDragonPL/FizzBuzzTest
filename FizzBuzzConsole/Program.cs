using FizzBuzz;

Console.WriteLine("Hello, World!");

IFizzBuzz fizz = new Fizz();
IFizzBuzz buzz = new Buzz();
FizzerBuzzer fb = new FizzerBuzzer(new List<IFizzBuzz> {fizz, buzz} );

for (int i=1; i<=100; i++)
{
    Console.WriteLine(fb.FizzbuzzNumber(i));
}

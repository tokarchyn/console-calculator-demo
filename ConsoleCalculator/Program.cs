using ConsoleCalculator;
using ConsoleCalculator.InputProviders;
using ConsoleCalculator.OperationProcessors;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("ConsoleCalculatorSystemTests")]
namespace ConsoleCalculator; // Note: actual namespace depends on the project name.

internal class Program
{
    public static void Main(string[] args)
    {
        var operationProcessorsResolver = new OperationProcessorsResolver(new IOperationProcessor[]
        {
            new AddOperationProcessor(),
            new SubOperationProcessor(),
            new MultiplyOperationProcessor(),
            new DivideOperationProcessor()
        });

        var calculator = new Calculator(operationProcessorsResolver);
        var result = calculator.Calculate(new FileInputProvider(args[0]));

        Console.WriteLine(result);
    }
}

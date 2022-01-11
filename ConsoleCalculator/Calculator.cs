using ConsoleCalculator.InputProviders;
using ConsoleCalculator.OperationProcessors;

namespace ConsoleCalculator;

public class Calculator
{
    private readonly OperationProcessorsResolver operationProcessorsResolver;

    public Calculator(OperationProcessorsResolver operationProcessorsResolver)
    {
        this.operationProcessorsResolver = operationProcessorsResolver;
    }

    public double Calculate(IInputProvider inputReader, double initialValue = 0)
    {
        var result = initialValue;
        foreach (var operationData in inputReader.GetOperations())
        {
            var processor = operationProcessorsResolver.GetProcessorForOperation(operationData);
            result = processor.Process(result, operationData.Argument);
        }
        return result;
    }
}

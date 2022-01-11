namespace ConsoleCalculator.OperationProcessors;

public class SubOperationProcessor : IOperationProcessor
{
    public bool CanProcess(string operationName)
    {
        return operationName == "SUB";
    }

    public double Process(double originalValue, double operationArgument)
    {
        return originalValue - operationArgument;
    }
}

namespace ConsoleCalculator.OperationProcessors;

public class AddOperationProcessor : IOperationProcessor
{
    public bool CanProcess(string operationName)
    {
        return operationName == "ADD";
    }

    public double Process(double originalValue, double operationArgument)
    {
        return originalValue + operationArgument;
    }
}

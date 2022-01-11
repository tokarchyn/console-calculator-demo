namespace ConsoleCalculator.OperationProcessors;

public class MultiplyOperationProcessor : IOperationProcessor
{
    public bool CanProcess(string operationName)
    {
        return operationName == "MUL";
    }

    public double Process(double originalValue, double operationArgument)
    {
        return originalValue * operationArgument;
    }
}

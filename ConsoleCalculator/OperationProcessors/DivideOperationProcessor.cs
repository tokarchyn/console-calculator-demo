namespace ConsoleCalculator.OperationProcessors;

public class DivideOperationProcessor : IOperationProcessor
{
    public bool CanProcess(string operationName)
    {
        return operationName == "DIV";
    }

    public double Process(double originalValue, double operationArgument)
    {
        return originalValue / operationArgument;
    }
}

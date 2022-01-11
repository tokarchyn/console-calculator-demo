namespace ConsoleCalculator.OperationProcessors;

public interface IOperationProcessor
{
    bool CanProcess(string operationName);

    double Process(double originalValue, double operationArgument);
}

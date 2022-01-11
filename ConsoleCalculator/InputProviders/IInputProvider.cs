using ConsoleCalculator.Model;

namespace ConsoleCalculator.InputProviders;

public interface IInputProvider
{
    IEnumerable<OperationData> GetOperations();
}

using ConsoleCalculator.InputProviders;
using ConsoleCalculator.Model;
using System.Collections.Generic;

namespace ConsoleCalculatorUnitTests.Utils;

internal class InMemoryInputProvider : IInputProvider
{
    private readonly OperationData[] operations;

    public InMemoryInputProvider(OperationData[] operations)
    {
        this.operations = operations;
    }

    public IEnumerable<OperationData> GetOperations()
    {
        return operations;
    }
}

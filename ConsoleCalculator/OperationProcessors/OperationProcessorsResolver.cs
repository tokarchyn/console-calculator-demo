using ConsoleCalculator.Model;

namespace ConsoleCalculator.OperationProcessors;

public class OperationProcessorsResolver
{
    private readonly IEnumerable<IOperationProcessor> operations;

    private readonly Dictionary<string, IOperationProcessor> operationProcessorCache = new();

    public OperationProcessorsResolver(IEnumerable<IOperationProcessor> operations)
    {
        this.operations = operations;
    }

    public IOperationProcessor GetProcessorForOperation(OperationData operationData)
    {
        if (!operationProcessorCache.ContainsKey(operationData.Name))
        {
            var processor = operations.FirstOrDefault(o => o.CanProcess(operationData.Name));
            if (processor == null)
            {
                throw new InvalidOperationException($"Cannot process operation: '{operationData.Name}'.");
            }

            operationProcessorCache[operationData.Name] = processor;
        }

        return operationProcessorCache[operationData.Name];
    }
}
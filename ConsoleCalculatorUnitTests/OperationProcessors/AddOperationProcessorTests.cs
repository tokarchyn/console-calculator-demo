using ConsoleCalculator.OperationProcessors;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleCalculatorTests.OperationProcessors;

[TestClass]
public class AddOperationProcessorTests
{
    [TestMethod]
    public void Can_process_operation()
    {
        new AddOperationProcessor()
            .CanProcess("ADD")
            .Should().BeTrue();
    }

    [TestMethod]
    public void Cannot_process_operation()
    {
        new AddOperationProcessor()
            .CanProcess("SOMETHING")
            .Should().BeFalse();
    }

    [TestMethod]
    public void Process_operation()
    {
        new AddOperationProcessor()
            .Process(10, 5)
            .Should().Be(15);
    }
}

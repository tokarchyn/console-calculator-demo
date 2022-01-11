using ConsoleCalculator;
using ConsoleCalculator.Model;
using ConsoleCalculator.OperationProcessors;
using ConsoleCalculatorUnitTests.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleCalculatorTests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Calculate_with_default_init_value()
    {
        var calculator = CreateCalculator();
        var inputProvider = new InMemoryInputProvider(new[]
        {
            new OperationData
            {
                Name = "ADD",
                Argument = 3
            }
        });

        var result = calculator.Calculate(inputProvider);

        result.Should().Be(3);
    }

    [TestMethod]
    public void Calculate_with_custom_init_value()
    {
        var calculator = CreateCalculator();
        var inputProvider = new InMemoryInputProvider(new[]
        {
            new OperationData
            {
                Name = "ADD",
                Argument = 3
            },
        });

        var result = calculator.Calculate(inputProvider, 10);

        result.Should().Be(13);
    }

    [TestMethod]
    public void Calculate_using_multiple_operations()
    {
        var calculator = CreateCalculator();
        var inputProvider = new InMemoryInputProvider(new[]
        {
            new OperationData
            {
                Name = "ADD",
                Argument = 3
            },
            new OperationData
            {
                Name = "ADD",
                Argument = 4
            },
            new OperationData
            {
                Name = "ADD",
                Argument = 5
            },
        });

        var result = calculator.Calculate(inputProvider);

        result.Should().Be(12);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Calculation_with_unknown_operation_should_throw_ex()
    {
        var calculator = CreateCalculator();
        var inputProvider = new InMemoryInputProvider(new[]
        {
            new OperationData
            {
                Name = "UNKNOWN",
                Argument = 3
            },
        });

        calculator.Calculate(inputProvider);
    }

    private Calculator CreateCalculator()
    {
        var operationProcessorsResolver = new OperationProcessorsResolver(new IOperationProcessor[]
        {
            new AddOperationProcessor()
        });

        return new Calculator(operationProcessorsResolver);
    }
}

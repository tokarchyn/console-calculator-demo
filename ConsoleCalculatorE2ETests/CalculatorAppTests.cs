using ConsoleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ConsoleCalculatorSystemTests;

[TestClass]
public class CalculatorAppTests
{
    [TestMethod]
    public void Run_and_calculate_operations_from_file()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { "Data\\test_1.txt" });

        Assert.AreEqual("3.5\r\n", stringWriter.ToString());
    }
}
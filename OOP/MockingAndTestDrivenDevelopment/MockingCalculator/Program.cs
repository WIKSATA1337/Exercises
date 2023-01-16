using Moq;
using System;

namespace MockingCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mock<ICalculator> mockCalculator = new Mock<ICalculator>();
            //ICalculator calculator = mockCalculator.Object;

            int numberOne = 55;
            int numberTwo = 0;

            // Setting up the Add() method.
            mockCalculator.Setup(
                calc => calc.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(7000);

            mockCalculator.Setup(
                calc => calc.Add(numberOne, numberTwo))
                .Returns(numberOne + numberTwo);

            mockCalculator.Setup(
                calc => calc.Add(It.IsAny<int>(), It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive)))
                .Throws(new ArgumentOutOfRangeException("Number must be 0 or greater."));

            mockCalculator.Setup(
                calc => calc.Add(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive), It.IsAny<int>()))
                .Throws(new ArgumentOutOfRangeException("Number must be 0 or greater."));

            mockCalculator.Setup(
                calc => calc.ToString())
                .Callback(() =>
                {
                    Console.WriteLine("ToString() method was called.");
                })
                .Returns("Im a mocked calculator!")
                .Callback(() =>
                {
                    Console.WriteLine("ToString() method finished its job.");
                });

            Console.WriteLine(mockCalculator.Object.Add(numberOne, numberTwo));
            Console.WriteLine(mockCalculator.Object.Add(11, 11));

            // Throws exception because params are negative numbers.
            //Console.WriteLine(mockCalculator.Object.Add(-183246187, -981274356));


            Console.WriteLine(mockCalculator.Object.ToString());

            mockCalculator.Verify(calc => calc.Add(It.IsAny<int>(), It.IsAny<int>()),
                Times.Exactly(3));

            mockCalculator.Verify(calc => calc.Add(55, 0),
                Times.Exactly(1));

            // Throws exception because called times are 3.
            //mockCalculator.Verify(calc => calc.Add(It.IsAny<int>(), It.IsAny<int>()),
            //    Times.Exactly(5));
        }
    }
}

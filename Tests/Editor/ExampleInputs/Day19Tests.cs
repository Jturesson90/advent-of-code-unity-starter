using AdventOfCode.Days;
using NUnit.Framework;

namespace ExampleInputs
{
    public class Day19Tests
    {
        [TestCase("1234", "4321")]
        [TestCase("1234", "4321")]
        [TestCase("1234", "4321")]
        public void PuzzleA(string input, string expectedResult)
        {
            // Arrange
            var day = new Day19();

            // Act
            var result = day.PuzzleA(input);

            // Assert
            Assert.Equals(result, expectedResult);
        }

        [TestCase("1234", "4321")]
        [TestCase("1234", "4321")]
        [TestCase("1234", "4321")]
        public void PuzzleB(string input, string expectedResult)
        {
            // Arrange
            var day = new Day19();

            // Act
            var result = day.PuzzleB(input);

            // Assert
            Assert.Equals(result, expectedResult);
        }
    }
}
using NUnit.Framework;
using System.Text;
using System;
using System.Diagnostics;

namespace LowerPackTranformation.Tests
{
    [TestFixture]
    public class LowerPackTransformationTests
    {
        /*
         "h h" -> "hh"
         " h " -> " h "
         "H H" -> "hh"
         ""
         */
        [Test]
        public void WhenStringNullThrowArgumentNullException() {
            //Arrange
            TransformKata transformation = new TransformKata();
            string input = null;
            //Act
            //Assert
            Assert.That(()=> transformation.LowerPack(input),Throws.ArgumentNullException);
        }

        [Test]
        public void WhenStringEmptyReturnStringEmpty()
        {
            TransformKata transformation = new TransformKata();
            string input = "";
            Assert.That(transformation.LowerPack(input), Is.Empty);
        }

        [Test]
        public void WhenStringItsLowerHReturnsLowerH()
        {
            TransformKata transformation = new TransformKata();
            string input = "h";
            Assert.That(transformation.LowerPack(input), Is.EqualTo("h"));
        }
        [Test]
        public void WhenStringItsUpperHReturnLowerH()
        {
            TransformKata transformation = new TransformKata();
            string input = "H";
            Assert.That(transformation.LowerPack(input), Is.EqualTo("h"));
        }
        [Test]
        public void WhenStringItsSpaceReturnSpace()
        {
            TransformKata transformation = new TransformKata();
            string input = " ";
            Assert.That(transformation.LowerPack(input), Is.EqualTo(" "));
        }
        [Test]
        public void WhenStringItsSpaceAndHReturnSpaceAndH()
        {
            TransformKata transformation = new TransformKata();
            string input = " h";
            Assert.That(transformation.LowerPack(input), Is.EqualTo(" h"));
        }
        /*
  "H H" -> "hh"
  ""
  */
        [Test]
        public void WhenStringItsLowerHSpaceLowerH()
        {
            TransformKata transformation = new TransformKata();
            string input = "h h";
            Assert.That(transformation.LowerPack(input), Is.EqualTo("hh"));
        }
        [Test]
        public void WhenStringItsSpaceLowerHSpace()
        {
            TransformKata transformation = new TransformKata();
            string input = " h ";
            Assert.That(transformation.LowerPack(input), Is.EqualTo(" h "));
        }
        [Test]
        public void WhenStringItsUpperHSpaceUpperH()
        {
            TransformKata transformation = new TransformKata();
            string input = "H H";
            Assert.That(transformation.LowerPack(input), Is.EqualTo("hh"));
        }

        [Test]
        public static void ComplexityTestWhenAvgRuntimeIsLineal()
        {
            int maxLength = 20, cntOperations = 0;
            TransformKata transformation = new TransformKata();
            double lastResultTime = -1, resultsSum = 0, percentErrorRange = 0.2;
            int incrementNumber = 2;
            for (int i = 1; i <= maxLength; i++)
            {
                int length = (int)Math.Pow(incrementNumber, i);
                string input = StringGenerator(length);
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                transformation.LowerPack(input);
                stopwatch.Stop();

                double currentResult = stopwatch.Elapsed.TotalMilliseconds;
                if(lastResultTime != -1) {
                    resultsSum += (currentResult / lastResultTime);
                    cntOperations++;
                }
                lastResultTime = currentResult;
            }
            double actualResult = resultsSum / cntOperations++;
            if ((incrementNumber - (incrementNumber * percentErrorRange)) <= actualResult 
                && actualResult <= (incrementNumber + (incrementNumber * percentErrorRange)))
            {
                Assert.Pass($"The complexity of the algorithm is O(n) within " +
                            $"the acceptance range of {percentErrorRange}. The result is as expected");
            }
            else
            {
                Assert.Fail("The complexity of the algorithm is not O(n)");
            }
        }

        private static string StringGenerator(int length)
        {
            string pattern = "A ";
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(pattern[i % 2]);
            }
            return result.ToString();
        }

    }


}

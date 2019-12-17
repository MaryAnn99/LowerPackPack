using NUnit.Framework;

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

    }


}

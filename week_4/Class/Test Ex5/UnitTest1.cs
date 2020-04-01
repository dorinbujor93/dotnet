using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ex5;


namespace Test_Ex5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindsSmoothSentenceWithDot()
        {
            string smoothSentence = "Marta appreciated deep perpendicular right trapezoids.";
            var checker = new SmoothChecker();
            Assert.IsTrue(checker.IsSmooth(smoothSentence));
        }

        [TestMethod]
        public void FindsSmoothSentence()
        {
            string smoothSentence = "She eats super righteously";
            var checker = new SmoothChecker();
            Assert.IsTrue(checker.IsSmooth(smoothSentence));
        }  
        
        [TestMethod]
        public void FindsNotSmoothSentence()
        {
            string smoothSentence = "Someone is outside the doorway";
            var checker = new SmoothChecker();
            var isSmooth = checker.IsSmooth(smoothSentence);
            Assert.IsFalse(isSmooth);
        }

    }
}

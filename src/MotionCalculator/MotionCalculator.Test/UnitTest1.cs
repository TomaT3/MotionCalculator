using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotionCalculator;

namespace MotionCalculator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var calculationResult = MotionCalculatorHelper.GetTimeForDistance(distance: 10000, acceleration: 10, deceleration: 10, travelSpeed: 50);
        }
    }
}

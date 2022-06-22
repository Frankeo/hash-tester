using System;
using HashSuite.Code;
using Xunit;

namespace HashSuite.Tests
{
    public class ChiSquareDistributionTest
    {
        [Theory]
        [InlineData(0.21, 4, 0.995)]
        [InlineData(25, 15, 0.05)]
        [InlineData(30.19, 17, 0.025)]
        [InlineData(2.156, 10, 0.995)]
        [InlineData(8.260, 20, 0.99)]
        [InlineData(20.599, 30, 0.90)]
        [InlineData(53.672, 30, 0.005)]
        [InlineData(66.766, 40, 0.005)]
        [InlineData(79.49, 50, 0.005)]
        [InlineData(91.952, 60, 0.005)]
        [InlineData(28.412, 20, 0.10)]
        [InlineData(23.542, 16, 0.1)]
        [InlineData(7.962, 16, 0.95)]
        [InlineData(13.120, 25, 0.975)]
        public void CompareWithKnownValues(double chi, int degreeOfFreedom, double expectedP)
        {
            var distribution = new ChiSquareDistribution();
            var result = distribution.GetProbability(chi, degreeOfFreedom);
            Assert.Equal(expectedP, result, 3);
        }
    }
}

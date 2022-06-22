using System;
using System.Collections.Generic;
using HashSuite.Code;
using Xunit;

namespace HashSuite.Tests
{
  public class ChiSquareTest
    {
        [Fact]
        public void Few_Samples_For_K_Observations()
        {
            var observations = new List<int> { 2, 3, 4 };
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChiSquare(observations));
        }
        
        [Fact]
        public void Create_With_Minimum_Samples_For_K_Observations() 
        {
            var observations = new List<int> { 5, 5, 5 };
            var exceptions = Record.Exception(() => new ChiSquare(observations));
            Assert.Null(exceptions);
        }

        [Fact]
        public void Create_With_Different_Length_Observations_And_Frequencies()
        {
            var observations = new List<int> { 5, 5, 5 };
            var frequencies = new List<double> { 0.5, 0.333 };
            Assert.Throws<ArgumentException>(() => new ChiSquare(observations, frequencies));
        }

        [Fact]
        public void Create_With_Same_Length_Observations_And_Frequencies()
        {
            var observations = new List<int> { 5, 5, 5 };
            var frequencies = new List<double> { 0.5, 0.333, 0.167 };
            var exceptions = Record.Exception(() => new ChiSquare(observations));
            Assert.Null(exceptions);
        }

        [Fact]
        public void Compute_Probability_Known_Values() {
            var observations = new List<int> { 10, 3, 2 };
            var chi = new ChiSquare(observations);
            Assert.Equal(0.022, chi.GetProbability(), 3);
        }
    }
}
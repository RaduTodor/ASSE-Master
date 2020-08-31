// <copyright file="UtilityTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.Utility;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="UtilityTests" />.
    /// </summary>
    public class UtilityTests
    {
        /// <summary>
        /// The TakeLastValidTest.
        /// </summary>
        [Test]
        public void TakeLastValidTest()
        {
            var testList = new List<string>();
            testList.Add("A");
            testList.Add("B");
            testList.Add("C");
            var lastTwo = testList.TakeLast(2);
            Assert.IsTrue(lastTwo.ElementAt(0) == "B");
        }

        /// <summary>
        /// The TakeLastInvalidTest.
        /// </summary>
        [Test]
        public void TakeLastInvalidTest()
        {
            var testList = new List<string>();
            testList.Add("A");
            testList.Add("B");
            testList.Add("C");
            var lastTwo = testList.TakeLast(-1);
            Assert.IsTrue(lastTwo.Count() == 0);
        }

        /// <summary>
        /// The RandomGeneratorTest.
        /// </summary>
        [Test]
        public void RandomGeneratorTest()
        {
            var randString = RandomGenerators.RandomString(3);
            Assert.IsTrue(randString.Length == 3);
        }
    }
}

// <copyright file="RandomGenerators.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Utility
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="RandomGenerators" />.
    /// </summary>
    public static class RandomGenerators
    {
        /// <summary>
        /// Defines the random.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// The RandomString.
        /// </summary>
        /// <param name="length">The length<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string RandomString(int length)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(Chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

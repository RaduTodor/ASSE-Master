// <copyright file="Extensions.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="Extensions" />.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// The TakeLast.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="source">The source<see cref="IEnumerable{T}"/>.</param>
        /// <param name="number">The number<see cref="int"/>.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int number)
        {
            return source.Skip(Math.Max(0, source.Count() - number));
        }
    }
}

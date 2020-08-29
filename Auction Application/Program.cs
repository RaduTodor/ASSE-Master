// <copyright file="Program.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application
{
    using System;
    using System.Linq;
    using Auction_Application.DataMappers;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {
            using (var context = new ApplicationContext())
            {
                Console.WriteLine(context.Configurations.Count());
                Console.WriteLine(context.Roles.Count());
                Console.WriteLine(context.Auctions.Count());
                Console.ReadLine();
            }
        }
    }
}

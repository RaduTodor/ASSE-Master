// <copyright file="FinalModel.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers
{
    using Auction_Application.DomainModels;
    using System.Data.Entity;

    /// <summary>
    /// Defines the <see cref="FinalModel" />.
    /// </summary>
    public partial class ApplicationContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinalModel"/> class.
        /// </summary>
        public ApplicationContext()
            : base("FinalModel")
        {
        }

        /// <summary>
        /// Gets or sets the Auctions.
        /// </summary>
        public virtual DbSet<Auction> Auctions { get; set; }

        /// <summary>
        /// Gets or sets the Auction_Histories.
        /// </summary>
        public virtual DbSet<Auction_History> Auction_Histories { get; set; }

        /// <summary>
        /// Gets or sets the Categories.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the Configurations.
        /// </summary>
        public virtual DbSet<Configuration> Configurations { get; set; }

        /// <summary>
        /// Gets or sets the People.
        /// </summary>
        public virtual DbSet<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the Roles.
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the Score_Histories.
        /// </summary>
        public virtual DbSet<Score_History> Score_Histories { get; set; }

        /// <summary>
        /// Gets or sets the sysdiagrams.
        /// </summary>
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        /// <summary>
        /// The OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
                .Property(e => e.START_PRICE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Auction>()
                .HasMany(e => e.Auction_History)
                .WithRequired(e => e.Auction)
                .HasForeignKey(e => e.AUCTION_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Auction_History>()
                .Property(e => e.OFFER)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.Category2)
                .HasForeignKey(e => e.PARENT_CATEGORY_ID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.PARENT_CATEGORY_ID);

            modelBuilder.Entity<Person>()
                .Property(e => e.SCORE)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Auctions)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.OWNER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Auction_History)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.PERSON_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Score_History)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.PERSON_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Auctions)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.PRODUCT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.ROLE_ID)
                .WillCascadeOnDelete(false);
        }
    }
}

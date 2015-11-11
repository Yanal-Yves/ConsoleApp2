namespace ConsoleApp2
{
    using ConsoleApp2.Model;

    using Microsoft.Data.Entity;
    using Microsoft.Data.Entity.Infrastructure;

    /// <summary>
    /// An entity framework context.
    /// </summary>
    public class MyDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyDbContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public MyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the parents.
        /// </summary>
        public DbSet<Parent> Parents { get; set; }

        /// <summary>
        /// Gets or sets the child 1 s.
        /// </summary>
        public DbSet<ChildA> ChildAs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
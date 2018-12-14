using Microsoft.EntityFrameworkCore;

/// <summary>
/// DbContext is an important class in Entity Framework API. 
/// It is a bridge between your domain or entity classes and the database.
/// </summary>





namespace EntityFrameworkBasics
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// we use region to get better and clearer code
        /// </summary>
        #region Public Properties
        /// <summary>
        /// The DbSet class represents an entity set that can be used for 
        /// create, read, update, and delete operations.
        /// </summary>  
        //settings for the application , and it will be a table in a database
        public DbSet<SettingsDataModel> Settings { get; set; }


        #endregion

        public ApplicationDbContext()
        {

        }

       /// <summary>
       /// we now connecting our database with this program
       /// </summary>
       /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=entityframework;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

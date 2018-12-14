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


        


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //fluent API U CAN USE HERE 
        }

    }
}

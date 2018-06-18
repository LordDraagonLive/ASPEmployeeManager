using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystem
{
    /// <summary>
    /// AppDbContext Class which inherits
    /// DbContext Class
    /// This class allows us to make a session with the database
    /// </summary>
    public class AppDbContext:DbContext 
    {
        /// <summary>
        /// Instantiation of AppDbContext class 
        /// while calling the superclass (base class) of AppDbContext
        /// and setting DbContextoptions
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// LINQ data set of Employees
        /// </summary>
        public DbSet<Employee> Employees { get; set; }


    }
}
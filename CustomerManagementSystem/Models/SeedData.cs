using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Models
{
    /// <summary>
    /// This class is used to initialize a connection with
    /// the db and asp.net
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// This method will Inilialize the db with
        /// pre-entered values.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // creating a var off AppDbContext
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // look for any employees
                if (context.Employees.Any())
                {
                    return;   // DB has been seeded
                }

                // adding a range of employees to inilialize the database
                context.Employees.AddRange(
                    new Employee
                    {
                        Name = "Someone ",
                        Role = "Manager",
                        Gender = "F",
                        Address = "Somewhere"
                    },
                    new Employee
                    {
                        Name = "Another One ",
                        Role = "Accountant",
                        Gender = "M",
                        Address = "Somewhere"
                    }

                    );
                // all the context is sent to the db and saved
                context.SaveChanges();
            }


        }

    }
}

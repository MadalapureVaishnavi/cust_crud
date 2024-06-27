using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using cust_crrud.Data;
using System;
using System.Linq;

namespace cust_crrud.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new cust_crrudContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<cust_crrudContext>>()))
            {
                // Look for any movies.
                if (context.Cust.Any())
                {
                    return;   // DB has been seeded
                }
                context.Cust.AddRange(
                    new Cust
                    {
                        Name = "Vaishnavi",
                        Address = "Pune",
                        Email = "madlapurevaishnavi@gmail.com"
                 
                    },
                    new Cust
                    {
                        Name = "Shweta",
                        Address = "Nanded",
                        Email = "madlapureshweta@gmail.com"

                    }
                );
                context.SaveChanges();
            }
        }
    }
}

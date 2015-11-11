namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;

    using ConsoleApp2.Model;

    using Microsoft.Data.Entity;
    using Microsoft.Framework.Configuration;

    /// <summary>
    /// The program class holding the entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The application entry point (main).
        /// </summary>
        public void Main()
        {
            // Get the connection string from config.json file
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("config.json");
            var configuration = configurationBuilder.Build();
            var connectionString = configuration["Data:DefaultConnection:ConnectionString"];

            // Create an instance of a SQL Server DBContext
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(connectionString);
            var context = new MyDbContext(options.Options);

            // Create a graph entity
            var parent = new Parent
            {
                Data = "Yanal",
                ChildBs = new List<ChildB> { new ChildB { Data = "1234" } },
                ChildA = new ChildA { Data = "1234" }
            };
            
            // Add the graph entity to context
            context.Parents.Add(parent, GraphBehavior.IncludeDependents);

            // Save change to the storage
            // Bug: ChildA is not going to be saved on the database on EF7 only ChildBs is going to be saved in the database.
            // On EF6 both ChildA and ChildB gets stored in database when calling context.SaveChanges().
            context.SaveChanges();
        }
    }
}

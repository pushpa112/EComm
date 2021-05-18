using ECommEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommDatabase
{
   public class ECContext : DbContext
    {
        // generate database inside this connection string
        public ECContext() : base("ECommConnection") 
        {

        }

        //Entities to generate in database(Migration)
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
/********************STEP1: *********************************
 * Go to Tools > NuGet Packet Manager > Packet Manager Console
 * enable-migrations: this code will generate Configuration file
 * add-migration initialized: This code will generate migration file(where tables, entities, keys etc are defined)
 * update-database: This code will add up the database inside Sql Server
 * Now, check the Server Explorer/ SQL Server Object Explorer to see if the database gets created there
 */

/********************************STEP2:***********************************
 * Inside SQL Server Object Explorer window, ECommConnection will show up. EComm-Database should show up there.
 * EcommWeb was setup as the startup project. That's the reason EcommConnection showed up there.
 * Now, goto Packet Manager Console, write:
 * enable-migrations
 * enable-migrations -verbose
 * Now, change the start-up project to ECommDatabase and then write
 * enable-migrations -verbose -force
 * update-database -verbose
 * Now, EComm-Database will appear inside the SQL Server Object Explorer Window
 */
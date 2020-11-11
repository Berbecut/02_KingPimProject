using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.DB
{
    public class KingPimDatabaseContext : IdentityDbContext<IdentityUser>
    {
        //create constructor of class KingPimFloDatabaseContext with parameter options inherited 
        //from base class of EntityFramework: DbContextOptions<KingPimDatabaseContext>
        public KingPimDatabaseContext(DbContextOptions<KingPimDatabaseContext> options)
             : base(options)
        {
        }

        //inherit/override void method "OnModelCreating" 
        //from base class of EntityFramework: DbContextOptions<KingPimDatabaseContext>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<KingPimV1.Models.Product> Products { get; set; }
        public DbSet<KingPimV1.Models.Category> Categories { get; set; }
        public DbSet<KingPimV1.Models.Subcategory> Subcategories { get; set; }
    }
}

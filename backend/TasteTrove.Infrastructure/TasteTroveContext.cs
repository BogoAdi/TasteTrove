using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Domain;

namespace TasteTrove.Infrastructure
{
    public class TasteTroveContext : DbContext
    {
        public TasteTroveContext(DbContextOptions<TasteTroveContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

        }
    }
}

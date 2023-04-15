using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Prueba_Técnica.Model
{
    public partial class DbDataModel : DbContext
    {
        public DbDataModel()
            : base("name=DbDataModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}

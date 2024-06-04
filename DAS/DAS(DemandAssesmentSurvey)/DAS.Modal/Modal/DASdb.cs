using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAS.Modal.Modal
{
    public partial class DASdb : DbContext
    {
        public DASdb()
            : base("name=DASdb")
        {
        }

        public virtual DbSet<CompanyDtl> CompanyDtls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

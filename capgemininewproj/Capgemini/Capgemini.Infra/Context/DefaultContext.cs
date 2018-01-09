using Capgemini.DTO;
using Capgemini.Infra.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Infra.Context
{
    public class DefaultContext : DbContext
    {
        static DefaultContext()
        {
            Database.SetInitializer<DefaultContext>(null);
        }

        public DefaultContext()
            : base("Name=CapgeminiContext")
        {
        }

        public DbSet<CadastroDTO> Cadastroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CadastroMap());
        }
    }
}

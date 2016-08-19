using Curaja.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Curaja.DAO
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("name=DbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pessoa> Pessoas { set; get; }

        public DbSet<Usuario> Usuarios { set; get; }

        public DbSet<Categoria> Categorias { set; get; }

        public DbSet<Movimento> Movimentos { set; get; }

        public DbSet<Sequencia> Sequencias { set; get; }

        public DbSet<MovimentoSequencia> MovimentosSequencia { set; get; }

        public DbSet<Tratamento> Tratamentos { set; get; }

        public DbSet<EnumJoint> EnumJoint { set; get; }

        public DbSet<Sessao> Sessoes { set; get; }

        public DbSet<EsqueletoResultadoSessao> EsqueletoResultadosSessao { set; get; }

        public DbSet<EstadoEsqueleto> EstadosEsqueleto { set; get; }

        public DbSet<Joint> Joint { set; get; }
    }
}
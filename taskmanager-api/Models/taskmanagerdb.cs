namespace taskmanager_api.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class taskmanagerdb : DbContext
    {
        public taskmanagerdb()
            : base("name=taskmanagerdb")
        {
        }

        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<tarefas> tarefas { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<status>()
                .Property(e => e.status1)
                .IsUnicode(false);

            modelBuilder.Entity<status>()
                .Property(e => e.desc_status)
                .IsUnicode(false);

            modelBuilder.Entity<tarefas>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<tarefas>()
                .Property(e => e.categoria)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.foto)
                .IsUnicode(false);
        }
    }
}

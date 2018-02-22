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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.categoria1)
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
        }
    }
}

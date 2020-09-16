namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Dbmodel : DbContext
    {
        public Dbmodel()
            : base("name=Dbmodel")
        {
        }

        public virtual DbSet<core__Menus> core__Menus { get; set; }
        public virtual DbSet<Dashboard__Chart> Dashboard__Chart { get; set; }
        public virtual DbSet<Dashboard__Chart____88____core__Menus> Dashboard__Chart____88____core__Menus { get; set; }
        public virtual DbSet<Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property> Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property { get; set; }
        public virtual DbSet<Dashboard__Chart__Property> Dashboard__Chart__Property { get; set; }
        public virtual DbSet<Dashboard__Month> Dashboard__Month { get; set; }
        public virtual DbSet<Shop__Client> Shop__Client { get; set; }
        public virtual DbSet<Shop__Commande> Shop__Commande { get; set; }
        public virtual DbSet<Shop__Product> Shop__Product { get; set; }
        public virtual DbSet<Shop__Tarif> Shop__Tarif { get; set; }
        public virtual DbSet<Shop__Tarif____88____Shop__Product____88____Shop__Commande> Shop__Tarif____88____Shop__Product____88____Shop__Commande { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<core__Menus>()
                .HasMany(e => e.Dashboard__Chart____88____core__Menus)
                .WithOptional(e => e.core__Menus)
                .HasForeignKey(e => e.ID____core__Menus);

            modelBuilder.Entity<Dashboard__Chart>()
                .HasMany(e => e.Dashboard__Chart____88____core__Menus)
                .WithOptional(e => e.Dashboard__Chart)
                .HasForeignKey(e => e.ID____Dashboard__Chart);

            modelBuilder.Entity<Dashboard__Chart>()
                .HasMany(e => e.Dashboard__Chart__Property)
                .WithOptional(e => e.Dashboard__Chart)
                .HasForeignKey(e => e.ID____Dashboard__Chart);

            modelBuilder.Entity<Dashboard__Chart____88____core__Menus>()
                .HasMany(e => e.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property)
                .WithOptional(e => e.Dashboard__Chart____88____core__Menus)
                .HasForeignKey(e => e.ID____Dashboard__Chart____88____core__Menus);

            modelBuilder.Entity<Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property>()
                .Property(e => e.Value)
                .IsFixedLength();

            modelBuilder.Entity<Dashboard__Chart__Property>()
                .HasMany(e => e.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property)
                .WithOptional(e => e.Dashboard__Chart__Property)
                .HasForeignKey(e => e.ID____Dashboard__Chart__Property);

            modelBuilder.Entity<Shop__Client>()
                .HasMany(e => e.Shop__Commande)
                .WithOptional(e => e.Shop__Client)
                .HasForeignKey(e => e.ID____Shop__Client);

            modelBuilder.Entity<Shop__Commande>()
                .HasMany(e => e.Shop__Tarif____88____Shop__Product____88____Shop__Commande)
                .WithOptional(e => e.Shop__Commande)
                .HasForeignKey(e => e.ID____Shop__Commande);

            modelBuilder.Entity<Shop__Product>()
                .Property(e => e.Poids)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Shop__Product>()
                .HasMany(e => e.Shop__Tarif____88____Shop__Product____88____Shop__Commande)
                .WithOptional(e => e.Shop__Product)
                .HasForeignKey(e => e.ID____Shop__Product);

            modelBuilder.Entity<Shop__Tarif>()
                .HasMany(e => e.Shop__Tarif____88____Shop__Product____88____Shop__Commande)
                .WithOptional(e => e.Shop__Tarif)
                .HasForeignKey(e => e.ID____Shop__Tarif);

            modelBuilder.Entity<Shop__Tarif____88____Shop__Product____88____Shop__Commande>()
                .Property(e => e.Quantite)
                .IsFixedLength();
        }
    }
}

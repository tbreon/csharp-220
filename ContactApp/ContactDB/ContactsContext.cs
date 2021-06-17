using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactDB
{
    public partial class ContactsContext : DbContext
    {
        public ContactsContext()
        {
        }

        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Contacts;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.PokemonId);

                entity.Property(e => e.PokemonCardCondition).HasMaxLength(50);

                entity.Property(e => e.PokemonCharacter)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PokemonCreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PokemonDateSold).HasColumnType("date");

                entity.Property(e => e.PokemonFinish).HasMaxLength(50);

                entity.Property(e => e.PokemonSet).HasMaxLength(50);

                entity.Property(e => e.PokemonSoldPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PokemonURL)
                    .HasColumnName("PokemonURL")
                    .HasMaxLength(1000);
            });
        }
    }
}

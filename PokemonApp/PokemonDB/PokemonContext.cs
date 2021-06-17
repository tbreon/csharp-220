using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PokemonDB
{
    public partial class PokemonContext : DbContext
    {
        public PokemonContext()
        {
        }

        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pokemon> Pokemon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Pokemon;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
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

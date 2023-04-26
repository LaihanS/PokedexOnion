
using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Contexts
{
    public class AppliContext : DbContext
    {
        public AppliContext(DbContextOptions<AppliContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemones { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Nombres(tablas)
            modelBuilder.Entity<Pokemon>().ToTable("Pokemones");
            modelBuilder.Entity<Region>().ToTable("Regiones");
            modelBuilder.Entity<Tipo>().ToTable("Tipos");
            #endregion

            #region "Primary Keys"
            modelBuilder.Entity<Pokemon>().HasKey(pokemon => pokemon.idpoke);
            modelBuilder.Entity<Region>().HasKey(Pokeregion => Pokeregion.idregion);
            modelBuilder.Entity<Tipo>().HasKey(Poketipo => Poketipo.idtipo);
            #endregion

            #region Relaciones
            modelBuilder.Entity<Region>().HasMany<Pokemon>(region => region.Pokemons).
             WithOne(pokemon => pokemon.Region).
             HasForeignKey(pokemon => pokemon.idRegion).
             OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tipo>()
              .HasMany<Pokemon>(tipo => tipo.Pokemons).
             WithOne(pokemon => pokemon.Tipo).
             HasForeignKey(pokemon => pokemon.idtipo).
             OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region config

            #region pokemon
            modelBuilder.Entity<Pokemon>().Property(pokem => pokem.name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Pokemon>().Property(pokem => pokem.idtipo).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(pokem => pokem.idRegion).IsRequired();


            #endregion

            #region Tipo
            modelBuilder.Entity<Tipo>().Property(poketipo => poketipo.tipoName).IsRequired().HasMaxLength(150);
            #endregion

            #region Regionpoke
            modelBuilder.Entity<Region>().Property(regiontipo => regiontipo.regionName).IsRequired().HasMaxLength(150);
            #endregion

            #endregion
        }
    }
}

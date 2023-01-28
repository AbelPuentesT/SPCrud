using System;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class PruebaSpnetContext : DbContext
{
    public PruebaSpnetContext()
    {
    }

    public PruebaSpnetContext(DbContextOptions<PruebaSpnetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pelicula__3214EC07CB1A2990");
            entity.ToTable("Pelicula");

            

            entity.Property(e => e.Genero).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

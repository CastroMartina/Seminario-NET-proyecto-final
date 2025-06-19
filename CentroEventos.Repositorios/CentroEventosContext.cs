using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentroEventos.Repositorios;

public class CentroEventosContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Reserva>()
        .Property(a => a.EstadoAsistencia)
        .HasConversion<string>();
    }
}


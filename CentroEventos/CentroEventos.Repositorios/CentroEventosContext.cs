using System;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroEventosContext : DbContext
{
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }
}

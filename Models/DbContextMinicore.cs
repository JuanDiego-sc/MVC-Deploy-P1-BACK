using Microsoft.EntityFrameworkCore;
using MiniCoreEnriqueMerizalde.Models;

public class DbContextMinicore : DbContext
{
    public DbContextMinicore(DbContextOptions<DbContextMinicore> options) : base(options) { }

    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Proyecto> Proyectos { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Empleado>()
            .HasKey(e => e.Id_Empleado);

        modelBuilder.Entity<Proyecto>()
            .HasKey(p => p.Id_Proyecto);

        modelBuilder.Entity<Tarea>()
            .HasKey(t => t.Id_Tarea);

        modelBuilder.Entity<Tarea>()
            .HasOne(t => t.Empleado)
            .WithMany()
            .HasForeignKey(t => t.Id_EmpleadoV);

        modelBuilder.Entity<Tarea>()
            .HasOne(t => t.Proyecto)
            .WithMany()
            .HasForeignKey(t => t.Id_ProyectoV);
    }
}



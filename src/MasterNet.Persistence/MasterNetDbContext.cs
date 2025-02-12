using Bogus;
using MasterNet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MasterNet.Persistence;

public class MasterNetDbContext : DbContext
{

    public MasterNetDbContext(DbContextOptions<MasterNetDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Curso>().ToTable("cursos");
        modelBuilder.Entity<Instructor>().ToTable("instructores");
        modelBuilder.Entity<CursoInstructor>().ToTable("curso_instructores");
        modelBuilder.Entity<Precio>().ToTable("precios");
        modelBuilder.Entity<CursoPrecio>().ToTable("cursos_precios");
        modelBuilder.Entity<Calificacion>().ToTable("calificaciones");
        modelBuilder.Entity<Photo>().ToTable("imagenes");

        modelBuilder.Entity<Precio>()
        .Property(p => p.PrecioActual)
        .HasPrecision(10,2);

        modelBuilder.Entity<Precio>()
        .Property(p => p.PrecioPromocion)
        .HasPrecision(10,2);

        modelBuilder.Entity<Precio>()
        .Property(p => p.Nombre)
        .HasColumnType("VARCHAR")
        .HasMaxLength(250);

        modelBuilder.Entity<Curso>()
        .HasMany(c => c.Photos)
        .WithOne(c => c.Curso)
        .HasForeignKey(c => c.CursoId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Curso>()
        .HasMany(c => c.Calificaciones)
        .WithOne(c => c.Curso)
        .HasForeignKey(c => c.CursoId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Curso>()
        .HasMany(c => c.Precios)
        .WithMany(c => c.Cursos)
        .UsingEntity<CursoPrecio>(
            j => j
                .HasOne(p => p.Precio)
                .WithMany(p => p.CursoPrecios)
                .HasForeignKey(p => p.PrecioId),
            j => j
                .HasOne(p => p.Curso)
                .WithMany(p => p.CursoPrecios)
                .HasForeignKey(p => p.CursoId),

            j => 
            {
                j.HasKey(t => new {t.PrecioId, t.CursoId});
            }
        );

        modelBuilder.Entity<Curso>()
        .HasMany(c => c.Instructores)
        .WithMany(c => c.Curso)
        .UsingEntity<CursoInstructor>(
            j => j
                .HasOne(p => p.Instructor)
                .WithMany(p => p.CursoInstructores)
                .HasForeignKey(p => p.InstructorId),
            j => j
                .HasOne(p => p.Curso)
                .WithMany(p => p.CursoInstructores)
                .HasForeignKey(p => p.CursoId),

            j => 
            {
                j.HasKey(t => new {t.InstructorId, t.CursoId});
            }
        );

        modelBuilder.Entity<Curso>().HasData(DataMaster().Item1);
        modelBuilder.Entity<Precio>().HasData(DataMaster().Item2);
        modelBuilder.Entity<Instructor>().HasData(DataMaster().Item3);
    }


    public Tuple<Curso[], Precio[], Instructor[]> DataMaster()
    {
        var cursos = new List<Curso>();
        var faker = new Faker();

        for(var i=1; i<10; i++)
        {
            var cursoId = Guid.NewGuid();
            cursos.Add(
                new Curso
                {
                    Id = cursoId,
                    Descripcion = faker.Commerce.ProductDescription(),
                    Titulo = faker.Commerce.ProductName(),
                    FechaPublicacion = DateTime.UtcNow
                }
            );
        }

        var precioId = Guid.NewGuid();
        var precio = new Precio
        {
            Id = precioId,
            PrecioActual = 10.0m,
            PrecioPromocion = 8.0m,
            Nombre = "Precio Regular"
        };
        var precios = new List<Precio>
        {
            precio
        };

        var fakerInstructor = new Faker<Instructor>()
            .RuleFor(t => t.Id, _ => Guid.NewGuid())
            .RuleFor(t => t.Nombre, f => f.Name.FirstName())
            .RuleFor(t => t.Apellido, f => f.Name.LastName())  
            .RuleFor(t => t.Grado, f => f.Name.JobTitle());

        var instructores = fakerInstructor.Generate(10);


        return Tuple.Create(cursos.ToArray(), precios.ToArray(), instructores.ToArray());
    }

    public DbSet<Curso>? Curso { get; set; }
    public DbSet<Calificacion>? Calificacion { get; set; }
    public DbSet<Instructor>? Instructor { get; set; }
    public DbSet<Precio>? Precio { get; set; }

}



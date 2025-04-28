using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndradeEduardoExamenProgreso1.Models
{

public class AppBaseDatosContextSQLServer : DbContext
{
    public AppBaseDatosContextSQLServer(DbContextOptions<AppBaseDatosContextSQLServer> options)
        : base(options)
    {
    }

    public DbSet<demoBaseDatos.Models.Estudiante> Estudiante { get; set; } = default!; //Ejemplo de como hacer las tablas


}
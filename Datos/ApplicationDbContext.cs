using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventarioMVCPOO.Models;

namespace InventarioMVCPOO.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}

        //Usar los modelos
        public DbSet<Articulo> Articulo {get; set;}
    }
}
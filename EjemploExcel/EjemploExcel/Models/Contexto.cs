using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EjemploExcel.Models
{
    public class Contexto: DbContext
    {
        public Contexto(): base("PruebaExcel") { }
        public DbSet<Departamentos> Departamento { get; set; }
        public DbSet<Empleado> Empleado { get; set; }

    }
}
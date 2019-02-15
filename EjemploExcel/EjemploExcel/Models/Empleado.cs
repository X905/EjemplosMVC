using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploExcel.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }

        public int IdDepartamento { get; set; }
        public virtual Departamentos deptos { get; set; }


    }
}
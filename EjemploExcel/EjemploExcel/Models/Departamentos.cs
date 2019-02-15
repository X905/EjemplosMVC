using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploExcel.Models
{
    public class Departamentos
    {
        [Key]
        public int IdDepartamento { get; set; }
        public string DepartamentoNombre { get; set; }

        public virtual List<Empleado> r { get; set; }
    }
}
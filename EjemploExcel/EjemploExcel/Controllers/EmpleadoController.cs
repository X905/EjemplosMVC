using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using EjemploExcel.Models;

namespace EjemploExcel.Controllers
{
    public class EmpleadoController : Controller
    {
        Contexto db = new Contexto();
        public IList<EmpleadoVM> GetEmpleadosList()
        {
            
            var EmpleadoLista = (from e in db.Empleado
                                 join d in db.Departamento on e.IdDepartamento equals d.IdDepartamento
                                 select new EmpleadoVM
                                 {
                                     Nombre = e.Nombre,
                                     Apellido = e.Apellido,
                                     Correo = e.Correo,
                                     Telefono = (int)e.Telefono,
                                     Direccion = e.Direccion,
                                     Departamento = d.DepartamentoNombre
                                 }).ToList();
            return EmpleadoLista;
        }

        // GET: Empleado
        public ActionResult Index()
        {
            return View(this.GetEmpleadosList());
        }
        public ActionResult ExportarExcel()
        {
            var gv = new GridView();
            gv.DataSource = this.GetEmpleadosList();
            gv.DataBind();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
        public ActionResult Crear()
        {
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "DepartamentoNombre");
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

    }
}
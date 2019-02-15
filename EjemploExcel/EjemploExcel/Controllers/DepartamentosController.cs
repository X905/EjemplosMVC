using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploExcel.Models;

namespace EjemploExcel.Controllers
{
    public class DepartamentosController : Controller
    {
        Contexto db = new Contexto();
        // GET: Departamentos
        public ActionResult Index()
        {
            
            return View(db.Departamento.ToList());
        }
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Departamento.Add(departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamentos);
        }
    }
}
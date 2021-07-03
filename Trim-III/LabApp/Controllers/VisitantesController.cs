using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabApp.Models;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace LabApp.Controllers
{
    public class VisitantesController : Controller
    {
        public IActionResult Index(int? page)
        {
            var base_datos = new lab_mundoContext();
            var paginaNumero = page ?? 1;
            int paginaTamaño = 5;
            var visitante = base_datos.Visitantes.ToPagedList(paginaNumero, paginaTamaño);
            return View(visitante);
        }

        [Authorize(Roles = "administrador")]
        public IActionResult Crear()
        {
            var base_datos = new lab_mundoContext();

            var listaRoles = base_datos.Roles.ToList();
            ViewBag.Roles = listaRoles;
            return View();
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Crear(Visitante visitante)
        {
            var base_datos = new lab_mundoContext();

            var existe = base_datos.Visitantes.Find(visitante.Codigo);

            if (existe == null)
            {
                base_datos.Add(visitante);
                base_datos.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["msj"] = $"El código {visitante.Codigo} ya existe.";
                return View();
            }
        }


        [Authorize(Roles = "administrador, cientifico")]
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var base_datos = new lab_mundoContext();
            var visitante = base_datos.Visitantes.Find(id);
            return View(visitante);
        }


        [Authorize(Roles = "administrador, cientifico")]
        [HttpPost]
        public IActionResult Editar(Visitante obj_visitante)
        {
            var base_datos = new lab_mundoContext();
            var visitante = base_datos.Visitantes.Find(obj_visitante.Codigo);
            visitante.Nombre = obj_visitante.Nombre;
            visitante.Correo = obj_visitante.Correo;
            base_datos.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult Borrar(int id)
        {
            var base_datos = new lab_mundoContext();
            var visitante = base_datos.Visitantes.Find(id);
            return View(visitante);
        }

        [Authorize(Roles = "administrador")]
        [HttpPost, ActionName("Borrar")]
        public IActionResult ConfirmarBorrar(int id)
        {
            var base_datos = new lab_mundoContext();
            var visitante = base_datos.Visitantes.Find(id);
            base_datos.Remove(visitante);
            base_datos.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalles(int id)
        {
            var base_datos = new lab_mundoContext();
            var visitante = base_datos.Visitantes.Find(id);
            return View(visitante);
        }
    }
}

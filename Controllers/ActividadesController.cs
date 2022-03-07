using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaFinal.Data;
using PruebaFinal.Models;

namespace PruebaFinal.Controllers
{
    [Authorize(Roles = "Agente")]
    public class ActividadesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ActividadesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var actividades = _context.Actividades.Include(a => a.IdTipoNavigation).ToList();
            ViewBag.Actividades = actividades;
            return View();
        }
        public IActionResult Create()
        {
            var tipos = _context.Tipos.ToList();
            ViewBag.tipos = new SelectList(tipos, "Id", "Tipo");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Actividades actividades)
        {
            try
            {
                _context.Add(actividades);
                _context.SaveChanges();
                TempData["MessageSuccess"] = "La actividad se ha registrado correctamente";
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["MessageError"] = "Error al crear el registro";
                return View(actividades);
            }
        }
        [Route("Actividades/Edit/{Id}")]
        public IActionResult Edit(long Id)
        {

            var actividades = _context.Actividades.Find(Id);
            var tipos = _context.Tipos.ToList();
            ViewBag.Tipos = new SelectList(tipos, "Id", "Tipo");
            return View(actividades);

        }

        [HttpPost]
        [Route("Actividades/Edit/{Id}")]
        public IActionResult Edit(Actividades actividades)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(actividades);
                    _context.SaveChanges();
                    TempData["MessageSuccess"] = "La actividad se ha Modificado correctamente";
                    return RedirectToAction("Index");
                }

                return View(actividades);
            }
            catch (System.Exception)
            {
                TempData["MessageError"] = "La actividad no se ha registrado correctamente";

                return View(actividades);
            }

        }
        public IActionResult Delete(long Id)
        {
            return Delete(Id);
        }

        [Route("Actividades/Delete/{Id}")]

        public IActionResult Delete(long Id, string v)
        {

            try
            {
                var ti = _context.Actividades.Find(Id);
                _context.Actividades.Remove(ti);
                _context.SaveChanges();
                TempData["MessageSuccess"] = "La actividad se ha eliminado correctamente";

                return RedirectToAction("Index");

            }
            catch (System.Exception)
            {
                TempData["MessageError"] = "Error al eliminar la actividad";
                return RedirectToAction("Index");

            }

        }

    }
}
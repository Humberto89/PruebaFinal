using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaFinal.Data;
using PruebaFinal.Models;

namespace PruebaFinal.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class TiposController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TiposController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Tipos = _context.Tipos.ToList();
            ViewBag.Tipos = Tipos;
            return View();
        }
    }
}
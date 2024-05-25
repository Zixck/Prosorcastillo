using app_ventas_ds502.Data;
using app_ventas_ds502.Models;
using Microsoft.AspNetCore.Mvc;

namespace app_ventas_ds502.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Producto> ListarProducto = _context.Producto;

            return View(ListarProducto);
        }
    }
}

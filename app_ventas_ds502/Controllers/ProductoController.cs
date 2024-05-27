using app_ventas_ds502.Data;
using app_ventas_ds502.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

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
            return View();
        }

        [HttpGet]
        public JsonResult Listar()
        {
            string cad_sql = "EXEC sp_ListarProducto";
            List<Producto> arr_producto = _context.Productos.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_producto });
        }

        [HttpGet]
        public JsonResult Consultar(string codigo_producto)
        {
            string cad_sql = "EXEC sp_ConsultarProducto @codigo_producto";
            Producto producto = _context.Productos.FromSqlRaw(cad_sql, new SqlParameter("@codigo_producto", codigo_producto)).FirstOrDefault();
            return Json(producto);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Producto producto)
        {
            bool rpta = true;

            try
            {
                Producto tmp_producto = _context.Productos.FirstOrDefault(p => p.codigo_producto == producto.codigo_producto);
                if (tmp_producto == null)
                {
                    _context.Productos.Add(producto);
                }
                else
                {
                    tmp_producto.producto = producto.producto;
                    tmp_producto.talla = producto.talla;
                    tmp_producto.stock_disponible = producto.stock_disponible;
                    tmp_producto.costo = producto.costo;
                    tmp_producto.ganancia = producto.ganancia;
                    tmp_producto.codigo_categoria = producto.codigo_categoria;
                    _context.Productos.Update(tmp_producto);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }

        [HttpGet]
        public JsonResult Borrar(string codigo_producto)
        {
            bool rpta = true;
            try
            {
                Producto producto = _context.Productos.FirstOrDefault(p => p.codigo_producto == codigo_producto);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                }
                else
                {
                    rpta = false;
                }
            }
            catch (Exception)
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }
    }
}

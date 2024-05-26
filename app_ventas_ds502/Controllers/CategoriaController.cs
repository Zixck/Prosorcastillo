using app_ventas_ds502.Data;
using app_ventas_ds502.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace app_ventas_ds502.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
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
            string cad_sql = "SELECT * FROM ar_categoria";
            List<Categoria> arr_categoria = _context.Categorias.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_categoria });
        }

        [HttpGet]
        public JsonResult Consultar(string codigo_categoria)
        {
            string cad_sql = "SELECT * FROM ar_categoria WHERE codigo_categoria = @codigo_categoria";
            Categoria categoria = _context.Categorias.FromSqlRaw(cad_sql, new SqlParameter("@codigo_categoria", codigo_categoria)).FirstOrDefault();
            return Json(categoria);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Categoria categoria)
        {
            bool rpta = true;

            try
            {
                Categoria tmp_categoria = _context.Categorias.FirstOrDefault(cat => cat.codigo_categoria == categoria.codigo_categoria);
                if (tmp_categoria == null)
                {
                    _context.Categorias.Add(categoria);
                }
                else
                {
                    tmp_categoria.categoria = categoria.categoria;
                    _context.Categorias.Update(tmp_categoria);
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
        public JsonResult Borrar(string codigo_categoria)
        {
            bool rpta = true;
            try
            {
                Categoria categoria = _context.Categorias.FirstOrDefault(cat => cat.codigo_categoria == codigo_categoria);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
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

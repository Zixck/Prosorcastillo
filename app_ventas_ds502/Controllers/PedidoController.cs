using app_ventas_ds502.Data;
using app_ventas_ds502.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace app_ventas_ds502.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context)
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
            string cad_sql = "exec sp_ListarPedidos";
            List<Pedido> arr_pedido = _context.Pedidos.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_pedido });
        }

        [HttpGet]
        public JsonResult Consultar(string codigo_pedido)
        {
            string cad_sql = "exec sp_ConsultarPedido @codigo_pedido";
            Pedido pedido = _context.Pedidos.FromSqlRaw(cad_sql, new SqlParameter("@codigo_pedido", codigo_pedido)).FirstOrDefault();
            return Json(pedido);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Pedido pedido)
        {
            bool rpta = true;

            try
            {
                Pedido tmp_pedido = _context.Pedidos.FirstOrDefault(p => p.codigo_pedido == pedido.codigo_pedido);
                if (tmp_pedido == null)
                {
                    _context.Pedidos.Add(pedido);
                }
                else
                {
                    tmp_pedido.fecha = pedido.fecha;
                    tmp_pedido.codigo_cliente = pedido.codigo_cliente;
                    _context.Pedidos.Update(tmp_pedido);
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
        public JsonResult Borrar(string codigo_pedido)
        {
            bool rpta = true;
            try
            {
                Pedido pedido = _context.Pedidos.FirstOrDefault(p => p.codigo_pedido == codigo_pedido);
                if (pedido != null)
                {
                    _context.Pedidos.Remove(pedido);
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

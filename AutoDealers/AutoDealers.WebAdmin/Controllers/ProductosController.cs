using AutoDealers.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoDealers.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {

        ProductosBL _productosBL;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
        }

        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productosBL.ObtenerProductos();

            return View(listadeProductos);
        }

      
        public ActionResult Crear ()
        {
            var nuevoProducto = new Producto();

            return View(nuevoProducto);
        }

        [HttpPost] //El usuario nos envia de regreso
        public ActionResult Crear(Producto producto)
        {
            _productosBL.GuardarProducto(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {

            var producto = _productosBL.ObtenerProductos(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar (Producto producto)
        {
            _productosBL.GuardarProducto(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle (int id)
        {
            var producto = _productosBL.ObtenerProductos(id);
            return View(producto);
        }

        public ActionResult Eliminar (int id)
        {
            var producto = _productosBL.ObtenerProductos(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar (Producto producto)
        {
            _productosBL.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }

}
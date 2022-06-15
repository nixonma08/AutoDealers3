using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealers.BL
{
    public class ProductosBL
    {

        Contexto _contexto;
        public List<Producto> listadeProductos { get; set; }

        public ProductosBL()
        {
           _contexto = new Contexto();
            listadeProductos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos()
        {

            listadeProductos = _contexto.Productos.ToList();
            return listadeProductos;
        }

        public void GuardarProducto(Producto producto)
        {
            if (producto.Id == 0)
            {
                _contexto.Productos.Add(producto);
            }
            else
            {
                var productoExistente = _contexto.Productos.Find(producto.Id);
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Modelo = producto.Modelo;
                productoExistente.Color = producto.Color;
                productoExistente.Precio = producto.Precio;
                productoExistente.Existencia = producto.Existencia;


            } 
            
            _contexto.SaveChanges();

        }

        public Producto ObtenerProductos (int id)
        {

            var producto = _contexto.Productos.Find(id);
            return producto;
        }

        public void EliminarProducto (int id)
        {
            var producto = _contexto.Productos.Find(id);

            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();
        }
    }
}

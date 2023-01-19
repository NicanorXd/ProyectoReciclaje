using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Producto.Infraestructura.DBRepository;
using Producto.Infraestructura.DBSettings;
using dominio = Producto.Dominio.Entidades;

namespace Producto.Aplicacion.Producto.Read
{
    public class ProductoQueryAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Producto> _producto;

        public ProductoQueryAll()
        {
            _producto = _repository.db.GetCollection<dominio.Producto>("productos");
        }

        public IEnumerable<dominio.Producto> ListarProductos()
        {
            return _producto.Find(x => true).ToList();
        }
    }
}

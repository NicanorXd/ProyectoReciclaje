using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Producto.Infraestructura.DBSettings;
using dominio = Producto.Dominio.Entidades;

namespace Producto.Dominio.Servicios
{
    public class ProductoService
    {
        private IMongoCollection<dominio.Producto> _producto;

        public ProductoService(IDBSettings dBSettings)
        {
            var cliente = new MongoClient(dBSettings.Server);
            var database = cliente.GetDatabase(dBSettings.Database);
            _producto = database.GetCollection<dominio.Producto>(dBSettings.Collection);
        }

        public List<dominio.Producto> ListarProductos()
        {
            return _producto.Find(x => true).ToList();
        }
    }
}

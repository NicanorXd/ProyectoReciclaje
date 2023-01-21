using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reciclaje.Infraestructura.DBSettings;
using dominio = Reciclaje.Dominio.Entidades;

namespace Reciclaje.Dominio.Servicios
{
    public class ReciclajeService
    {
        private IMongoCollection<dominio.Reciclaje> _reciclaje;

        public ReciclajeService(IDBSettings dBSettings)
        {
            var cliente = new MongoClient(dBSettings.Server);
            var database = cliente.GetDatabase(dBSettings.Database);
            _reciclaje = database.GetCollection<dominio.Reciclaje>(dBSettings.Collection);
        }

        public List<dominio.Reciclaje> ListarProductos()
        {
            return _reciclaje.Find(x => true).ToList();
        }
    }
}

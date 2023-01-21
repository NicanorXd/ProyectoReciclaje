using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Reciclaje.Infraestructura.DBRepository;
using Reciclaje.Infraestructura.DBSettings;
using dominio = Reciclaje.Dominio.Entidades;

namespace Reciclaje.Aplicacion.Producto.Read
{
    public class ReciclajeQueryAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Reciclaje> _reciclaje;

        public ReciclajeQueryAll()
        {
            _reciclaje = _repository.db.GetCollection<dominio.Reciclaje>("material");
        }

        public IEnumerable<dominio.Reciclaje> ListarMateriales()
        {
            return _reciclaje.Find(x => true).ToList();
        }
    }
}

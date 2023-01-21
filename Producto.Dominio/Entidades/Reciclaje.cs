using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciclaje.Dominio.Entidades
{
    [BsonIgnoreExtraElements]
    public class Reciclaje
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int materialId { get; set; }

        public string materialDescr { get; set; }

        public double unidadMediadId { get; set; }

        public double materialPrecioUnidad { get; set; }

        public double materialLimite { get; set; }

    }
}

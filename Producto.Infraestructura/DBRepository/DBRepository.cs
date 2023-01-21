﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciclaje.Infraestructura.DBRepository
{
    public class DBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;

        public DBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("Reciclaje");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Reciclaje.Api.Routes;
using Reciclaje.Aplicacion.Producto.Read;
using Reciclaje.Dominio.Servicios;
using static Reciclaje.Api.Routes.ApiRoutes;
using dominio = Reciclaje.Dominio.Entidades;

namespace Reciclaje.Api.Controllers
{
    [ApiController]
    public class ReciclajeController : ControllerBase
    {
        private ReciclajeQueryAll db = new ReciclajeQueryAll();

        [HttpGet(RouteReciclaje.GetAll)]
        public IEnumerable<dominio.Reciclaje> ListarMateriales()
        {
            //#region Conexión a base de datos
            //var client = new MongoClient("mongodb://localhost:27017");
            //var database = client.GetDatabase("TDB_productos");
            //var collection = database.GetCollection<dominio.Producto>("producto");
            //#endregion

            //var listaProducto = collection.Find(x => true).ToList();

            var listarMateriales = db.ListarMateriales();
            return listarMateriales;
        }

       // [HttpGet(RouteProducto.GetById)]
      //  public dominio.Producto BuscarProducto(int id)
       // {
       //     #region Conexión a base de datos
         //   var client = new MongoClient("mongodb://localhost:27017");
          //  var database = client.GetDatabase("ProyectoTaller");
           // var collection = database.GetCollection<dominio.Producto>("productos");
           // #endregion

//            var objProducto = collection.Find(x => x.IdProducto == id).FirstOrDefault();
//
  //          return objProducto;
  //      }

        [HttpPost(RouteReciclaje.Create)]
        public ActionResult<dominio.Reciclaje> CrearMaterial(dominio.Reciclaje reciclaje)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Reciclaje");
            var collection = database.GetCollection<dominio.Reciclaje>("material");
            #endregion

            reciclaje._id = ObjectId.GenerateNewId().ToString();
            collection.InsertOne(reciclaje);
            //producto.IdProducto = listaProducto.Count() + 1;
            //listaProducto.Add(producto);
            return Ok();
        }

        [HttpPut(RouteReciclaje.Update)]
        public ActionResult<dominio.Reciclaje> ModificarMaterial(dominio.Reciclaje reciclaje)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Reciclaje");
            var collection = database.GetCollection<dominio.Reciclaje>("material");
            #endregion

            collection.FindOneAndReplace(x => x._id == reciclaje._id, reciclaje);

            //var oldProducto = collection.Find(x => x.IdProducto == producto.IdProducto).FirstOrDefault();
            //oldProducto.Nombre = producto.Nombre;
            //oldProducto.Precio = producto.Precio;
            //oldProducto.Cantidad = producto.Cantidad;
            //collection.ReplaceOne(x=>x.IdProducto == oldProducto.IdProducto, oldProducto);


            //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
            //productoModificado.Nombre = producto.Nombre;
            //productoModificado.Cantidad = producto.Cantidad;
            //productoModificado.Precio= producto.Precio;
            //return CreatedAtAction("ModificarProducto", productoModificado);
            return Ok();
        }

        [HttpDelete(RouteReciclaje.Delete)]
        public ActionResult<dominio.Reciclaje> EliminarMaterial(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Reciclaje");
            var collection = database.GetCollection<dominio.Reciclaje>("material");
            #endregion

            collection.FindOneAndDelete(x => x.materialId == id);
            //listaProducto.RemoveAt(id);
            return Ok(id);
        }
    }
}

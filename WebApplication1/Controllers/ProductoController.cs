﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Producto.Api.Routes;
using Producto.Aplicacion.Producto.Read;
using Producto.Dominio.Servicios;
using static Producto.Api.Routes.ApiRoutes;
using dominio = Producto.Dominio.Entidades;

namespace Producto.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoQueryAll db = new ProductoQueryAll();

        [HttpGet(RouteProducto.GetAll)]
        public IEnumerable<dominio.Producto> ListarProductos()
        {
            //#region Conexión a base de datos
            //var client = new MongoClient("mongodb://localhost:27017");
            //var database = client.GetDatabase("TDB_productos");
            //var collection = database.GetCollection<dominio.Producto>("producto");
            //#endregion

            //var listaProducto = collection.Find(x => true).ToList();

            var listaProducto = db.ListarProductos();
            return listaProducto;
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

        [HttpPost(RouteProducto.Create)]
        public ActionResult<dominio.Producto> CrearProducto(dominio.Producto producto)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ProyectoTaller");
            var collection = database.GetCollection<dominio.Producto>("productos");
            #endregion

            producto._id = ObjectId.GenerateNewId().ToString();
            collection.InsertOne(producto);
            //producto.IdProducto = listaProducto.Count() + 1;
            //listaProducto.Add(producto);
            return Ok();
        }

        [HttpPut(RouteProducto.Update)]
        public ActionResult<dominio.Producto> ModificarProducto(dominio.Producto producto)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ProyectoTaller");
            var collection = database.GetCollection<dominio.Producto>("productos");
            #endregion

            collection.FindOneAndReplace(x => x._id == producto._id, producto);

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

        [HttpDelete(RouteProducto.Delete)]
        public ActionResult<dominio.Producto> EliminarProducto(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ProyectoTaller");
            var collection = database.GetCollection<dominio.Producto>("productos");
            #endregion

            collection.FindOneAndDelete(x => x.IdProducto == id);
            //listaProducto.RemoveAt(id);
            return Ok(id);
        }
    }
}

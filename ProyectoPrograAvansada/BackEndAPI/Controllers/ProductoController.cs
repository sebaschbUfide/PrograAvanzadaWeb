using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    { 
        private Producto Convertir(ProductoModel producto)
    {
        return new Producto
        {
            ProdId =producto.ProdId,
            ProdName = producto.ProdName,
            ProdDescrip = producto.ProdDescrip,
            ProdPrecio = producto.ProdPrecio

        };
    }

    
        // GET: api/<Producto>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Producto> productos;
            using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new PrograAvanzadaWebBDContext()))
            {
                productos = unidad.genericDAL.GetAll();
            }


            return new JsonResult(productos);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Producto producto;
            using (UnidadDeTrabajo<Producto> unidad = new
                UnidadDeTrabajo<Producto>(new PrograAvanzadaWebBDContext()))
            {
                producto = unidad.genericDAL.Get(id);
            }
            return new JsonResult(producto);
        }


        // POST api/<ProductoController>
        [HttpPost]
        public bool Post([FromBody] ProductoModel producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return false;
                }

                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new PrograAvanzadaWebBDContext()))
                {
                    
                    unidad.genericDAL.Add(Convertir(producto));
                     unidad.Complete();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

           
        }
        // PUT api/<ProductoController>/5
        [HttpPut]
        public bool Put( [FromBody] ProductoModel  producto)
        {
            bool result = false;
            try
            {
                if (!ModelState.IsValid)
                {
                    return false;
                }
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new PrograAvanzadaWebBDContext()))
                {
                    unidad.genericDAL.Update(Convertir(producto));
                    result = unidad.Complete();
                }

                return result;
            }
            catch (Exception)
            {

                return result;
            }
        }
        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
         

            try
            {
                Producto producto;
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new PrograAvanzadaWebBDContext()))
                {
                    producto = unidad.genericDAL.Get(id);
                }
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new PrograAvanzadaWebBDContext()))
                {
                    unidad.genericDAL.Remove(producto);
                     unidad.Complete();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ContizacionController : ControllerBase
    {
        private Cotizacion Convertir(CotizacionViewModel cotizacion)
        {
            return new Cotizacion
            {
                ContizacionId = cotizacion.ContizacionId,
                ClienteName = cotizacion.ClienteName,
                ProducName = cotizacion.ProducName


            };
        }
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Cotizacion> cotizacion;
            using (UnidadDeTrabajo<Cotizacion> unidad = new UnidadDeTrabajo<Cotizacion>(new PrograAvanzadaWebBDContext()))
            {
                cotizacion = unidad.genericDAL.GetAll();
            }


            return new JsonResult(cotizacion);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Cotizacion cotizacion;
            using (UnidadDeTrabajo<Cotizacion> unidad = new
                UnidadDeTrabajo<Cotizacion>(new PrograAvanzadaWebBDContext()))
            {
                cotizacion = unidad.genericDAL.Get(id);
            }
            return new JsonResult(cotizacion);
        }


        // POST api/<ProductoController>
        [HttpPost]
        public bool Post([FromBody] CotizacionViewModel cotizacion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return false;
                }

                using (UnidadDeTrabajo<Cotizacion> unidad = new UnidadDeTrabajo<Cotizacion>(new PrograAvanzadaWebBDContext()))
                {

                    unidad.genericDAL.Add(Convertir(cotizacion));
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
        public bool Put([FromBody] CotizacionViewModel cotizacion)
        {
            bool result = false;
            try
            {
                if (!ModelState.IsValid)
                {
                    return false;
                }
                using (UnidadDeTrabajo<Cotizacion> unidad = new UnidadDeTrabajo<Cotizacion>(new PrograAvanzadaWebBDContext()))
                {
                    unidad.genericDAL.Update(Convertir(cotizacion));
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
                Cotizacion cotizacion;
                using (UnidadDeTrabajo<Cotizacion> unidad = new UnidadDeTrabajo<Cotizacion>(new PrograAvanzadaWebBDContext()))
                {
                    cotizacion = unidad.genericDAL.Get(id);
                }
                using (UnidadDeTrabajo<Cotizacion> unidad = new UnidadDeTrabajo<Cotizacion>(new PrograAvanzadaWebBDContext()))
                {
                    unidad.genericDAL.Remove(cotizacion);
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

using BackEnd.DAL;
using BackEnd.Entities;
using FrontEndApi.Models;
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
    public class EnvioController : ControllerBase
    {
        private Envio Convertir(EnvioVeiwModel envio)
        {
            return new Envio
            {
                EnvioId = envio.EnvioId,
                ClienteId = envio.ClienteId,
                CotizacionId = envio.ContizacionId,
                Direccion = envio.Direccion
                 

            };
        }
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Envio> envio;
            using (UnidadDeTrabajo<Envio> unidad = new UnidadDeTrabajo<Envio>(new PrograAvanzadaWebBDContext()))
            {
                envio = unidad.genericDAL.GetAll();
            }


            return new JsonResult(envio);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Envio envio;
            using (UnidadDeTrabajo<Envio> unidad = new
                UnidadDeTrabajo<Envio>(new PrograAvanzadaWebBDContext()))
            {
                envio = unidad.genericDAL.Get(id);
            }
            return new JsonResult(envio);
        }


        // POST api/<ProductoController>
        [HttpPost]
        public bool Post([FromBody] EnvioVeiwModel envio)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return false;
                }

                using (UnidadDeTrabajo<Envio> unidad = new UnidadDeTrabajo<Envio>(new PrograAvanzadaWebBDContext()))
                {

                    unidad.genericDAL.Add(Convertir(envio));
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
        public bool Put([FromBody] EnvioVeiwModel envio)
        {
            bool result = false;
            try
            {
                if (!ModelState.IsValid)
                {
                    return false;
                }
                using (UnidadDeTrabajo<Envio> unidad = new UnidadDeTrabajo<Envio>(new PrograAvanzadaWebBDContext()))
                {
                    unidad.genericDAL.Update(Convertir(envio));
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
                Envio envio;
                using (UnidadDeTrabajo<Envio> unidad = new UnidadDeTrabajo<Envio>(new PrograAvanzadaWebBDContext()))
                {
                    envio = unidad.genericDAL.Get(id);
                }
                using (UnidadDeTrabajo<Envio> unidad = new UnidadDeTrabajo<Envio>(new PrograAvanzadaWebBDContext()))
                {
                    unidad.genericDAL.Remove(envio);
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


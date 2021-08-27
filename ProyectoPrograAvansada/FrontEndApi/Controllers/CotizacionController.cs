using FrontEndApi.REST;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEndApi.Controllers
{
    public class CotizacionController : Controller
    {
       



            private readonly IConfiguration _config;
            private string _URL;
            private ServiceRepository serviceObj;
            public CotizacionController(IConfiguration config)
            {

                _config = config;
                _URL = _config.GetValue<string>("Services:ProyectoPrograAvanzadaURL");
                serviceObj = new ServiceRepository(_URL);
            }
            // GET: ProductoController
            public ActionResult Index()
            {
                try
                {
                    ServiceRepository serviceObj = new ServiceRepository(_URL);
                    HttpResponseMessage response = serviceObj.GetResponse("api/envio");
                    response.EnsureSuccessStatusCode();
                    //List<Models.ProductoViewModel> productos = new List<Models.ProductoViewModel>();
                    var content = response.Content.ReadAsStringAsync().Result;

                    List<Models.CotizacionViewModel> cotizacion = JsonConvert.DeserializeObject<List<Models.CotizacionViewModel>>(content);


                    ViewBag.Title = "Cotizacion";
                    return View(cotizacion);
                }
                catch (HttpRequestException)
                {
                    throw;
                }

                catch (Exception)
                {
                    throw;
                }
            }

            // GET: ProductoController/Details/5
            public ActionResult Details(int id)
            {
                HttpResponseMessage response = serviceObj.GetResponse("api/cot/" + id.ToString());
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                Models.EnvioVeiwModel envioVeiwModel = JsonConvert.DeserializeObject<Models.EnvioVeiwModel>(content);



                //ViewBag.Title = "All Products";
                return View(envioVeiwModel);
            }

            // GET: ProductoController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: CategoryController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Models.EnvioVeiwModel envio)
            {
                try
                {

                    HttpResponseMessage response = serviceObj.PostResponse("api/cot", envio);
                    response.EnsureSuccessStatusCode();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: ProductoController/Edit/5
            public ActionResult Edit(int id)
            {

                HttpResponseMessage response = serviceObj.GetResponse("api/evio/" + id.ToString());
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                Models.EnvioVeiwModel envioVeiwModel = JsonConvert.DeserializeObject<Models.EnvioVeiwModel>(content);



                //ViewBag.Title = "All Products";
                return View(envioVeiwModel);
            }

            // POST: CategoryController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Models.EnvioVeiwModel envio)
            {
                try
                {

                    HttpResponseMessage response = serviceObj.PutResponse("api/envio/", envio);
                    response.EnsureSuccessStatusCode();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: ProductoController/Delete/5
            public ActionResult Delete(int id)
            {
                HttpResponseMessage response = serviceObj.GetResponse("api/envio/" + id.ToString());
                var content = response.Content.ReadAsStringAsync().Result;
                Models.EnvioVeiwModel envioVeiwModel =
                    JsonConvert.DeserializeObject<Models.EnvioVeiwModel>(content);
                return View(envioVeiwModel);
            }

            // POST: CategoryController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(Models.EnvioVeiwModel envio)
            {
                try
                {

                    HttpResponseMessage response = serviceObj.DeleteResponse("api/envio/" + envio.EnvioId.ToString());
                    response.EnsureSuccessStatusCode();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }


    }


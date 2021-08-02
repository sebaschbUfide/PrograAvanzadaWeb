using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FrontEndAPI.REST;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FrontEndApi.Controllers
{
    public class ProductoController : Controller
    {


        private readonly IConfiguration _config;
        private string _URL;
        public ProductoController(IConfiguration config)
        {

            _config = config;
            _URL = _config.GetValue<string>("Services:ProyectoPrograAvanzadaURL");
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository(_URL);
                HttpResponseMessage response = serviceObj.GetResponse("api/Producto");
                response.EnsureSuccessStatusCode();
                //List<Models.ProductoViewModel> productos = new List<Models.ProductoViewModel>();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.ProductoViewModel> productos = JsonConvert.DeserializeObject<List<Models.ProductoViewModel>>(content);

                ViewBag.Title = "All productos";
                return View(productos);
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
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

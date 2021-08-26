using FrontEndApi.Extensions;
using FrontEndApi.REST;
using Microsoft.AspNetCore.Http;
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
    public class ProductoController : Controller
    {
        private readonly IConfiguration _config;
        private string _URL;
        ServiceRepository serviceObj;
        public ProductoController(IConfiguration config)
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
                HttpResponseMessage response = serviceObj.GetResponse("api/producto");
                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.ProductoViewModel> productos = JsonConvert.DeserializeObject<List<Models.ProductoViewModel>>(content);

                ViewBag.Title = "All Productos";
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

            HttpResponseMessage response = serviceObj.GetResponse("api/producto/" + id.ToString());
            var content = response.Content.ReadAsStringAsync().Result;
            Models.ProductoViewModel productoViewModel =
                JsonConvert.DeserializeObject<Models.ProductoViewModel>(content);
            return View(productoViewModel);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: personaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ProductoViewModel producto)
        {
            try
            {

                HttpResponseMessage response = serviceObj.PostResponse("api/producto", producto);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {

            HttpResponseMessage response = serviceObj.GetResponse("api/producto/" + id.ToString());
            var content = response.Content.ReadAsStringAsync().Result;
            Models.ProductoViewModel productoViewModel =
                JsonConvert.DeserializeObject<Models.ProductoViewModel>(content);
            return View(productoViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.ProductoViewModel producto)
        {
            try
            {
                HttpResponseMessage response = serviceObj.PutResponse("api/producto", producto);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Details", new { id = producto.ProdId});
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = serviceObj.GetResponse("api/producto/" + id.ToString());
            var content = response.Content.ReadAsStringAsync().Result;
            Models.ProductoViewModel productoViewModel =
                JsonConvert.DeserializeObject<Models.ProductoViewModel>(content);
            return View(productoViewModel);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.ProductoViewModel producto)
        {
            try
            {

                HttpResponseMessage response = serviceObj.DeleteResponse("api/producto/" + producto.ProdId.ToString());
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public IActionResult GetProductos(int? idproducto)
        {
            ServiceRepository serviceObj = new ServiceRepository(_URL);
            HttpResponseMessage response = serviceObj.GetResponse("api/producto");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            if (idproducto != null)
            {
                List<int> carrito;
                if (HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                {
                    carrito = new List<int>();
                }
                else
                {
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                }
                if (carrito.Contains(idproducto.Value) == false)
                {
                    carrito.Add(idproducto.Value);
                    HttpContext.Session.SetObject("CARRITO", carrito);
                }
            }
            List<Models.ProductoViewModel> productos = JsonConvert.DeserializeObject<List<Models.ProductoViewModel>>(content);
            return View(productos);
        }

        public IActionResult Carrito(int? idproducto)
        {
            ServiceRepository serviceObj = new ServiceRepository(_URL);
            HttpResponseMessage response = serviceObj.GetResponse("api/producto");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            if (carrito == null)
            {
                return View();
            }
            else
            {
                if (idproducto != null)
                {
                    carrito.Remove(idproducto.Value);
                    HttpContext.Session.SetObject("CARRITO", carrito);
                }

                List<Models.ProductoViewModel> productos = JsonConvert.DeserializeObject<List<Models.ProductoViewModel>>(content);
                return View(productos);
            }
        }

        public IActionResult Pedidos()
        {
            ServiceRepository serviceObj = new ServiceRepository(_URL);
            HttpResponseMessage response = serviceObj.GetResponse("api/producto");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            List<Models.ProductoViewModel> productos = JsonConvert.DeserializeObject<List<Models.ProductoViewModel>>(content);
            HttpContext.Session.Remove("CARRITO");
            return View(productos);
        }
    }
}
   /* }
}*/

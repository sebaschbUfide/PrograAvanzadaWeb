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
        private ServiceRepository serviceObj;
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
            HttpResponseMessage response = serviceObj.GetResponse("api/producto/" + id.ToString());
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            Models.ProductoViewModel productoViewModel = JsonConvert.DeserializeObject<Models.ProductoViewModel>(content);



            //ViewBag.Title = "All Products";
            return View(productoViewModel);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
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

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {

            HttpResponseMessage response = serviceObj.GetResponse("api/producto/" + id.ToString());
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            Models.ProductoViewModel productoViewModel = JsonConvert.DeserializeObject<Models.ProductoViewModel>(content);



            //ViewBag.Title = "All Products";
            return View(productoViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.ProductoViewModel producto)
        {
            try
            {

                HttpResponseMessage response = serviceObj.PutResponse("api/producto/", producto);
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
    }
}

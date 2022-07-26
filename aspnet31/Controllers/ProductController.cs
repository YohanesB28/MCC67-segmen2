using aspnet31.Models;
using aspnet31.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Threading.Tasks;

namespace aspnet31.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository;
        SupplierRepository supplierRepository;

        public ProductController(ProductRepository productRepository, SupplierRepository supplierRepository)
        {
            this.productRepository = productRepository;
            this.supplierRepository = supplierRepository;
        }

        #region get
        public ActionResult Index()
        {
            //var products = productRepository.Get();
            //if (products == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }
        #endregion get

        #region Details
        [HttpGet("/Product/Details/{id}")]
        public ActionResult Details(int id)
        {
            var products = productRepository.Get(id);
            return View(products);
        }
        #endregion Details

        #region Create
        public ActionResult Create()
        {
            var suppliers = supplierRepository.Get();
            if (suppliers.Count > 0)
            {
                ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name");
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var result = productRepository.Post(product);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return View();
        }
        #endregion Create

        #region Edit
        [HttpGet("/Product/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var suppliers = supplierRepository.Get();
            if (suppliers.Count > 0)
            {
                ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name");
            }
            var products = productRepository.Get(id);
            return View(products);
        }

        [HttpPost("/Product/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var result = productRepository.Put(product);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return View();
        }
        #endregion Edit

        #region Delete
        [HttpGet("Product/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var products = productRepository.Get(id);
            if (products != null)
            {
                return View(products);
            }
            return View();
        }

        [HttpPost("/Product/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            var result = productRepository.Delete(product.Id);
            if (result > 0)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        #endregion Delete
    }
}

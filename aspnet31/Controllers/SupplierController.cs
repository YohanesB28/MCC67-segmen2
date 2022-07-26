using aspnet31.Models;
using aspnet31.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace aspnet31.Controllers
{
    public class SupplierController : Controller
    {
        SupplierRepository supplierRepository;

        public SupplierController(SupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        #region Get
        [HttpGet]
        public ActionResult Index()
        {
            //var suppliers = supplierRepository.Get();
            //if (suppliers != null)
            //{
            //    return View(suppliers);
            //}
            return View();
        }
        #endregion Get

        #region Details
        [HttpGet("/Supplier/Details/{id}")]
        public ActionResult Details(int id)
        {
            var suppliers = supplierRepository.Get(id);
            return View(suppliers);
        }
        #endregion Details

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            var result = supplierRepository.Post(supplier);
            if (result>0)
            {
                return RedirectToAction("Index", "Supplier");
            }
            return View();
        }
        #endregion Create

        #region Edit
        [HttpGet("/Supplier/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var suppliers = supplierRepository.Get(id);
            return View(suppliers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            /*if (ModelState.IsValid)
            {
                var result = supplierRepository.Put(supplier);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Supplier");
                }
            }
            return View();*/
            var result = supplierRepository.Put(supplier);
            if (result > 0)
            {
                return RedirectToAction("Index", "Supplier");
            }
            return View();
        }
        #endregion Edit

        #region Delete
        [HttpGet("/Supplier/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var suppliers = supplierRepository.Get(id);
            return View(suppliers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Supplier supplier)
        {
            //context.Entry(supplier).State = EntityState.Deleted;
            var result = supplierRepository.Delete(supplier.Id);
            if (result > 0)
            {
                return RedirectToAction("Index", "Supplier");
            }
            return View();
        }
        #endregion Delete
    }
}

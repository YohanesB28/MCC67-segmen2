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
            return View();
        }
        #endregion Get

        #region GetbyJson
        [HttpGet]
        public ActionResult GetJson()
        {
            var suppliers = supplierRepository.Get();
            if (suppliers != null)
                return Ok(new
                {
                    status = 200,
                    message = "Data Berhasil Didapatkan",
                    data = suppliers
                });
            return NotFound(new
            {
                status = 404,
                message = "Data Tidak Ditemukan di getbyjson"
            });
        }
        #endregion GetbyJson

        #region Details
        [HttpGet("/Supplier/Details/{id}")]
        public ActionResult Details(int id)
        {
            var suppliers = supplierRepository.Get(id);
            if (suppliers != null)
            {
                return Ok(new
                {
                    status = 200,
                    message = "Data Berhasil Didapatkan",
                    data = suppliers
                });
            }
            else
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Data Tidak Ditemukan didetails"
                });
            }
        }
        #endregion Details

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([FromBody]Supplier supplier)
        {
            var result = supplierRepository.Post(supplier);
            if (result > 0)
            {
                return Ok(new
                {
                    status = 200,
                    message = "Dapat Berhasil Diinputkan"
                });
            }
            else
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "Data Gagal Diinputkan"
                });
            }
        }
        #endregion Create

        #region Edit
        [HttpGet("/Supplier/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            //var suppliers = supplierRepository.Get(id);
            return View();
        }

        [HttpPut]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([FromBody]Supplier supplier)
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
            //if (result > 0)
            //{
            //    return RedirectToAction("Index", "Supplier");
            //}
            //return View();
            if (result > 0)
            {
                return Ok(new
                {
                    status = 200,
                    message = "Dapat Berhasil DiUpdate"
                });
            }
            else
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "Data Gagal Diinputkan"
                });
            }
        }
        #endregion Edit

        #region Delete
        [HttpGet("/Supplier/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            //var suppliers = supplierRepository.Get(id);
            return View();
        }

        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete([FromBody] Supplier supplier)
        {
            //context.Entry(supplier).State = EntityState.Deleted;
            var result = supplierRepository.Delete(supplier.Id);
            //if (result > 0)
            //{
            //    return RedirectToAction("Index", "Supplier");
            //}
            //return View();
            if (result > 0)
            {
                return Ok(new
                {
                    status = 200,
                    message = "Dapat Berhasil Dihapus"
                });
            }
            else
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "Data Gagal Diinputkan"
                });
            }
        }
        #endregion Delete
    }
}

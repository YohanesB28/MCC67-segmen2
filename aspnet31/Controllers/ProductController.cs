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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion get

        #region GetbyJson
        [HttpGet]
        public ActionResult GetJson()
        {
            var products = productRepository.Get();
            if (products != null)
                return Ok(new
                {
                    status = 200,
                    message = "Data Berhasil Didapatkan",
                    data = products
                });
            return NotFound(new
            {
                status = 404,
                message = "Data Tidak Ditemukan di getbyjson"
            });
        }
        #endregion GetbyJson

        #region Details
        [HttpGet("/Product/Details/{id}")]
        public ActionResult Details(int id)
        {
            var products = productRepository.Get(id);
            if (products != null)
            {
                return Ok(new
                {
                    status = 200,
                    message = "Data Berhasil Didapatkan",
                    data = products
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
        //[ValidateAntiForgeryToken]
        public ActionResult Create([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                var result = productRepository.Post(product);
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
            return RedirectToAction("Index", "Home");
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

        [HttpPut]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                var result = productRepository.Put(product);
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
            return RedirectToAction("Index", "Home");
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

        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete([FromBody]Product product)
        {
            var result = productRepository.Delete(product.Id);
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

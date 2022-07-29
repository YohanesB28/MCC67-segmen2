using API.Repositories.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TRepository> : ControllerBase
        where TModel : class
        where TRepository : IGenericRepository<TModel>
    {
        TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<TModel>> Get()
        {
            var result = repository.Get();
            if (result != null)
                return Ok(new 
                { 
                    status = 200,
                    message = "Data Berhasil Didapatkan",
                    data = result
                });
             return NotFound(new
             {
                status = 404,
                message = "Data Tidak Ditemukan"
             });
        }

        /*[HttpGet("/api/Product/GetByJoin")]
        public ActionResult<List<Product>> getByJoin()
        {
            var result = repository.;
            if (result != null)
            {
                return Ok(new
                {
                    status = 200,
                    message = "Data Berhasil Didapatkan",
                    data = result
                });
            }
            else
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Data Tidak Ditemukan"
                });
            }
        }*/

        [HttpGet("{id}")]
        public ActionResult<TModel> Get(int id)
        {
            var result = repository.Get(id);
            if (result != null)
            {
                return Ok(new 
                {
                    status =200,
                    message = "Data Berhasil Didapatkan",
                    data = result
                });
            }
            else
            {
                return NotFound(new 
                { 
                    status = 404,
                    message = "Data Tidak Ditemukan"
                });
            }
        }

        [HttpPost]
        public ActionResult<int> Post(TModel model)
        {
            if (repository.Post(model) > 0)
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

        [HttpPut]
        public ActionResult<int> Put(TModel model)
        {
            if (repository.Put(model) > 0)
            {
                return Ok(new 
                {
                    status =200,
                    message = "Data Berhasil Diupdate"
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

        [HttpDelete]
        public ActionResult<int> Delete(TModel model)
        {
            if (repository.Delete(model) > 0)
            {
                return Ok(new 
                {
                    status =200,
                    message = "Data Berhasil Didelete"
                });
            }
            else
            {
                return BadRequest(new 
                {
                    status =400,
                    message = "Data Gagal Didelete"
                });
            }
        }
    }
}

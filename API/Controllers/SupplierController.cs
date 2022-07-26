using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Manager")]
    public class SupplierController : BaseController<Supplier, SupplierRepository>
    {
        SupplierRepository repository;
        public SupplierController(SupplierRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}

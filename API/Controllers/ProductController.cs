using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ProductController : BaseController<Product, ProductRepository>
    {
        ProductRepository repository;
        public ProductController(ProductRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}

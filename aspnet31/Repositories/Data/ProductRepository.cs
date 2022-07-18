using aspnet31.Context;
using aspnet31.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace aspnet31.Repositories.Data
{
    public class ProductRepository : GenericRepository<Product, int>
    {
        public ProductRepository() : base("Product")
        {
        }
    }
}

using aspnet31.Context;
using aspnet31.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace aspnet31.Repositories.Data
{
    public class SupplierRepository : GenericRepository<Supplier, int>
    {
        public SupplierRepository() : base("Supplier")
        {
        }
    }
}

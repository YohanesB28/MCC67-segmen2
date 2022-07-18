using aspnet31.Models;
using System.Collections.Generic;

namespace aspnet31.Repositories.Interfaces
{
    public interface IProduct
    {
        List<Product> Get();
        Product Get(int id);
        int Post(Product product);
        int Put(Product product);
        int Delete(Product product);
    }
}

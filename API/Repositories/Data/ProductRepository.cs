using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class ProductRepository : GenericRepository<Product>
    {
        MyContext myContext;

        public ProductRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}

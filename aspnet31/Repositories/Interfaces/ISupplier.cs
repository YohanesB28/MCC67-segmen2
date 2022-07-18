using aspnet31.Models;
using System.Collections.Generic;

namespace aspnet31.Repositories.Interfaces
{
    public interface ISupplier
    {
        //Get all
        List<Supplier> Get();
        //Get
        Supplier Get(int id);
        //Post
        int Post(Supplier supplier);
        //put (Edit)
        int Put(Supplier supplier);
        //Delete
        int Delete(Supplier supplier);
    }
}

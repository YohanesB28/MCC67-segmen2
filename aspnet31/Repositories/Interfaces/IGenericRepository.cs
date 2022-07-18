using System.Collections.Generic;

namespace aspnet31.Repositories.Interfaces
{
    public interface IGenericRepository<TModel, TPrimaryKey>
        where TModel : class
    {
        List<TModel> Get();
        TModel Get(TPrimaryKey id);
        int Post(TModel model);
        int Put(TModel model);
        int Delete(TPrimaryKey id);
    }
}

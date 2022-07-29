using System.Collections.Generic;

namespace API.Repositories.Repositories
{
    public interface IGenericRepository<TModel>
        where TModel : class
    {
        public List<TModel> Get();
        public TModel Get(int id);
        public int Post(TModel model);
        public int Put(TModel model);
        public int Delete(TModel model);
    }
}

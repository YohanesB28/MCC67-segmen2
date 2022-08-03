using API.Context;
using API.Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel>
        where TModel : class
    {
        MyContext myContext;

        public GenericRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            TModel model = Get(id);
            myContext.Set<TModel>().Remove(model);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<TModel> Get()
        {
            return myContext.Set<TModel>().ToList();
        }

        public TModel Get(int id)
        {
            return myContext.Set<TModel>().Find(id);
        }

        public int Post(TModel model)
        {
            myContext.Set<TModel>().Add(model);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(TModel model)
        {
            myContext.Set<TModel>().Update(model);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}

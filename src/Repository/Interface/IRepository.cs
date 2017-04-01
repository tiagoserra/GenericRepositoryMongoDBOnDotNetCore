using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {

        void Insert(TEntity obj);

        void Remove(Guid id);

        void Update(TEntity obj);

        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

    }
}

using System.Collections.Generic;
using ProductProject.API.Utils;

namespace ProductProject.API.Repositories
{
    public interface IRepository<T, TId>
    {
        IEnumerable<T> GetAll();

        T Get(TId id);

        IRepositoryResponse Update(TId id, T item);

        IRepositoryResponse Insert(T item);

        IRepositoryResponse Delete(TId id);

        bool Save();
    }
}

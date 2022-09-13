using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductProject.API.Repositories
{
    public interface IProductRepository : IRepository<Entities.Product, int>
    {
        IEnumerable<Entities.Product> Get(string description);
    }
}

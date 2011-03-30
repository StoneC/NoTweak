using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoTweak.Domain;
using NoTweak.Data.Infrastructure;

namespace NoTweak.Data
{
    public class DishRepository : RepositoryBase<Dish>, IDishRepository
    {
        public DishRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IDishRepository : IRepository<Dish>
    {
    }
   
}

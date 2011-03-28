using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoTweak.Domain;
using NoTweak.Data.Infrastructure;


namespace NoTweak.Data
{
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
    }
}

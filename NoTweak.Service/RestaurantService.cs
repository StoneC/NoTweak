using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoTweak.Domain;
using NoTweak.Data;
using NoTweak.Data.Infrastructure;

namespace NoTweak.Service
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);
        void CreateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);
        void SaveRestaurant();
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository RestaurantRepository;
        private readonly IUnitOfWork unitOfWork;
        public RestaurantService(IRestaurantRepository RestaurantRepository, IUnitOfWork unitOfWork)
        {
            this.RestaurantRepository = RestaurantRepository;
            this.unitOfWork = unitOfWork;
        }  
        #region IRestaurantService Members

        public IEnumerable<Restaurant> GetCategories()
        {
            var categories = RestaurantRepository.GetAll();
            return categories;
        }

        public Restaurant GetRestaurant(int id)
        {
            var Restaurant = RestaurantRepository.GetById(id);
            return Restaurant;
        }

        public void CreateRestaurant(Restaurant Restaurant)
        {
            RestaurantRepository.Add(Restaurant);
            unitOfWork.Commit();
        }

        public void DeleteRestaurant(int id)
        {
            var Restaurant = RestaurantRepository.GetById(id);
            RestaurantRepository.Delete(Restaurant);
            unitOfWork.Commit();
        }

        public void SaveRestaurant()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoTweak.Domain;
using NoTweak.Data;
using NoTweak.Data.Infrastructure;

namespace NoTweak.Service
{
    public interface IDishService
    {
        IEnumerable<Dish> GetDishes();
        Dish GetDish(int id);
        void CreateDish(Dish Dish);
        void DeleteDish(int id);
        void SaveDish();
    }

    public class DishService : IDishService
    {
        private readonly IDishRepository DishRepository;
        private readonly IUnitOfWork unitOfWork;
        public DishService(IDishRepository DishRepository, IUnitOfWork unitOfWork)
        {
            this.DishRepository = DishRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IDishService Members

        public IEnumerable<Dish> GetDishes()
        {
            var Dishes = DishRepository.GetAll();
            return Dishes;
        }

        public Dish GetDish(int id)
        {
            var Dish = DishRepository.GetById(id);
            return Dish;
        }

        public void CreateDish(Dish Dish)
        {
            DishRepository.Add(Dish);
            unitOfWork.Commit();
        }

        public void DeleteDish(int id)
        {
            var Dish = DishRepository.GetById(id);
            DishRepository.Delete(Dish);
            unitOfWork.Commit();
        }

        public void SaveDish()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}

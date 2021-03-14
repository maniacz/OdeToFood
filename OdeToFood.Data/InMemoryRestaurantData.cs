using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Sierak", Location = "Gliwice", Cusine = CusineType.Mexican},
                new Restaurant {Id = 2, Name = "Lilly Kebab", Location = "Bielsko-Biała", Cusine = CusineType.Indian},
                new Restaurant {Id = 3, Name = "Rka", Location = "Żory", Cusine = CusineType.Italian}
            };
        }

        public Restaurant GetById(int restaurantId)
        {
            return restaurants.SingleOrDefault(r => r.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants
                .Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name))
                .OrderBy(r => r.Name);

            //return from r in restaurants
            //       where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
            //       orderby r.Name
            //       select r;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var resaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (resaurant != null)
            {
                resaurant.Name = updatedRestaurant.Name;
                resaurant.Location = updatedRestaurant.Location;
                resaurant.Cusine = updatedRestaurant.Cusine;
            }
            return resaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}

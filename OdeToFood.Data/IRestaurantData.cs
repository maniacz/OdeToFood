using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

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
    }
}

using SMS.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class CityServices
    {
        private readonly SMSDbContext _context = new SMSDbContext();

        public List<City> GetCities()
        {
            return _context.Cities.Where(c => c.IsDelete == false).ToList();
        }

        public City GetCityById(int id)
        {
            return _context.Cities.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Create(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public void Update(City city)
        {
            var query = _context.Cities.Where(c => c.Id == city.Id).FirstOrDefault();
            if (query != null)
            {
                query.Name = city.Name;
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var query = _context.Cities.Find(id);
            if(query != null) query.IsDelete = true;
        }
    }
}

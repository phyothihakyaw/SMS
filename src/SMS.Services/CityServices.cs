using SMS.Data.Models;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class CityServices : CommonServices<CityViewModel>
    {
        private readonly SMSDbContext _context = new SMSDbContext();

        public override List<CityViewModel> GetAll()
        {
            return _context
                .Cities
                .Where(c => c.IsDelete == false)
                .Select(c => new CityViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }

        public override CityViewModel GetById(int id)
        {
            return _context
                .Cities
                .Where(c => c.Id == id)
                .Select(c => new CityViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();
        }

        public override void Create(CityViewModel cityViewModel, string userId)
        {
            var city = new City
            {
                Id = cityViewModel.Id,
                Name = cityViewModel.Name
            };
            city.CreatedUserId = city.UpdatedUserId = userId;
            city.CreatedDate = city.UpdatedDate = DateTime.Now;
            city.Version = 1;

            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public override void Update(CityViewModel viewModel, string userId)
        {
            var query = _context.Cities.Where(c => c.Id == viewModel.Id).FirstOrDefault();
            if (query != null)
            {
                query.Name = viewModel.Name;
                query.UpdatedUserId = userId;
                query.UpdatedDate = DateTime.Now;
                query.Version += 1;
            }

            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = _context.Cities.Find(id);
            if (query != null) query.IsDelete = true;

            _context.SaveChanges();
        }
    }
}

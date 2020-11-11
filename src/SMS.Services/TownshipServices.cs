using SMS.Data.Models;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class TownshipServices : CommonServices<TownshipViewModel>
    {
        private readonly SMSDbContext _context = new SMSDbContext();

        public override List<TownshipViewModel> GetAll()
        {
            var townships = _context.Townships      //outer table
                .Where(t => !t.IsDelete)
                .Join(
                    _context.Cities,                //inner table 
                    t => t.CityId,                  //inner table key
                    c => c.Id,                      //outter table key
                    (t, c) => new { t, c }          //function to make new annoynymouse object based on matching keys from two table
                ).Select(tc => new TownshipViewModel
                {
                    Id = tc.t.Id,
                    Name = tc.t.Name,
                    CityId = tc.t.CityId,
                    CityName = tc.c.Name
                })
                .ToList();

            return townships;
        }

        public override TownshipViewModel GetById(int id)
        {
            var township = _context.Townships.Where(t => t.Id == id)
                .Join(
                    _context.Cities,
                    t => t.CityId,
                    c => c.Id,
                    (t, c) => new { t, c }
                ).Select(tc => new TownshipViewModel
                {
                    Id = tc.t.Id,
                    Name = tc.t.Name,
                    CityId = tc.t.CityId,
                    CityName = tc.c.Name
                }).SingleOrDefault();

            return township;
        }

        public List<TownshipViewModel> GetTownshipByCityId(int cityId)
        {
            var townships = _context.Townships
                .Where(t => t.CityId == cityId)
                .Select(t => new TownshipViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    CityId = t.CityId
                }).ToList();

            return townships;
        }

        public override void Create(TownshipViewModel viewModel, string userId)
        {
            var newTownship = new Township
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                CityId = viewModel.CityId
            };
            newTownship.CreatedDate = newTownship.UpdatedDate = DateTime.Now;   //multi variable assignment
            newTownship.CreatedUserId = newTownship.UpdatedUserId = userId;
            newTownship.Version = 1;

            _context.Townships.Add(newTownship);
            _context.SaveChanges();
        }

        public override void Update(TownshipViewModel viewModel, string userId)
        {
            var township = _context.Townships.Where(t => t.Id == viewModel.Id).SingleOrDefault();

            if (township != null)
            {
                township.Id = viewModel.Id;
                township.Name = viewModel.Name;
                township.CityId = viewModel.CityId;
                township.UpdatedUserId = userId;
                township.UpdatedDate = DateTime.Now;
                township.Version += 1;

                _context.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            var township = _context.Townships.Where(t => t.Id == id).SingleOrDefault();

            township.IsDelete = true;
            _context.SaveChanges();
        }
    }
}

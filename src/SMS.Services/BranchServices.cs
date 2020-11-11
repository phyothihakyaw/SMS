using SMS.Data.Models;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class BranchServices : CommonServices<BranchViewModel>
    {
        private readonly SMSDbContext _context = new SMSDbContext();

        public override List<BranchViewModel> GetAll()
        {
            var branches = _context
                .Branches
                .Where(b => !b.IsDelete)
                .Join(
                    _context.Townships,
                    b => b.TownshipId,
                    t => t.Id,
                    (b, t) => new { b, t }
                ).Join(
                    _context.Cities,
                    bt => bt.b.CityId,
                    c => c.Id,
                    (bt, c) => new { bt, c }
                ).Select(btc => new BranchViewModel
                {
                    Id = btc.bt.b.Id,
                    Name = btc.bt.b.Name,
                    CityId = btc.bt.b.CityId,
                    CityName = btc.c.Name,
                    TownshipId = btc.bt.t.Id,
                    TownshipName = btc.bt.t.Name,
                    FullAddress = btc.bt.b.FullAddress,
                    PhoneNo = btc.bt.b.PhoneNo,
                    Email = btc.bt.b.Email
                }).ToList();

            return branches;
        }

        public override BranchViewModel GetById(int id)
        {
            var branch = _context
                .Branches
                .Where(b => !b.IsDelete)
                .Join(
                    _context.Townships,
                    b => b.TownshipId,
                    t => t.Id,
                    (b, t) => new { b, t }
                ).Join(
                    _context.Cities,
                    bt => bt.b.CityId,
                    c => c.Id,
                    (bt, c) => new { bt, c }
                ).Select(btc => new BranchViewModel
                {
                    Id = btc.bt.b.Id,
                    Name = btc.bt.b.Name,
                    CityId = btc.bt.b.CityId,
                    CityName = btc.c.Name,
                    TownshipId = btc.bt.t.Id,
                    TownshipName = btc.bt.t.Name,
                    FullAddress = btc.bt.b.FullAddress,
                    PhoneNo = btc.bt.b.PhoneNo,
                    Email = btc.bt.b.Email
                }).FirstOrDefault();

            return branch;
        }
        public override void Create(BranchViewModel viewModel, string userId)
        {
            var branch = new Branch
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                CityId = viewModel.CityId,
                TownshipId = viewModel.TownshipId,
                FullAddress = viewModel.FullAddress,
                PhoneNo = viewModel.PhoneNo,
                Email = viewModel.Email,
                Version = 1
            };
            branch.CreatedUserId = branch.UpdatedUserId = userId;
            branch.CreatedDate = branch.UpdatedDate = DateTime.Now;

            _context.Branches.Add(branch);
            _context.SaveChanges();
        }

        public override void Update(BranchViewModel viewModel, string userId)
        {
            var branch = _context.Branches.Where(b => b.Id == viewModel.Id).FirstOrDefault();
            if (branch != null)
            {
                branch.Name = viewModel.Name;
                branch.CityId = viewModel.CityId;
                branch.TownshipId = viewModel.TownshipId;
                branch.FullAddress = viewModel.FullAddress;
                branch.PhoneNo = viewModel.PhoneNo;
                branch.Email = viewModel.Email;
                branch.UpdatedDate = DateTime.Now;
                branch.UpdatedUserId = userId;
                branch.Version += 1;
            }

            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var branch = _context.Branches.Where(b => b.Id == id).FirstOrDefault();
            branch.IsDelete = true;

            _context.SaveChanges();
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModels
{
    public class BranchViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Branch")]
        public string Name { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        [Display(Name = "City")]
        public string CityName { get; set; }

        [Display(Name = "Township")]
        public int TownshipId { get; set; }

        [Display(Name = "Township")]
        public string TownshipName { get; set; }

        [Display(Name = "Address")]
        public string FullAddress { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNo { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        public List<CityViewModel> Cities { get; set; }
        public List<TownshipViewModel> Townships { get; set; }
    }
}

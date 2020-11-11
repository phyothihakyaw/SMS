using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModels
{
    public class TownshipViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Township")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        //for list text display
        [Display(Name = "City")]
        [Required]
        public string CityName { get; set; }

        //for dropdown list
        public List<CityViewModel> Cities { get; set; }

        public static bool IsExistingTownship(int id)
        {
            return id == 0 ? false : true;
        }
    }
}

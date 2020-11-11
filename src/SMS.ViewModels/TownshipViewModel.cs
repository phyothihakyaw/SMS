using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModels
{
    public class TownshipViewModel
    {
        public int Id { get; set; }

        [DisplayName("Township")]
        [Required]
        public string Name { get; set; }

        [DisplayName("City")]
        public int CityId { get; set; }

        //for list display
        [DisplayName("City")]
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

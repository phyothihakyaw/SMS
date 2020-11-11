using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [Display(Name = "City")]
        [Required]
        public string Name { get; set; }
    }
}

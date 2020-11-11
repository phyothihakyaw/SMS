using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [DisplayName("City")]
        [Required]
        public string Name { get; set; }
    }
}

using System.ComponentModel;

namespace SMS.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [DisplayName("City Name")]
        public string Name { get; set; }
    }
}

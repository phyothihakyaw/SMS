namespace SMS.Data.Models
{
    public class Township : Common
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}

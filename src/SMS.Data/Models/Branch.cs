namespace SMS.Data.Models
{
    public class Branch : Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int TownshipId { get; set; }
        public string FullAddress { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}

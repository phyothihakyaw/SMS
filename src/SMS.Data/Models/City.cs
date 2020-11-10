namespace SMS.Data.Models
{
    public class City : Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public long Version { get; set; }
    }
}

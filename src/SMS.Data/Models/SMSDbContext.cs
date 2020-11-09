using Microsoft.AspNet.Identity.EntityFramework;

namespace SMS.Data.Models
{
    public class SMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public SMSDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static SMSDbContext Create()
        {
            return new SMSDbContext();
        }
    }
}

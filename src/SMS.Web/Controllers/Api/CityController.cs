using SMS.Data.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SMS.Web.Controllers.Api
{
    public class CityController : ApiController
    {
        private SMSDbContext db = new SMSDbContext();

        // DELETE: api/City/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> DeleteCity(int id)
        {
            City city = await db.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            city.IsDelete = true;
            await db.SaveChangesAsync();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
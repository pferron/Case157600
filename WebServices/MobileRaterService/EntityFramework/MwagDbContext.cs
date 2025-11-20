using System.Data.Entity;
using WOW.MobileRaterService.Models;

namespace WOW.MobileRaterService.Data
{
    public class MwagDbContext : DbContext
    {
        public MwagDbContext() : base("MwagDbContext")
        {
            Database.SetInitializer<MwagDbContext>(null);
        }

        public virtual DbSet<QuoteRequest> QuoteRequests { get; set; }        
    }
}
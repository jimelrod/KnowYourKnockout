using Microsoft.EntityFrameworkCore;

namespace KnowYourKnockout.Data
{
    public class KnowYourKnockoutContext : DbContext
    {
        public KnowYourKnockoutContext(DbContextOptions<KnowYourKnockoutContext> options)
            : base(options)
        {
        }
    }
}

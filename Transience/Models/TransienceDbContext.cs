using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Transience.Models
{
    public class TransienceDbContext : DbContext
    {
        public virtual DbSet<Memory> Memories { get; set; }

        public TransienceDbContext()
            : base("TransienceDb")
        {

        }

        

        public static TransienceDbContext Create()
        {
            return new TransienceDbContext();
        }
    }
}
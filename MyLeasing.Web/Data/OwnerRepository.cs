using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Owner> GetOwnersWithUsers()
        {
            return _context.Owners.Include(o => o.User).OrderBy(o => o.FirstName);
        }
    }
}

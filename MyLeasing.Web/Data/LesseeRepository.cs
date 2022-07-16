using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;
using System.Linq;

namespace MyLeasing.Web.Data
{
    public class LesseeRepository : GenericRepository<Lessee>, ILesseeRepository
    {
        private readonly DataContext _context;

        public LesseeRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Lessee> GetLesseesWithUsers()
        {
            return _context.Lessees.Include(o => o.User).OrderBy(o => o.FirstName);
        }
    }
}
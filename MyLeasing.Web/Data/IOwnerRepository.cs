using System.Linq;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        IQueryable<Owner> GetOwnersWithUsers();
    }
}

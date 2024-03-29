﻿using System.Linq;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public interface ILesseeRepository : IGenericRepository<Lessee>
    {
        IQueryable<Lessee> GetLesseesWithUsers();
    }
}

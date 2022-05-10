using AppCore.DataAccess.Bases.EntityFramework;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public abstract class CityRepositoryBase : RepositoryBase<City>
    {
        protected CityRepositoryBase(DbContext db) : base(db)
        {

        }
    }

    public class CityRepository : CityRepositoryBase
    {
        public CityRepository(DbContext db) : base(db)
        {

        }
    }
}

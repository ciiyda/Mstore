using AppCore.DataAccess.Bases.EntityFramework;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public abstract class SingerRepositoryBase:RepositoryBase<Singer>
    {
        protected SingerRepositoryBase(DbContext db) : base(db)
        {

        }
    }

    public  class SingerRepository : SingerRepositoryBase
    {
        public SingerRepository(DbContext db) : base(db)
        {

        }
    }

}

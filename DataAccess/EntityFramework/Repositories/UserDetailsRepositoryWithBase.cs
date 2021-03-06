using AppCore.DataAccess.Bases.EntityFramework;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public abstract class UserDetailsRepositoryBase : RepositoryBase<UserDetails>
    {
        protected UserDetailsRepositoryBase(DbContext db) : base(db)
        {

        }
    }

    public class UserDetailsRepository : UserDetailsRepositoryBase
    {
        public UserDetailsRepository(DbContext db) : base(db)
        {

        }
    }
}

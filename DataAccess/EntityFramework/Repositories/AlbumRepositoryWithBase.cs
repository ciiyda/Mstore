using AppCore.DataAccess.Bases.EntityFramework;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public abstract class AlbumRepositoryBase : RepositoryBase<Album>
    {
        protected AlbumRepositoryBase(DbContext db) : base(db)
        {

        }
    }

    public class AlbumRepository : AlbumRepositoryBase
    {
        public AlbumRepository(DbContext db) : base(db)
        {

        }
    }
}

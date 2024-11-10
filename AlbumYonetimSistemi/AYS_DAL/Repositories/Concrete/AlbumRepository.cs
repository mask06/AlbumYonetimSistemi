using AYS_DAL.Entities.Concrete;
using AYS_DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.Repositories.Concrete
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly DbContext _dbContext;
        private bool _disposed;
        public AlbumRepository(DbContext dbcontext) : base(dbcontext)
        {
           _dbContext = dbcontext;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using AYS_DAL.Repositories.Abstract;
using AYS_DAL.Repositories.Concrete;
using AYS_DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace AYS_DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        private bool _disposed = false;

        public UnitOfWork(DbContext dbContext)
        {
            // ctor içerisinde repoların bir örnekleri alındı 
            _dbContext = dbContext;
            Albums = new AlbumRepository(_dbContext);
            Admins = new AdminRepository(_dbContext);
        }

        public IAlbumRepository Albums
        {
            get;
            private set;
        }

        public IAdminRepository Admins
        {
            get;
            private set;
        }

        public int complete()
        {
            int affectedRows = _dbContext.SaveChanges();
            return affectedRows;
        }

        public void Dispose(bool disposing)
        {

            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    Admins.Dispose();
                    Albums.Dispose();
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

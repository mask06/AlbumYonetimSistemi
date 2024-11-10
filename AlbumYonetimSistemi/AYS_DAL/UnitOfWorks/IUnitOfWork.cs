using AYS_DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.UnitOfWorks
{
    // unitofWork repositoryleri yöneten bir yapı sağlar
    public interface IUnitOfWork : IDisposable
    {
        // AlbumRepository ile uow üzerinden repolara erişim sağlanır
        IAlbumRepository Albums
        {
            get;
        }
        // AdminRepository ile uow üzerinden repolara erişim sağlanır.
        IAdminRepository Admins
        {
            get;
        }

        // ilk tanımlaması burda yapılan bu yapı değişiklikleri kaydeder ve etkilenen satır sayısını döner.
        int complete();
    }
}

using AYS_DAL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.Repositories.Abstract
{
    public interface IAlbumRepository : IRepository<Album>, IDisposable
    {
        // bu alanın boş bırakılmasının sebebi IRepository içerisinde Tüm işlemlerin yapılıyor olması
    }
}

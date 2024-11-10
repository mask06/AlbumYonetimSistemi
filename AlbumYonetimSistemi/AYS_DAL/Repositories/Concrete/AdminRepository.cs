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
    // AdminRepository sınıfı, Admin varlıkları ile ilgili veri erişim işlemlerini yönetir.
    // Repository pattern'ını uygular ve IAdminRepository arayüzünü gerçekleştirir.
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private DbContext _dbContext; // DbContext örneği, veri tabanı ile etkileşimde kullanılır.
        private bool _disposed = false; // Dispose işlemi kontrolü için bayrak.

        // Constructor: Yeni bir AdminRepository örneği oluşturulduğunda DbContext başlatılır.
        public AdminRepository(DbContext context) : base(context)
        {
            _dbContext = context; // Context atanır.
        }

        // Dispose metodu: Kaynakları serbest bırakmak için kullanılır.
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // Managed kaynakları serbest bırak.
                    _dbContext.Dispose(); // DbContext'i dispose et.
                }
            }
            this._disposed = true; // Dispose işlemi yapıldığını işaretle.
        }

        // IDisposable arayüzünden gelen Dispose metodu.
        public void Dispose()
        {
            Dispose(true); // Dispose işlemini çağır.
            GC.SuppressFinalize(this); // Çöp toplayıcıya, nesnenin sonlandırıcısını çağırmaması için bildirimde bulun.
        }
    }
}

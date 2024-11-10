using AYS_DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.Repositories.Abstract
{
    // Burada IRepository Tentity türünden veriler alır ve işi bittiğinde ise serbest bırakılır
    // where TEntity : BaseEntity ise TEntity yapısının mutlaka BaseEntityden türeyen bir yapı olaması koşuludur.
    public interface IRepository<TEntity>:IDisposable where TEntity : BaseEntity
    {
        public void Create(TEntity entity);
        public void Update(TEntity entity);
        // Delete yapısı Soft delete Yapıyor yani veri tabanından silmeyip status ü delete e çekiyor
        public void Delete(TEntity entity);
        // Remove Hard Delete yapıyor veritabanından da siliyor
        public void Remove(TEntity entity);
        public ICollection<TEntity> GetAll();
        public TEntity GetById(int id);
        public ICollection<TEntity> Search(Expression<Func<TEntity, bool>>conditions);
    }
}

using AYS_DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AYS_DAL.Repositories.Abstract
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entities;
        private bool disposed = false;

        protected Repository(DbContext dbcontext)
        {
            _dbContext = dbcontext;
            _entities = _dbContext.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            // burada gelen entity isactivelik durumu true oluyor ve bu veri ekleniyor
            entity.IsActive = true;
            _entities.Add(entity);
        }
        // Delete Yapısı soft delete olduğundan sadece durumu silindi olarak güncellenir.
        public void Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.IsActive = false;
            Update(entity);

        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // where linq sorgusu ile deletedate i null olan yani silinmemiş verileri liste şeklinde döndürür
        // ve asNoTracking ile bu gelen verilerin izlenme durumunu devre dışı bırakır.
        public ICollection<TEntity> GetAll()
        {
            return _entities.AsNoTracking().Where(e => e.DeletedDate == null).ToList();
        }

        public TEntity GetById(int id)
        {
           return _entities.AsNoTracking().SingleOrDefault(e => e.Id == id);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        // Burada silinmemiş verilerin arasında belli bir condition a göre aramak yapmak üzere bir yapı hazırlanır
        // compile methodu gelen filtre sorgusunu func a uygun formata çevirir.
        public ICollection<TEntity> Search(Expression<Func<TEntity, bool>> conditions)
        {
            return _entities.AsNoTracking().Where(e=>e.DeletedDate== null).Where(conditions.Compile()).ToList();
        }

        // Bu kod bloğu, verilen entity nesnesinin veritabanında mevcut olup olmadığını kontrol eder;
        // mevcutsa Created tarihini korur, değilse Created tarihini o anki zamana(DateTime.Now) ayarlar.
        // Ardından, Modified alanına güncel zaman atanarak varlığın en son güncellenme zamanı belirlenir
        // ve IsActive alanı true olarak ayarlanarak varlığın aktif olduğu işaretlenir.
        // Son olarak _entities.Update(entity) ile entity nesnesi veritabanında güncellenmek üzere işaretlenir.
        public void Update(TEntity entity)
        {
            var existingEntity = GetById(entity.Id);
            if (existingEntity != null)
            {
                entity.CreatedDate = existingEntity.CreatedDate;
            }
            else
            {
                entity.CreatedDate = DateTime.Now;
            }
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = true;
            _entities.Update(entity);
        }
    }
}

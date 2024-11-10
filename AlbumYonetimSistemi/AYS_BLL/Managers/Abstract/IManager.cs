using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AYS_BLL.Managers.Abstract
{
    /// <summary>
    /// Burada TModel ile IManager Inteface ini generic hale getiriyoruz 
    /// Yani albüm için ayrı admin için ayrı manager üretmek yerine referans tipli bir yapı
    /// manager ınterfaceni kullanabilir demiş oluyoruz
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IManager<TModel> where TModel : class
    {
        public void Create(TModel model);
        public void Update(TModel model);
        // Delete yapısı Soft delete Yapıyor yani veri tabanından silmeyip status ü delete e çekiyor
        public void Delete(TModel model);
        // Remove Hard Delete yapıyor veritabanından da siliyor
        public void Remove(TModel model);
        
        int save();
        // GetAll yapısı veritabanındaki tüm Tmodel türündeki yani kullanılan yere göre değişen yapıyı döndürür.
        // ICollection kullanılmasının amacı tüm verileri tek seferde çekip üzerinde crud işlemlerini yapmak istememiz
        // IQuaryable yapısı bellek dostu olabilir fakat ekleme silme işlemleri yapmaya izin vermez
        public ICollection<TModel> GetAll();
        // Gelen ID ye göre Tmodel Dönen yapı
        public TModel GetById(int id);
        // Arama yapmayı amaçlayan bir metottur. içerisine parametre olarak sql sorgusuna dönüşebilen bir yapı alır 
        // ve istenilen duruma(koşula) göre arama işlemi gerçekleştirir.
        public ICollection<TModel> Search(Expression<Func<TModel, bool>> conditions);
    }
}

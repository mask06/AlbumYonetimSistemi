using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.Services.Abstract
{
    // burada IService yapısı TModel türündeki veriler ile çalışır ve burada crud işlemleri tanımlamaları gerçekleşir.
    public interface IService<TModel>:IDisposable where TModel : class
    {
        public void Create(TModel model);
        public void Update(TModel model);
        public void Delete(TModel model);
        public void Remove(TModel model);
        public ICollection<TModel> GetAll();
        public TModel GetBYId(int id);
        public ICollection<TModel> Search(Expression<Func<TModel, bool>> condition);
        int Save();
    }
}

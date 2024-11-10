using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AYS_DAL.Data;
using AYS_DAL.Entities.Abstract;
using AYS_DAL.Repositories.Abstract;
using AYS_DAL.UnitOfWorks;
using System.Linq.Expressions;

using IConfigurationProvider = AutoMapper.IConfigurationProvider;


namespace AYS_DAL.Services.Abstract
{
    // servis katmanı genel bir hizmet katmanıdır 
    // Model ve Entity arasındaki dönüşümü yapar
    public class Service<TModel, TEntity> : IDisposable, IService<TModel> 
        where TModel : class 
        where TEntity : BaseEntity
    {
        private protected readonly IUnitOfWork _unitOfWork;
        private protected IRepository<TEntity> _repository;
        // automapper konfigurasyonu
        private IConfigurationProvider _configuration;
        // dönüşümler için kullanılan automapper örneği
        private IMapper _mapper;
        private bool disposed = false;

        public Service()
        {
            AYS_DBContext dB_AYSContext = new AYS_DBContext();
            _unitOfWork = new UnitOfWork(dB_AYSContext);

            // konfigurasyon ayarlarında Tmodel Tentity türlerini karşılıklı olarak dönüştümeyi belirtiyoruz
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping().CreateMap<TModel, TEntity>().ReverseMap();
            });
            _mapper = new Mapper(_configuration);
        }
        public void Create(TModel model)
        {
            // TModel olarak gelen Yapıyı TEntity Formatına çeviyoruz
            TEntity entity = _mapper.Map<TEntity>(model);
            //Çevirilen TEntity Yapısını Repositorynin Create Methoduna gönderiyoruz
            _repository.Create(entity);
        }

        public void Delete(TModel model)
        {
            // TModel olarak gelen Yapıyı TEntity Formatına çeviyoruz
            TEntity entity = _mapper.Map<TEntity>(model);
            //Çevirilen TEntity Yapısını Repositorynin Delete Methoduna gönderiyoruz
            _repository.Delete(entity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Managed kaynakları serbest bırak.
                    _unitOfWork.Dispose(); // UnitOfWork serbest bırakılır.
                    _repository.Dispose(); // Repository serbest bırakılır.
                }
            }
            this.disposed = true; // Dispose işlemi yapıldığını işaretle.
        }
        public void Dispose()
        {
            Dispose(true); // Dispose işlemini çağır.
            GC.SuppressFinalize(this); // Çöp toplayıcıya, nesnenin sonlandırıcısını çağırmaması için bildirimde bulun.
        }

        public ICollection<TModel> GetAll()
        {
            // GetAll ile gelen tüm verileri TEntity FOrmatında Alıyoruz
            ICollection<TEntity> entities = _repository.GetAll();
            // gelen verileri model formatına çeviriyoruz Crud işlemlerinin aksine burada tersine bir hareket
            // söz konusu yani Database den Modele bir geçiş var
            ICollection<TModel> models = _mapper.Map<ICollection<TModel>>(entities);
            return models;
        }

        public TModel GetBYId(int id)
        {
            // repodan gelen veri TEntity türünde bir değişkende tutuluyor
            TEntity entity = _repository.GetById(id);
            // ardından bu veri Model Türüne dönüştürülüyor
            // çünkü burada da aynı şekilde Databaseden Model türüne bir geçiş var
            TModel model = _mapper.Map<TModel>(entity);
            return model;
        }

        public void Remove(TModel model)
        {
            // TModel türünde gelen veriyi Databaseden silebilmek için gerek veri tipi olan TEntity 
            // türüne dönüştürüyoruz
            TEntity entity = _mapper.Map<TEntity>(model);
            _repository.Remove(entity);
        }

        public int Save()
        {
            return _unitOfWork.complete();
        }

        public ICollection<TModel> Search(Expression<Func<TModel, bool>> condition)
        {
            Expression<Func<TEntity, bool>> expression = _mapper.Map<Expression<Func<TEntity, bool>>>(condition); // Koşul ifadesi varlığa dönüştürülür.
            ICollection<TEntity> search = _repository.Search(expression); // Repository üzerinden arama yapılır.

            return _mapper.Map<ICollection<TModel>>(search); // Varlıklardan modellere dönüşüm yapılır ve döner.
        }

        public void Update(TModel model)
        {
            // Tmodel türünde gelen Veriyi Güncelleyebilmek için gerek veriTipi olan Tentity Türüne dönüştürüyoruz
            TEntity entity = _mapper.Map<TEntity>(model);
            _repository.Update(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.Entities.Abstract
{
    /// <summary>
    ///  Bu interface yapısında genel entity yapısının ortak işlemleri yer alır.
    /// </summary>
    public interface IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate
        { get; set; }
        /// <summary>
        /// DateTime? ifadesi zorunlu olarak değer atanmasını geçersiz kılar yani bu property null değer alabilir.
        /// </summary>
        public DateTime? ModifiedDate
        { get; set; }
        public DateTime? DeletedDate
        { get; set; }
    }
}

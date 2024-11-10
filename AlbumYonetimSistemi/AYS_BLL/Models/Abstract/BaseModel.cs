using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_BLL.Models.Abstract
{
    public abstract class BaseModel
    {
        // Burada model içerisinde ortak olan yapılar kalıtım verecek abs sınıfa yazıldı.
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Update { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Deleted { get; set; }
    }
}

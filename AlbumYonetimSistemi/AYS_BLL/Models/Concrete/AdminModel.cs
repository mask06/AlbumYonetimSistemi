using AYS_BLL.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_BLL.Models.Concrete
{
    // admin yapısının alacağı proplar 
    public class AdminModel : BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}

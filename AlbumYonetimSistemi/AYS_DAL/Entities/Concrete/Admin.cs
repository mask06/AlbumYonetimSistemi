using AYS_DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.Entities.Concrete
{
    public class Admin : BaseEntity
    {
        /// <summary>
        ///  Burada admin entitysi BaseEntity üzerinden kalıtım alır ve onun özellikleri taşır
        ///  column ifadesi name kolonun nvarchar olacağını ve max 25 karakter içereceğini belirtir.
        /// </summary>
        [Column(TypeName = "nvarchar(25)")]
        public string Name
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
    }
}

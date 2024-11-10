using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_BLL.Models.Concrete
{
    // album yapısının alacağı proplar
    public class AlbumModel
    {
        public string Name
        {
            get; set;
        }
        public string Artist
        {
            get; set;
        }
        public DateOnly ReleaseDate
        {
            get; set;
        }
        public decimal Price
        {
            get; set;
        }
        public decimal Discount
        {
            get; set;
        }
        public bool Status
        {
            get; set;
        }
    }
}

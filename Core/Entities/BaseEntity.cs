using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    // BaseEntity isimli bu class aracılığı ile tüm entitylerde ortak olabilecek özellikleri bir arada topluyoruz.
    // Bu gibi benzer durumlar için Core ismini verip bir class library daha projemize dahil ettik.
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

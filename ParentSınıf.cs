using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapMagazası2
{
   public abstract class ParentSınıf
    {
       
        public DateTime KayıtTarihi { get; set; }
        public DateTime GüncellemeTarihi { get; set; }
        const int MIN_ID = 10000;
        const int MAX_ID = 100000;
        public int Id { get; set; }
        public ParentSınıf()
        {
            Random rastgele = new Random();
            Id = rastgele.Next(MIN_ID, MAX_ID);

        
            KayıtTarihi = DateTime.Now; //oluştuğu andaki tarihi ekler başlatır
            GüncellemeTarihi = DateTime.Now;


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapMagazası2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Kitap yeniKitap = new Kitap("kitap 1",KitapTipiEnums.ROMAN,45.2,5,35);
             Kitap.KitapEkle(yeniKitap);
             Kitap yeniKitap2 = new Kitap("kitap 2", KitapTipiEnums.BIYOGRAFI, 50.2, 5, 40);
             Kitap.KitapEkle(yeniKitap2);*/
            // yeniKitap.Isim = "kitap 1";
            //  yeniKitap.Tip = KitapTipiEnums.ROMAN;
            // yeniKitap.MaliyetFiyati = 60.55;
            //  yeniKitap.VergiOranı = 1;
            // yeniKitap.KarOranı = 30;
            // yeniKitap.StokAdedi = 5; kitap classında metot yazdığımız için sürekli bu şekilde yazmaya gerek yok


            // yeniKitap.SonFiyat = yeniKitap.MaliyetFiyati + ((yeniKitap.MaliyetFiyati * yeniKitap.VergiOranı) / 100) + ((yeniKitap.MaliyetFiyati * yeniKitap.KarOranı) / 100);

            /*  foreach(Kitap  kitap in Kitap.KitapListesi)
              {
                  Console.WriteLine(" kitap id: {0} isim : {1} maliyet : {2} fiyat : {3} ", kitap.Id, kitap.Isim, kitap.MaliyetFiyati,kitap.SonFiyat);
              }*/

            int secim = 0;
            while (secim != 7)
            {
                Console.WriteLine("1-kitap ekle"); 
                Console.WriteLine("2-kitap silme");
                Console.WriteLine("3-kitap güncelle");
                Console.WriteLine("4-kitap satışı");
                Console.WriteLine("5-kitap listele");
                Console.WriteLine("6-kitap ara ");
                Console.WriteLine("7-kasa hareketleri");
                Console.WriteLine("8-çıkış");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("lütfen yapmak istediğiniz işlemi seçiniz!!!!");
                Console.WriteLine(new string('-', 50));
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        Console.Write("lütfen kitap adını giriniz :");
                        string KitapAdi = Console.ReadLine();
                        Console.Write("kitap tipi 0-4 : ");
                        int KitapTipi = Convert.ToInt32(Console.ReadLine());

                        Console.Write("kitap maliyeti : ");
                        int KitapAdedi = Convert.ToInt32(Console.ReadLine());
                        Console.Write("kitap adedi : ");
                        int KitapMaliyeti = Convert.ToInt32(Console.ReadLine());
                        Console.Write("kar oranı : ");
                        int karOrani = Convert.ToInt32(Console.ReadLine());
                        Console.Write("vergi oranı : ");
                        int vergiOrani = Convert.ToInt32(Console.ReadLine());

                        Kitap yeniKitap = new Kitap(KitapAdi, (KitapTipiEnums)KitapTipi, KitapMaliyeti,KitapAdedi,karOrani, vergiOrani);
                        Kitap.KitapEkle(yeniKitap);
                        break;
                    case 2:
                        Kitap.kitapSilme();
                      
                        break;
                    case 3:
                        Kitap.kitaplariGüncelle();
                        break;
                    case 4:
                       Kitap.kitapSatis();
                        // kitap alındığı zaman gelir olarak geçecek. bunları yap
                        break;
                    case 5:
                        Kitap.kitaplariListele();
                        break;
                    case 6:
                        Kitap.kitapArama();
                        break;
                    case 7:
                        KasaHareketi.kasaHareketleriniListele();
                        // gelir ve gider hesaplanacak görülecek.bunları yap

                        break;

                    default:
                        break;
                }

            }
            Console.ReadLine();
           
        }

    }
}

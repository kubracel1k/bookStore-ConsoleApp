using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapMagazası2
{

    public class KasaHareketi : ParentSınıf
    {
        public static List<KasaHareketi> KasaHareketleri { get; set; } = new List<KasaHareketi>();
        public KasaHareketTipiEnums Tip { get; set; }
        public double Tutar { get; set; }

        //yapıcı metot
        public KasaHareketi(KasaHareketTipiEnums _tip,double _tutar)
        {
            Tip = _tip;
            Tutar = _tutar;

        }

        public static void kasaHareketiEkle(KasaHareketi kasaHareketi)
        {
            KasaHareketleri.Add(kasaHareketi);
        }
        public static double toplamTutarıHesapla(int adet,double birimFiyati)
        {
            return birimFiyati * adet;
        }
        public static void kasaHareketleriniListele()
        {
            Console.WriteLine("kasa hareketleri ");
            double kasaToplam = 0;
            foreach(KasaHareketi kasaHareketi in KasaHareketleri)
            {
                Console.WriteLine(new string('-', 50));
                if (kasaHareketi.Tip==KasaHareketTipiEnums.MASRAF)
                {
                    kasaToplam -= kasaHareketi.Tutar;

                }
                else
                {
                    kasaToplam += kasaHareketi.Tutar;
                }
                Console.WriteLine(kasaHareketi.ToString());

              //  Console.WriteLine("Id : {0} tip : {1} tutar : {2} kayıt tarihi : {3}",kasaHareketi.Id,kasaHareketi.Tip,kasaHareketi.Tutar,kasaHareketi.Tutar);
            }
            Console.WriteLine("kasa tutarı toplam : "+kasaToplam);
        }
        public override string ToString()
        {
            return string.Format(" Id:{0} - Tip: {1} - " + "tutar:{2} - kayıt tarihi: {3}", Id,Tip, Tutar, KayıtTarihi);
        }
        public static void kitapSatis1(int kitapID, int kitapStok)
        {
            foreach (Kitap kitap in Kitap.KitapListesi)
            {
                if (kitap.Id == kitapID)
                {
                    if (kitap.StokAdedi >= kitapStok)
                    {
                        // adetin satıldığında azalması
                        kitap.StokAdedi = kitap.StokAdedi - kitapStok;
                        //satış tutarı

                        double satisTutar = KasaHareketi.toplamTutarıHesapla((int)kitap.SonFiyat, kitapStok);

                        KasaHareketi kasaHareketi = new KasaHareketi(KasaHareketTipiEnums.GELiR,satisTutar);
                        KasaHareketi.kasaHareketiEkle(kasaHareketi);
                    }
                }
            }

        }
        
    }
}

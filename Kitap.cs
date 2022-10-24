using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapMagazası2
{


    public class Kitap : ParentSınıf
    {
        public static List<Kitap> KitapListesi { get; set; } = new List<Kitap>();

        public string Isim { get; set; }
        public KitapTipiEnums Tip { get; set; }
        public double MaliyetFiyati { get; set; }
        public int VergiOranı { get; set; }
        public int KarOranı { get; set; }
        public double SonFiyat { get; set; }
        public int StokAdedi { get; set; }

        //yapıcı metot
        public Kitap(string _isim, KitapTipiEnums _tip, double _maliyetFiyatı, int _stokAdedi, int _karOranı = 30, int _vergiOranı = 1)
        {
            Isim = _isim;
            Tip = _tip;
            MaliyetFiyati = _maliyetFiyatı;
            StokAdedi = _stokAdedi;
            KarOranı = _karOranı;

            SonFiyat = sonFiyatHesapla(_maliyetFiyatı, _vergiOranı, _karOranı);
        }
        // matematiksel, aritmetik hesapları daha çok metotlara yükleriz oraya yazarız.

        public static double sonFiyatHesapla(double maliyetFiyati, int vergiOrani, int karOrani)
        {
            return maliyetFiyati + ((maliyetFiyati * vergiOrani) / 100) + ((maliyetFiyati * karOrani) / 100);
        }
        public static void KitapEkle(Kitap eklenecekKitap)
        {
            KitapListesi.Add(eklenecekKitap);
            double tutar = KasaHareketi.toplamTutarıHesapla(eklenecekKitap.StokAdedi, eklenecekKitap.MaliyetFiyati);
            //harcama yapıyoruz kasaya eklemeli
            KasaHareketi kasaHareketi = new KasaHareketi(KasaHareketTipiEnums.MASRAF, tutar);
            KasaHareketi.kasaHareketiEkle(kasaHareketi);


        }
        public static void kitaplariListele()
        {
            foreach (Kitap kitap in KitapListesi)
            {
                Console.WriteLine(" kitap id: {0} isim : {1} maliyet : {2} fiyat : {3} : adet : {4} ", kitap.Id, kitap.Isim, kitap.MaliyetFiyati, kitap.SonFiyat, kitap.StokAdedi);
            }
        }

        public static void kitaplariGüncelle()
        {
            kitaplariListele();
            Console.WriteLine("güncellemek istediğiniz kitabın numarasını giriniz : ");
            int updateID = Convert.ToInt32(Console.ReadLine());
            foreach (Kitap item in KitapListesi)
            {
                if (item.Id == updateID)
                {
                    int secim = 0;
                    while (secim != 7)
                    {
                        Console.WriteLine("1 -  Kitap Adı : ");
                        Console.WriteLine("2 -  Maliyet Fiyatı : ");
                        Console.WriteLine("3 -  Kitap Türü : ");
                        Console.WriteLine("4 -  Vergi Oranı : ");
                        Console.WriteLine("5 -  Kar Oranı : ");
                        Console.WriteLine("6 -  Kitap Adedi : ");
                        Console.WriteLine("7 -  Güncellemeden Çıkmak İstiyorum.");
                        Console.Write("Güncellemek istediğiniz özellik : ");
                        secim = Convert.ToInt32(Console.ReadLine());

                        switch (secim)
                        {
                            case 1:
                                Console.WriteLine("yeni kitap adı giriniz : ");
                                string yeniIsim = Console.ReadLine();
                                foreach (Kitap kitap in KitapListesi)
                                {
                                    item.Isim = yeniIsim;
                                    Console.WriteLine(kitap.ToString());

                                    Console.WriteLine("Başarıyla Güncellendi!!!");
                                    Console.WriteLine(new string('-', 50));
                                }
                                break;
                            case 2:
                                Console.WriteLine("yeni maliyet giriniz : ");
                                double yeniMaliyet = Convert.ToDouble(Console.ReadLine());

                                item.MaliyetFiyati = yeniMaliyet;
                                item.SonFiyat = sonFiyatHesapla(yeniMaliyet, item.VergiOranı, item.KarOranı);

                                Console.WriteLine("maliyet fiyatı güncellendi..");
                                Console.WriteLine(new string('-', 50));
                                break;
                            case 3:
                                Console.WriteLine("yeni bir tür giriniz (0-4) : ");
                                int yeniTip = Convert.ToInt32(Console.ReadLine());
                                foreach (Kitap kitap in KitapListesi)
                                {
                                    item.Tip = (KitapTipiEnums)yeniTip;
                                    Console.WriteLine(kitap.ToString());

                                    Console.WriteLine("kitap türü  güncellendi..");
                                    Console.WriteLine(new string('-', 50));



                                }
                                break;
                            case 4:
                                Console.WriteLine("yeni vergi oranı giriniz : ");
                                int yeniVergiOranı = Convert.ToInt32(Console.ReadLine());
                                foreach (Kitap kitap in KitapListesi)
                                {
                                    item.VergiOranı = yeniVergiOranı;
                                    item.SonFiyat = sonFiyatHesapla(yeniVergiOranı, item.VergiOranı, item.KarOranı);
                                    Console.WriteLine(kitap.ToString());

                                    Console.WriteLine("vergi oranı  güncellendi..");
                                    Console.WriteLine(new string('-', 50));

                                }

                                break;
                            case 5:
                                Console.WriteLine("yeni kar oranı giriniz : ");
                                int yeniKarOranı = Convert.ToInt32(Console.ReadLine());
                                foreach (Kitap kitap in KitapListesi)
                                {
                                    item.KarOranı = yeniKarOranı;
                                    item.SonFiyat = sonFiyatHesapla(yeniKarOranı, item.VergiOranı, item.KarOranı);
                                    Console.WriteLine(kitap.ToString());

                                    Console.WriteLine("kar oranı güncellendi..");
                                    Console.WriteLine(new string('-', 80));

                                }
                                break;
                            case 6:
                                Console.WriteLine("yeni kitap adedi : ");
                                int yeniAdet = Convert.ToInt32(Console.ReadLine());
                                foreach (Kitap kitap in KitapListesi)
                                {
                                    item.StokAdedi = yeniAdet;
                                    Console.WriteLine(kitap.ToString());

                                    Console.WriteLine("stok adedi güncellendi..");
                                    Console.WriteLine(new string('-', 80));


                                }

                                break;
                            case 7:
                                continue;

                            default:
                                break;
                        }
                    }
                }
            }
        }
        public static void kitapSatis()
        {
            kitaplariListele();
            Console.WriteLine("kitap ID'si giriniz : ");
            int satinAlinanKitapID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kitap Miktarını giriniz: ");
            int kitapAdeti = Convert.ToInt32(Console.ReadLine());
            KasaHareketi.kitapSatis1(satinAlinanKitapID, kitapAdeti);
            kitaplariListele();
        }
        public static void kitapArama() //aratılan kitap var veya yok diye yazılacak*
        {
            kitaplariListele();
            Console.WriteLine("aramak istediğiniz kitabı yazınız :");
            string bookName = Console.ReadLine();
            Console.WriteLine("arattığınız kitap : " + bookName);

            Console.WriteLine(new string('-', 50));
            foreach (Kitap kitap in KitapListesi)
            {
                int bookId=Convert.ToInt32(Console.ReadLine());
               
                if (bookId >=kitap.Id && bookId<=kitap.Id) //(kitap.Isim.ToUpper().Contains(bookName.ToUpper()))
                {

                    Console.WriteLine("aradığınız kitap mevcuttur.");

                }
                else
                {
                    Console.WriteLine("aradığınız kitap yoktur.");
                }
            }
        }
        public static void kitapSilme()
        {
            kitaplariListele();
            Console.Write("Silmek istediğiniz kitap ID: ");
            int bookID = Convert.ToInt32(Console.ReadLine());
            Kitap.removeKitap(bookID);
        }
        public static void removeKitap(int ID)
        {
            foreach (Kitap book in KitapListesi)
            {
                if (book.Id == ID)
                {
                    KitapListesi.Remove(book);
                    break;
                }
            }
        }
    }
}

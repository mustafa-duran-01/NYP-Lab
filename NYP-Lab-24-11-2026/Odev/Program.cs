using System;
using System.Collections.Generic;

namespace NYPLabOdev
{
    enum CihazTuru
    {
        Lamba,
        Klima,
        GuvenlikSistemi
    }

    class Cihaz
    {
        public int Kimlik { get; set; }
        public string Ad { get; set; }
        public CihazTuru Tur { get; set; }
        public bool AcikMi { get; private set; }

        public Cihaz(int kimlik, string ad, CihazTuru tur)
        {
            Kimlik = kimlik;
            Ad = ad;
            Tur = tur;
            AcikMi = false;
        }

        public void Ac()
        {
            AcikMi = true;
        }

        public void Kapat()
        {
            AcikMi = false;
        }

        public void BilgileriGoster()
        {
            string durum = AcikMi ? "Açık" : "Kapalı";
            Console.WriteLine($"Kimlik: {Kimlik} | Ad: {Ad} | Tür: {Tur} | Durum: {durum}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cihaz> cihazlar = new List<Cihaz>
            {
                new Cihaz(1, "Salon Lambası", CihazTuru.Lamba),
                new Cihaz(2, "Oda Kliması", CihazTuru.Klima),
                new Cihaz(3, "Kapı Güvenliği", CihazTuru.GuvenlikSistemi)
            };

            while (true)
            {
                Console.WriteLine("\n--- Akıllı Ev Cihaz Yönetimi ---");
                Console.WriteLine("1 - Cihazları Listele");
                Console.WriteLine("2 - Yeni Cihaz Ekle");
                Console.WriteLine("3 - Cihaz Aç");
                Console.WriteLine("4 - Cihaz Kapat");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            cihaz.BilgileriGoster();
                        }
                        break;

                    case "2":
                        Console.Write("Cihaz kimliği: ");
                        if (!int.TryParse(Console.ReadLine(), out int yeniKimlik))
                        {
                            Console.WriteLine("Geçersiz kimlik girdiniz.");
                            break;
                        }

                        if (CihazBul(cihazlar, yeniKimlik) != null)
                        {
                            Console.WriteLine("Bu kimliğe sahip bir cihaz zaten mevcut.");
                            break;
                        }

                        Console.Write("Cihaz adı: ");
                        string yeniAd = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(yeniAd))
                        {
                            Console.WriteLine("Cihaz adı boş olamaz.");
                            break;
                        }

                        Console.Write("Cihaz türü (1-Lamba, 2-Klima, 3-Güvenlik Sistemi): ");
                        string turSecim = Console.ReadLine();
                        CihazTuru yeniTur;

                        if (turSecim == "1")
                            yeniTur = CihazTuru.Lamba;
                        else if (turSecim == "2")
                            yeniTur = CihazTuru.Klima;
                        else if (turSecim == "3")
                            yeniTur = CihazTuru.GuvenlikSistemi;
                        else
                        {
                            Console.WriteLine("Geçersiz cihaz türü.");
                            break;
                        }

                        cihazlar.Add(new Cihaz(yeniKimlik, yeniAd.Trim(), yeniTur));
                        Console.WriteLine("Yeni cihaz eklendi.");
                        break;

                    case "3":
                        Console.Write("Açılacak cihaz kimliği: ");
                        if (!int.TryParse(Console.ReadLine(), out int acilacakKimlik))
                        {
                            Console.WriteLine("Geçersiz kimlik girdiniz.");
                            break;
                        }

                        Cihaz acilacakCihaz = CihazBul(cihazlar, acilacakKimlik);
                        if (acilacakCihaz == null)
                        {
                            Console.WriteLine("Belirtilen kimliğe sahip cihaz bulunamadı.");
                        }
                        else if (acilacakCihaz.AcikMi)
                        {
                            Console.WriteLine($"{acilacakCihaz.Ad} zaten açık.");
                        }
                        else
                        {
                            acilacakCihaz.Ac();
                            Console.WriteLine($"{acilacakCihaz.Ad} açıldı.");
                        }
                        break;

                    case "4":
                        Console.Write("Kapatılacak cihaz kimliği: ");
                        if (!int.TryParse(Console.ReadLine(), out int kapatilacakKimlik))
                        {
                            Console.WriteLine("Geçersiz kimlik girdiniz.");
                            break;
                        }

                        Cihaz kapatilacakCihaz = CihazBul(cihazlar, kapatilacakKimlik);
                        if (kapatilacakCihaz == null)
                        {
                            Console.WriteLine("Belirtilen kimliğe sahip cihaz bulunamadı.");
                        }
                        else if (!kapatilacakCihaz.AcikMi)
                        {
                            Console.WriteLine($"{kapatilacakCihaz.Ad} zaten kapalı.");
                        }
                        else
                        {
                            kapatilacakCihaz.Kapat();
                            Console.WriteLine($"{kapatilacakCihaz.Ad} kapatıldı.");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
        }

        static Cihaz CihazBul(List<Cihaz> cihazlar, int kimlik)
        {
            foreach (Cihaz cihaz in cihazlar)
            {
                if (cihaz.Kimlik == kimlik)
                {
                    return cihaz;
                }
            }
            return null;
        }
    }
}

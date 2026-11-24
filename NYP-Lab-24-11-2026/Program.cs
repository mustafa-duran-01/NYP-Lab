using System;

interface IBildirimServisi
{
    void Gonder(string mesaj);
}

interface ILoglanabilir
{
    void LogYaz(string mesaj);
}

//E-Mail IBildirimServisi
class EmailServisi : IBildirimServisi, ILoglanabilir
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine("Email gonderildi : " + mesaj);
        LogYaz(mesaj);
    }

    public void LogYaz(string mesaj)
    {
        Console.WriteLine("Email logu gonderildi : " + mesaj);
    }
}

class SmsServisi : IBildirimServisi
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine("Sms gonderildi : " + mesaj);
    }
}

class MobilBildirimServisi : IBildirimServisi
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine("Mobil bildirim gonderildi : " + mesaj);
    }
}

class SiparisServisi
{
    private IBildirimServisi bildirimServisi;

    public SiparisServisi(IBildirimServisi bildirimServisi)
    {
        this.bildirimServisi = bildirimServisi;
    }

    public void SiparisOlustur (string urunAdi)
    {
        Console.WriteLine (urunAdi + " siparisiniz olusturuldu.");

        bildirimServisi.Gonder("Siparisiniz başarıyla oluşturuldu");
    }
}

namespace NYPLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //E-mail
            IBildirimServisi email = new EmailServisi();
            SiparisServisi siparis1 = new SiparisServisi(email);
            siparis1.SiparisOlustur("Laptop");
            Console.WriteLine();

            //SMS
            IBildirimServisi sms = new SmsServisi();
            SiparisServisi siparis2 = new SiparisServisi(sms);
            siparis2.SiparisOlustur("Telefon");
            Console.WriteLine();

            //Mobil Bildirim
            IBildirimServisi mobil = new MobilBildirimServisi();
            SiparisServisi siparis3 = new SiparisServisi(mobil);
            siparis3.SiparisOlustur("Tablet");
            Console.WriteLine();
        }
    }
}

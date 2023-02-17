// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Chain Of Responsibility (CoR) isteği bir zincir boyunca iletmenizi sağlayan bir tasarım desenidir. Zincirin ilk halkası isteği alır, işler ve sonraki halkaya iletir ya da işlemi durdurabilir.
 * 
 * Sorun:
 * Bir kullanıcı -> Sipariş akışı yazmaktasınız. Sadece üye kullanıcıların sipariş vermesi gerekiyor. İşlemlerin sırayla yapılması gerektiğine karar verdiniz.
 * 1. Authenticate
 * 2. Authorize
 * 3. Validation
 * 4. Cache
 * 5. Logging <-> Exception Handling
 * 
 * 
 * Amadeus projesinde; tüm avrupada konferans veya toplantı salonu rezervasyon sistemi modülü yazacaksınız. Çok büyük bir db'niz var; her  ülkedeki operasyonlar ayrı tablolar ile yönetiliyor...
 */


LondonMeeting londonMeeting = new LondonMeeting();
BerlinMeeting berlinMeeting = new BerlinMeeting();
AmsterdamMeeting amsterdamMeeting = new AmsterdamMeeting();

londonMeeting.Next = berlinMeeting;
berlinMeeting.Next = amsterdamMeeting;

Reservation reservation = new Reservation() { City = "Amsterdam" };
londonMeeting.Confirm(reservation);


public class ReservationEventArgs
{
    public string City { get; set; }
}

public class Reservation
{
    public string City { get; set; }
    public int Participant { get; set; }
}

public abstract class Responsible
{
    public Responsible Next { get; set; }
    public EventHandler<ReservationEventArgs> ReservationConfirm;

    public abstract void ReservationConfirmHandler(object sender, ReservationEventArgs e);
    protected void OnReserved(ReservationEventArgs e)
    {
        if (ReservationConfirm != null)
        {
            ReservationConfirm(this, e);
        }
    }

    public Responsible()
    {
        ReservationConfirm += ReservationConfirmHandler;
    }
    public void Confirm(Reservation reservation)
    {
        ReservationEventArgs eventArgs = new ReservationEventArgs { City = reservation.City };
        OnReserved(eventArgs);
    }



}

public class LondonMeeting : Responsible
{
    public override void ReservationConfirmHandler(object sender, ReservationEventArgs e)
    {
        if (e.City == "London")
        {
            //tüm db ve diğer operasyonlar buradan çağrılacak...
            Console.WriteLine("Londra'da rezervasyon işşemi yapıldı");
        }
        else
        {
            Next.ReservationConfirmHandler(this, e);
        }
    }
}

public class BerlinMeeting : Responsible
{
    public override void ReservationConfirmHandler(object sender, ReservationEventArgs e)
    {
        if (e.City == "Berlin")
        {
            //tüm db ve diğer operasyonlar buradan çağrılacak...
            Console.WriteLine("Berlin'de rezervasyon işlemi yapıldı");
        }
        else
        {
            Next.ReservationConfirmHandler(this, e);
        }
    }
}

public class AmsterdamMeeting : Responsible
{
    public override void ReservationConfirmHandler(object sender, ReservationEventArgs e)
    {
        if (e.City == "Amsterdam")
        {
            //tüm db ve diğer operasyonlar buradan çağrılacak...
            Console.WriteLine("Amsterdam'da rezervasyon işlemi yapıldı");
        }
        else
        {
            //Next.ReservationConfirmHandler(this, e);
            Console.WriteLine("Bu şehir ile çalışmıyoruz.....");
        }
    }
}


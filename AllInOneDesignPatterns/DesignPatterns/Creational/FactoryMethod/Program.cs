// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


CultureMap cultureMap = new CultureMap();
cultureMap.VisitPoints.ForEach(p => Console.WriteLine(p.Icon));
Console.WriteLine("-------------------------------------------");
Console.WriteLine("İnanç haritası");

ReligionMap religionMap = new ReligionMap();
religionMap.VisitPoints.ForEach(p => Console.WriteLine(p.Icon));

//Bir nesne (harita), instance'i alınırken kendisine bağlı başka instance'ları da içermek zorundadır (ziyaret  noktaları). Bu ihtiyacı karşılamak için Factory Method pattern'i kullanılır. Constructor her çağrıldığında factory method da çağrılır.


//SORUN:
/*
 * Sadece kültürel ziyaret noktalarını gösteren bir harita uygulamanız var.
 * Projeniz çok tuttu şimdi yeni bir harita türü olarak inanç noktalarını göstermek istiyorsunuz.
 */
//Harita kultur = new KulturHaritasi();
//kultur.ZiyaretNoktalari: Bu koleksiyon dolu olacak

/*
 * 1. Factory Method ne üretecek (Product)
 */

public interface IRecommendedVisitPoint
{
    double Latitude { get; set; }
    double Longitude { get; set; }
    string Icon { get; set; }
    string APIUrl { get; set; }
}

public interface ICulturalRecommendedVisitPoint : IRecommendedVisitPoint
{
    bool IsAvailable { get; set; }
}

//2. Concrete sınıflar, farklı interface'leri implemente edebilirler.
public class Museum : ICulturalRecommendedVisitPoint
{
    public bool IsAvailable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Icon { get; set; }
    public string APIUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class Exhibiton : ICulturalRecommendedVisitPoint
{
    public bool IsAvailable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Icon { get; set; }
    public string APIUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class Mosquee : IRecommendedVisitPoint
{
    public double Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Icon { get; set; }
    public string APIUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}


//3. Oluşturucu yapı:
//Bu haritayı bellekte yaratırken, hangi ziyaret noktalarını göstereceğim?

public abstract class MapBase
{
    public List<IRecommendedVisitPoint> VisitPoints { get; set; }

    public MapBase()
    {
        VisitPoints = new List<IRecommendedVisitPoint>();
        addVisitPoints();
    }
    //Factory method:
    protected abstract void addVisitPoints();
}

//4. Oluşturucu da, farklı miras alan class'lara sahip olabilir.

public class CultureMap : MapBase
{
    protected override void addVisitPoints()
    {
        VisitPoints.Add(new Museum { Icon = "Topkapı Sarayı" });
        VisitPoints.Add(new Museum { Icon = "Yerebatan Sarnıcı" });
        VisitPoints.Add(new Exhibiton { Icon = "Reim Sergisi" });

    }
}

public class ReligionMap : MapBase
{
    protected override void addVisitPoints()
    {
        VisitPoints.Add(new Mosquee { Icon = "Sultanahmet" });
        VisitPoints.Add(new Mosquee { Icon = "Ayasofya" });
        VisitPoints.Add(new Mosquee { Icon = "Eyüp Sultan..." });
    }
}


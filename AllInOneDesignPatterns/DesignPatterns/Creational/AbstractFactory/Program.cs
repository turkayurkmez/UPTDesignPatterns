// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Map<SatelliteCultureMap> map = new Map<SatelliteCultureMap>();
map.Show();

Map<RegionalCultureMap> rgMap = new Map<RegionalCultureMap>();
rgMap.Show();

Map<SatelliteReligionMap> rgSatellite = new Map<SatelliteReligionMap>();
rgSatellite.Show();


//DB<Oracle> oracleDb = new DB<Oracle>();
//oracleDb.GetData()



//Map<SatelliteReligionMap> rgSatellite = new Map<SatelliteReligionMap>();


/*
 * Abstract Factory; doğrudan sınıf belirtmeden ilgili instance'ların tüm türlerini oluşturabilen bir tasarım deseni.
 * 
 * 
 * Sorun:
 *  Factory Method'daki senaryoda; harita türünün değişebileceğini var sayın. Uydu haritası, yol ve hibrit harita...
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


public interface IMapCreator
{
    List<IRecommendedVisitPoint> GetRecommendedVisitPoints();
    MapBase MapFormat();
    string MapStyle { get; set; }

}

public class SatelliteCultureMap : IMapCreator
{
    public string MapStyle { get; set; } = "Satellite";
    private CultureMap cultureMap = new CultureMap();
    public List<IRecommendedVisitPoint> GetRecommendedVisitPoints()
    {
        return cultureMap.VisitPoints;
    }

    public MapBase MapFormat()
    {
        return cultureMap;
    }
}

public class RegionalCultureMap : IMapCreator
{
    public string MapStyle { get; set; } = "Regional";
    private CultureMap cultureMap = new CultureMap();
    public List<IRecommendedVisitPoint> GetRecommendedVisitPoints()
    {
        return cultureMap.VisitPoints;
    }

    public MapBase MapFormat()
    {
        return cultureMap;
    }
}

public class SatelliteReligionMap : IMapCreator
{
    public string MapStyle { get; set; } = "Satellite";

    private ReligionMap religionMap = new ReligionMap();

    public List<IRecommendedVisitPoint> GetRecommendedVisitPoints()
    {
        return religionMap.VisitPoints;
    }

    public MapBase MapFormat()
    {
        return religionMap;
    }
}



public class Map<T> where T : IMapCreator, new()
{
    private T mapCreator;
    public Map()
    {
        mapCreator = new T();
    }

    public void Show()
    {
        Console.WriteLine($"Oluşturulan harita türü: {mapCreator.MapFormat().GetType().Name} - Harita stili: {mapCreator.MapStyle}");
        mapCreator.GetRecommendedVisitPoints().ForEach(p => Console.WriteLine(p.Icon));
    }

}
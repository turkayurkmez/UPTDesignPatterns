// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Bir nesneyi oluşturmak için çok aşamadan geçmeniz gerekmektedir. Her aşamayı metot olarak yazabilseniz bile, bir constructor'da bunları çağırmak kaosa sebep olabilecektir. Madem öyle her aşamayı ayrı bir nesne tamamlasın diyorsanız; Builder pattern'i kullanırsınız.
 */

/*
 *  Uygulama; db üzerinde çeşitli tablolardan veri çekerek Rapor (object) üretmektedir. Bir rapor; Başlık, Grafik, Hazırlayanlar ve İçerik bölümlerinden oluşmaktadır. 
 * 
 */

ReportCreator reportCreator = new ReportCreator();
reportCreator.Create(new SalesReportBuilder());
reportCreator.Show();
var report = reportCreator.GetReport();




public enum ReportParts
{
    Title,
    Graph,
    Sign,
    Data
}

public enum ReportType
{
    Performance,
    Sales
}

public class Report
{
    private Dictionary<ReportParts, string> parts = new Dictionary<ReportParts, string>();
    private ReportType reportType;

    public Report(ReportType reportType)
    {
        this.reportType = reportType;
    }

    public string this[ReportParts part]
    {
        get { return parts[part]; }
        set { parts[part] = value; }
    }

    public void ShowReport()
    {
        Console.WriteLine($"{reportType} türünde rapor oluşturuldu....");
        Console.WriteLine($"Rapor başlığı: {this[ReportParts.Title]}");
        Console.WriteLine($"Rapor grafiği: {this[ReportParts.Graph]}");
        Console.WriteLine($"Rapor imzası: {this[ReportParts.Sign]}");
        Console.WriteLine($"Rapor verisi: {this[ReportParts.Data]}");
    }
}

public abstract class ReportBuilder
{
    public Report Report { get; set; }

    public ReportBuilder(ReportType reportType)
    {
        Report = new Report(reportType);
    }

    public abstract void CreateTitle();
    public abstract void CreateGraph();
    public abstract void CreateSign();
    public abstract void CreateData();


}

public class PerformanceReportBuilder : ReportBuilder
{
    public PerformanceReportBuilder() : base(ReportType.Performance)
    {
    }

    public override void CreateData()
    {
        Report[ReportParts.Data] = "Çalışan performans verisi....";
    }

    public override void CreateGraph()
    {
        Report[ReportParts.Graph] = "Çalışan performans bar grafiği oluşturuldu....";

    }

    public override void CreateSign()
    {
        Report[ReportParts.Sign] = "A, B ve C kişileri tarafından hazırlandı";

    }

    public override void CreateTitle()
    {
        Report[ReportParts.Title] = "Aylara göre çalışan verim raporu";
    }
}

public class SalesReportBuilder : ReportBuilder
{
    public SalesReportBuilder() : base(ReportType.Sales)
    {
    }

    public override void CreateData()
    {
        Report[ReportParts.Data] = "Satış performans verisi....";
    }

    public override void CreateGraph()
    {
        Report[ReportParts.Graph] = "Satış performans bar grafiği oluşturuldu....";

    }

    public override void CreateSign()
    {
        Report[ReportParts.Sign] = "X, Y ve Z kişileri tarafından hazırlandı";

    }

    public override void CreateTitle()
    {
        Report[ReportParts.Title] = "Yıllık satış ciro raporu";
    }
}
public class ReportCreator
{
    private ReportBuilder reportBuilder;
    public void Create(ReportBuilder reportBuilder)
    {
        this.reportBuilder = reportBuilder;
        reportBuilder.CreateTitle();
        reportBuilder.CreateData();
        reportBuilder.CreateGraph();
        reportBuilder.CreateSign();

    }

    public void Show()
    {
        reportBuilder.Report.ShowReport();
    }
    public Report GetReport()
    {
        return reportBuilder.Report;
    }
}
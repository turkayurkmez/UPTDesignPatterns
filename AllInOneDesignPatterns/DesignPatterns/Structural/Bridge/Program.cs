// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Senaryo:
 *   Bir rapor üretim uygulaması geliştiriyorsunuz.
 *    Rapor kategorileri: Satış ve Performans vs... Her rapor, PDF veya HTML formatında yayınlanır.
 *    
 * Problem: Bir class'ı bir base class'dan türetmek; gelecekte oluşabilecek ihtiyaçları sınırlayabilir. Bu tasarım hatası bridge ile düzelebilir.    
 * 
 */
SalesReport salesReport = new SalesReport { Format = new Excel() };
PDF pdf = new PDF();
HTML html = new HTML();
salesReport.Format = pdf;
salesReport.Format = html;


public class Report
{
    public ReportFormat Format { get; set; }
}

public class PerformanceReport : Report
{

}

public class SalesReport : Report
{

}

public class ReportFormat
{

}

public class PDF : ReportFormat
{

}
public class HTML : ReportFormat
{

}

public class Excel : ReportFormat
{

}

//public class PDFPerformanceReport : PerformanceReport
//{

//}

//public class HTMLPerformanceReport : PerformanceReport
//{

//}

//public class HTMLSalesReport : SalesReport
//{

//}

//public class PDFSalesReport : SalesReport
//{

//}

//public class ExcelSalesReport: SalesReport
//{

//}

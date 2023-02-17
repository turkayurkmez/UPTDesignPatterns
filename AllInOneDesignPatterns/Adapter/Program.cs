// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
DataParser dataParser = new DataParser();
dataParser.GetProducts(new DbProvider()).ForEach(p => Console.WriteLine(p.FromProvider));
dataParser.GetProducts(new XMLProvider()).ForEach(p => Console.WriteLine(p.FromProvider));


/*
 * Problem:
 * Farklı iki kaynaktan; uygulamanız ile uyuşmayan data almaktasınız. Bu uyuşmazlığı nasıl giderirsiniz?
 * 
 * Senaryo:
 * Bir uygulama; belirtilen veri kaynağından (XML, Db vs) veri okuma işlemi yapacaktır. Birbirleriyle doğrudan ilişkisi olmayan bu iki kaynaktan veriyi adaptör pattern'i aracılığı ile okuyacağız
 */

public interface IProductDataAdapter
{
    List<Product> GetProductsFromProvider();
}

public class XMLProvider : IProductDataAdapter
{
    public List<Product> GetProductsFromProvider()
    {
        return new List<Product>() { new Product { FromProvider = "XML'den çekildi...." } };

    }
}


public class DbProvider : IProductDataAdapter
{
    public List<Product> GetProductsFromProvider()
    {
        return new List<Product>() { new Product { FromProvider = "DB'den çekildi...." } };
    }
}

public class Product
{
    public string FromProvider { get; set; }
}

public class DataParser
{
    public List<Product> GetProducts(IProductDataAdapter dataAdapter)
    {
        return dataAdapter.GetProductsFromProvider();
    }
}

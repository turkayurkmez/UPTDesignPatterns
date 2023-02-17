// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

OrderFacade orderFacade = new OrderFacade();
Customer customer = new Customer { Name = "Türkay" };
List<Product> products = new List<Product>
{
    new(){ Id =1, Name="ABC", Quantity=3},
    new(){ Id =2, Name="XYZ", Quantity=5},

};
orderFacade.CreateOrder(customer, products);

/*
 * Çok karmaşık işlemler ve nesnelerden oluşan bir işiniz var. Bu karmaşık işlere; düzen getirecek bir sınıf oluşturarak işleri basitleştirebilirsiniz.
 */

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

public class Order
{
    public Customer Customer { get; set; }
    public List<Product> OrderItems { get; set; }

    //public void AddToDb()
    //{

    //}
}

public class OrderService
{
    public int AddOrder(Customer customer, DateTime dateTime)
    {
        Console.WriteLine($"{customer.Name}, {dateTime.ToLongDateString()} tarihinde sipariş verdi");
        return 1;
    }


}

public class OrderDetailService
{
    public void AddOrderDetails(int orderId, List<Product> products)
    {
        Console.WriteLine($"{orderId} numaralı siparışte satın alınan ürünler");
        products.ForEach(p => Console.WriteLine($"{p.Name} ürününden {p.Quantity} adet"));

    }
}

public class ProductService
{
    public void UpdateStock(List<Product> products)
    {
        products.ForEach(p => Console.WriteLine($"{p.Name} ürününden {p.Quantity} adet düşürüldü..."));
    }
}

public class OrderFacade
{
    OrderService orderService = new OrderService();
    OrderDetailService orderDetailService = new OrderDetailService();
    ProductService productService = new ProductService();

    public void CreateOrder(Customer customer, List<Product> products)
    {
        var orderId = orderService.AddOrder(customer, DateTime.Now);
        orderDetailService.AddOrderDetails(orderId, products);
        productService.UpdateStock(products);

    }
}
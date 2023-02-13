// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Customer customer = new Customer { CartType = new Premium(), Name = "Türkay" };
OrderManagement orderManagement = new OrderManagement { Customer = customer };
var result = orderManagement.GetTotalPrice(1000);
Console.WriteLine(result);

//Bir nesne ..Gelişime... AÇIK .Değişime.. KAPALI olmalı

//public enum CartTypes
//{
//    Standard,
//    Silver,
//    Gold

//}

public abstract class CartType
{
    public abstract double GetDiscountedPrice(double price);

}
public class Silver : CartType
{
    public override double GetDiscountedPrice(double price)
    {
        return price * .90;
    }
}

public class Gold : CartType
{
    public override double GetDiscountedPrice(double price)
    {
        return price * .85;
    }
}


public class Standard : CartType
{
    public override double GetDiscountedPrice(double price)
    {
        return price * .95;
    }
}

public class Premium : CartType
{
    public override double GetDiscountedPrice(double price)
    {
        return price * .80;
    }
}

public class Customer
{
    public CartType CartType { get; set; }
    public string Name { get; set; }
}

public class OrderManagement
{
    public Customer Customer { get; set; }
    public double GetTotalPrice(double price)
    {
        //switch (Customer.CartType)
        //{
        //    case CartTypes.Standard:

        //        return price * 0.95;
        //    case CartTypes.Silver:
        //        return price * 0.90;
        //    case CartTypes.Gold:
        //        return price * 0.85;
        //    default:
        //        return price;

        //}

        return Customer.CartType.GetDiscountedPrice(price);


    }
}
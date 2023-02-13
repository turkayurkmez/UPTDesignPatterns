// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Bir nesne ..Gelişime... AÇIK ........Değişime...... KAPALI olmalı

public enum CartTypes
{
    Standard,
    Silver,
    Gold

}
public class Customer
{
    public CartTypes CartType { get; set; }
    public string Name { get; set; }
}

public class OrderManagement
{
    public Customer Customer { get; set; }
    public double GetTotalPrice(double price)
    {
        switch (Customer.CartType)
        {
            case CartTypes.Standard:
                break;
            case CartTypes.Silver:
                break;
            case CartTypes.Gold:
                break;
            default:
                break;
        }

        return 0;
    }
}
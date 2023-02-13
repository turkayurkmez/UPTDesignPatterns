// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Bir base class objesi ile ondan miras alan derived class objesi birbirlerinin yerine kullanılabilir olmalı.
 * 
 * 
 */
Square square = new Square { UnitLength = 10 };
Rectangle rectangle = new Rectangle { Height = 10, Width = 5 };

Console.WriteLine(rectangle.GetArea());
Console.WriteLine(square.GetArea());

var rect = GetRectangle(10, 3);
//rect.Width = 5;
//rect.Height = 10;
Console.WriteLine($"Kare alanı {rect.GetArea()}");





IAreaCalcutable GetRectangle(int unit1, int? unit2 = null)
{
    //var sayınki geriye kare döndürmeniz gerekiyor.
    if (unit2.HasValue)
    {
        return new Rectangle { Width = unit1, Height = unit2.Value };
    }
    return new Square() { UnitLength = unit1 };
}


public interface IAreaCalcutable
{
    int GetArea();
}

public class Rectangle : IAreaCalcutable
{

    public int Width { get; set; }
    public int Height { get; set; }

    public int GetArea() => Width * Height;

}

public class Square : IAreaCalcutable
{
    //public override int Width
    //{
    //    get => base.Width; set
    //    {
    //        base.Width = value;
    //        base.Height = value;
    //    }
    //}
    //public override int Height
    //{
    //    get => base.Height; set
    //    {
    //        base.Width = value;
    //        base.Height = value;
    //    }
    //}
    public int UnitLength { get; set; }

    public int GetArea() => UnitLength * UnitLength;



}
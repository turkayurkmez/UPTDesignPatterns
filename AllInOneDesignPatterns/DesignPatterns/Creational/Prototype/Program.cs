// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");
string[] words = { "A", "B", "C" };
var cloneOfWords = (string[])words.Clone();
cloneOfWords[1] = "X";

Console.WriteLine("ilk hali:");
words.ToList().ForEach(word => Console.Write(word + " "));

Console.WriteLine("klon:");
cloneOfWords.ToList().ForEach(word => Console.Write(word + "  "));
Console.WriteLine();

Console.WriteLine("Tekrar  ilk hali:");
words.ToList().ForEach(word => Console.Write(word + " "));
Console.WriteLine();

var siyah = new Renk();
var kirmizi = (Renk)siyah.Clone();
kirmizi.R = 255;
Console.WriteLine(kirmizi);

var yesil = (Renk)siyah.Clone();
yesil.G = 255;
Console.WriteLine(yesil);

var beyaz = (Renk)yesil.Clone();
beyaz.B = 255;
beyaz.R = 255;




List<bool> bools = new List<bool>();
ArrayList arrayList = new ArrayList();


Console.WriteLine(beyaz);


/*
 * Problem: Bellekte oluşturulması uzun süren (long running) bir nesneniz var. Bu sorunu aşmak için ne yaparsınız?
 * 
 */
public class Renk : ICloneable
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public Renk()
    {
        Thread.Sleep(3000);
        R = 0;
        G = 0;
        B = 0;
    }

    public override string ToString()
    {
        return $"{R}-{G}-{B}";

    }



    public object Clone()
    {
        return MemberwiseClone();
    }
}


public class Weapon
{
    public int HitPoint { get; set; }
}

public class Armor
{
    public int Health { get; set; }
}
//Aynı anda çok düşman (Red Alert)
public class Enemy : ICloneable
{
    public Weapon Weapon { get; set; }
    public Armor Armor { get; set; }

    public object Clone(bool isDeep)
    {
        if (isDeep)
        {
            //Serialize to memory

        }
        return Clone();
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}






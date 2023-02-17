// See https://aka.ms/new-console-template for more information

using System.Collections;

Console.WriteLine("Hello, World!");
/*
 * Iterator:
 * 
 * Bir koleksiyonun elemanlarını, o koleksiyonun yapısını (tree structure, linked list vs) açığa çıkarmadan kullanabilmenizi sağlayan bir pattern'dir 
 * 
 * Arama algoritmalarının temelinde linked list veya tree structure (MS SQL) vardır. Fakat aranacak alana yeni bir eleman eklendiğinde; arkada yapılan işlem gizlenir (encapsulation). 
 */

//Current -> Next -> Prev

Iterator<News> newsGallery = new Iterator<News>
{
    new News() { Title = "Güzel bir haber" },
    new News() { Title = "Türk Fizikçi nobel kazandı" },
    new News() { Title = "Türkiye ekonomide dünya lideri!" }
};

foreach (var item in newsGallery)
{
    Console.WriteLine($"{item.Title}");
}

var next = newsGallery.Next();
Console.WriteLine(next.Title);
Console.WriteLine(newsGallery.Next().Title);
Console.WriteLine(newsGallery.First().Title);
Console.WriteLine(newsGallery.Last().Title);





public class News
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime NewsDate { get; set; }
}

public class Iterator<T> : IEnumerable<T>
{
    //public T Current => throw new NotImplementedException();

    //object IEnumerator.Current => throw new NotImplementedException();

    //public void Dispose()
    //{
    //    throw new NotImplementedException();
    //}

    //public bool MoveNext()
    //{
    //    throw new NotImplementedException();
    //}

    //public void Reset()
    //{
    //    throw new NotImplementedException();
    //}

    public Iterator()
    {
        // Current = collection[0];
    }

    List<T> collection = new List<T>();
    public void Add(T item)
    {
        collection.Add(item);
        Current = collection[collection.Count - 1];
    }

    private int position = 0;

    public T Current { get; private set; }

    public T Next()
    {
        position++;
        Current = collection[position];
        return Current;
    }
    public T First()
    {
        Current = collection[0];
        return Current;
    }
    public T Last()
    {
        Current = collection[collection.Count - 1];
        return Current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in collection)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Students students = new Students();
students.SortStudent(new BubbleSortStrategy());
students.SortStudent(new Quick3SortStrategy());
students.SortStudent(new HeapSortStrategy());



public interface ISortStrategy
{
    void Sort();

}

public class BubbleSortStrategy : ISortStrategy
{
    public void Sort()
    {
        Console.WriteLine("Bubble Sort ile sıralandı");
    }
}

public class Quick3SortStrategy : ISortStrategy
{
    public void Sort()
    {
        Console.WriteLine("Quick3 Sort ile sıralandı");
    }
}

public class HeapSortStrategy : ISortStrategy
{
    public void Sort()
    {
        Console.WriteLine("Heap Sort ile sıralandı");
    }
}


public class Students
{
    public void SortStudent(ISortStrategy sortStrategy)
    {
        sortStrategy.Sort();
    }
}




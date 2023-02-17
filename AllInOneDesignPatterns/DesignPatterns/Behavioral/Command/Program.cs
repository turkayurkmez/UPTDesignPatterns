// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Tanım:
 * Command, bir isteği; bu isteği içeren bütün bilgileri tutan bir nesneye dönüştüren desendir.
 * 
 * Senaryo:
 * Bir uygulama; birden fazla komutu (müşteri-garson-yemek siparişi) biriktirebilir ve sırayla çalıştırabilir. Bu sırayı tek tek ele alma veya bir komutu iptal etme ihtiyacını karşılamak için bu pattern'i kullanabiliriz.
 */
CommandInvoker commandInvoker = new CommandInvoker();
commandInvoker.AddCommand(new DocumentCreatedOnDbCommand());
commandInvoker.AddCommand(new PrintDocumentCommand());
commandInvoker.AddCommand(new SaveDocumentCommand());

commandInvoker.ExecuteCommands();
commandInvoker.ExecuteCommands();





public interface ICommand
{

    void Execute();
}
//Editör: Save, Open, New, Undo.....

public class CommandInvoker
{

    private class Test
    {
        public string TestDesc { get; set; }
    }
    //Queue<ICommand>
    //Stack<ICommand>
    private Queue<ICommand> commands = new Queue<ICommand>();
    public void AddCommand(ICommand command) => commands.Enqueue(command);
    public void ExecuteCommands()
    {


        if (commands.Count == 0)
        {
            Console.WriteLine("Çalıştırılacak komut yok!");
        }
        while (commands.Count > 0)
        {
            var command = commands.Dequeue();
            command.Execute();
        }
    }
    public void ClearCommands() => commands.Clear();
    public void RemoveCommand(ICommand command) => commands.Clear();

}

public class SaveDocumentCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Döküman kaydedildi");
    }
}

public class PrintDocumentCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Dokümanın çıktısı alındı");
    }
}

public class DocumentCreatedOnDbCommand : ICommand
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public void Execute()
    {
        Console.WriteLine("Doküman oluştu ve dv'ye kaydedildi");
    }
}

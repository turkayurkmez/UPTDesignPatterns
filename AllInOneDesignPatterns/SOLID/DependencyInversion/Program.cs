// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Report report = new Report()



public class Report
{

    public Report(ISender sender)
    {
        mailSender = sender;
    }

    private ISender mailSender;
    public void Send()
    {
        //MailSender mailSender = new MailSender();
        mailSender.Send();
    }
}

public interface ISender
{
    void Send();
}

public class MailSender : ISender
{
    public void Send()
    {
        Console.WriteLine("Mail ile gönderildi");
    }
}

public class WhatsAppSender : ISender
{
    public void Send()
    {
        Console.WriteLine("WS ile gönderildi");
    }
}

public class TelegramSender : ISender
{
    public void Send()
    {
        Console.WriteLine("Telegram ile gönderildi");
    }
}


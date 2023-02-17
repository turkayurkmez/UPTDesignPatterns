// See https://aka.ms/new-console-template for more information
using System.IO.Compression;
using System.Net.Sockets;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

FileStream fs = null;
MemoryStream ms = null;
NetworkStream ns = null;

GZipStream gZip = new GZipStream(fs, CompressionLevel.Optimal);
CryptoStream cryptoStream = new CryptoStream(gZip, null, CryptoStreamMode.Write);
/*
 *        Kahve
 *   Sütlü Kahve     Amerikano
 *      Sekerli Kahve
 *    
 *   Sütlü ve Şekerli Kahve 
 * Kahve kahve = new Kahve(); 
 * Sutlu skahve = new Sutlu(kahve);
 * 
 */

MailMessage mailMessage = new MailMessage();
SignedMail signedMail = new SignedMail(mailMessage);
CryptoMail cryptoMail = new CryptoMail(signedMail);


public interface IMail
{
    void Send();
}
public class MailMessage : IMail
{
    public string Body { get; set; }
    public void Send()
    {
        Console.WriteLine("Mail gönderildi");
    }
}

public class SignedMail : IMail
{
    private IMail mail;
    public SignedMail(IMail mail)
    {
        this.mail = mail;
    }

    public bool IsSigned { get; set; }
    public string SignedBy { get; set; }
    public void Send()
    {
        if (IsSigned && !string.IsNullOrEmpty(SignedBy))
        {
            Console.WriteLine($"Mail {SignedBy} tarafından imzalandı");
        }
        mail.Send();
    }
}

public class CryptoMail : IMail
{

    private IMail mail;

    public CryptoMail(IMail mail)
    {
        this.mail = mail;
    }

    public void Send()
    {
        Console.WriteLine("Mail şifrelendi");
        mail.Send();
    }
}




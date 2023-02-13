namespace InterfaceSegregation
{

    public interface IPrintable
    {
        void Print();
    }
    public class PrinterComponent
    {
        public void Print(IPrintable printable)
        {
            printable.Print();
        }
    }
}

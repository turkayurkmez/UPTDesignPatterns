namespace Proxy
{
    internal class ProxyPattern
    {
        /*
         * Problem: Uzak makinede, sunucuda veya aynı makinede farklı bir uygulama doğrudan erişemediğiniz (güvenlik, data paylaşımı gibi sorunlar nedeniyle) durumlarda proxy kullanılır.
         * 
         * 
         */
    }

    public interface IMath
    {
        int Add(int x, int y);
        int Subtract(int x, int y);

    }
    public class RealMath : IMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }
    }

    public class ProxyMath : IMath
    {
        //Bu örneğe sonradan bakan dostlara not:
        //Bu RealMath sınıfının uzakta, başka bir makinede ya da başka bir uygulamada olduğunu var sayın. Yani new() ile instance'ının öyle kolayca alınamadığı bir senaryo hayal edin. Bu durumda - bu instance'ı almaya - tek yetkili ProxyMath sınıfı olacaktır.
        private RealMath realMath = new RealMath();
        public int Add(int x, int y)
        {
            return realMath.Add(x, y);
        }

        public int Subtract(int x, int y)
        {
            return realMath.Subtract(x, y);
        }
    }
}

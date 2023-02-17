namespace Proxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //srvTCKimlik.KPSPublicSoapClient kPSPublicSoapClient = new srvTCKimlik.KPSPublicSoapClient(null);

            //kPSPublicSoapClient.TCKimlikNoDogrulaAsync()

            ProxyMath proxyMath = new ProxyMath();
            var result = proxyMath.Add(3, 5);
            MessageBox.Show(result.ToString());
        }
    }
}
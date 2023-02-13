namespace SingleResponsibility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * Eğer bir nesnenin sınıfında değişiklik yapmak için birden fazla SEBEBİNİZ varsa SRP'yi ihlal ediyorsunuz demektir.
             */
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProductService productService = new ProductService();
            var name = textBoxName.Text;
            var price = decimal.Parse(textBoxPrice.Text);

            Product product = new() { Price = price, Name = name };

            var affectedRows = productService.AddProduct(product);
            var message = affectedRows > 0 ? "Kaydedildi" : "İşlem başarısız";
            MessageBox.Show(message);


        }
    }
}
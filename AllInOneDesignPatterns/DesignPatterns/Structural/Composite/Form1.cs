namespace Composite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CategoryComposite<Category> categoryComposite = new CategoryComposite<Category>();
            var bilgisayar = categoryComposite.Add(new Category("Bilgisayar"));
            var laptop = bilgisayar.Add(new Category("laptop"));
            var sesSistemi = categoryComposite.Add(new Category("ses sistemi"));
            var blueTooth = sesSistemi.Add(new Category("Bluetooth"));


            categoryComposite.Children[1].Add(new Category("5+1"));
            categoryComposite.Children.RemoveAll(x => x.Children.Any(p => p.Node.Name == "5+1"));

            CategoryComposite<Category>.Show(1, categoryComposite, treeView1);
        }
    }
}
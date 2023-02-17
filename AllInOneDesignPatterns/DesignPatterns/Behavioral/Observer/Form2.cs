namespace Observer
{
    public partial class Form2 : Form, IObserver
    {
        private ObservableColorSubscription observableColorSubscription;
        public Form2(ObservableColorSubscription observableColorSubscription)
        {
            InitializeComponent();
            this.observableColorSubscription = observableColorSubscription;
        }

        public void ChangeColor(Color color)
        {
            BackColor = color;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            observableColorSubscription.Subscribe(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            observableColorSubscription.UnSubscribe(this);
        }
    }
}

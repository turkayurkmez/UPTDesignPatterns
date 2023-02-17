namespace FlyWeight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createPlanets(panel1.CreateGraphics(), numericUpDown1.Value);
        }

        private void createPlanets(Graphics graphics, decimal value)
        {
            var colorList = new List<Color> { Color.Blue, Color.Yellow, Color.Purple, Color.Green, Color.White };
            Random random = new Random();
            for (int i = 0; i < value; i++)
            {
                Planet planet = PlanetFlyWeight.CreatePlanet(colorList[random.Next(colorList.Count)]);
                planet.X = random.Next(panel1.Width);
                planet.Y = random.Next(panel1.Height);
                planet.Radius = random.Next(2, 100);
                planet.Draw(graphics);
            }
        }
    }
}
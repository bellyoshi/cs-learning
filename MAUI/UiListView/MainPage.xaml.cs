namespace UiListView
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
            var list = new List<Card>();
            list.Add(new Card { Name = "C#" });
            list.Add(new Card { Name = "Visual Basic" });

            this.lv.ItemsSource = list;
        }

    }
    public class Card
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
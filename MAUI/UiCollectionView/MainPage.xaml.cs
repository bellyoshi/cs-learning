namespace UiCollectionView
{
    public partial class MainPage : ContentPage
    {
  

        public MainPage()
        {
            InitializeComponent();

            var cardlist = new List<Card>
            {
                new Card() { ImageUrl = "cock.jpg", Name = "Cocking", Location = "Japan" },
                new Card() { ImageUrl = "book.jpg", Name ="Book Boy", Location = "Japan" },
                new Card() { ImageUrl = "dotnet_bot.png", Name = ".Net", Location = "USA" }
            };
            this.cv.ItemsSource = cardlist;
        }


    }
    public class Card
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
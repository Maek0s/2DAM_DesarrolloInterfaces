namespace AYUDA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnComenzar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Page2());
        }
    }

}

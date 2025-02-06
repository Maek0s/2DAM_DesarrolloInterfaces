using ud08EjemploMicroCharts.ViewModels;

namespace ud08EjemploMicroCharts
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }
    }
}

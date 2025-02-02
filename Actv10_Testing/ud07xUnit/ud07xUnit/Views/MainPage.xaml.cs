using ud07xUnit.ViewModels;

namespace ud07xUnit.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

}

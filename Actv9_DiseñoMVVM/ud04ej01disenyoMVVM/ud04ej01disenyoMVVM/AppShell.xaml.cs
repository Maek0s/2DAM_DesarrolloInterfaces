using ud04ej01disenyoMVVM.ViewModels;
using ud04ej01disenyoMVVM.Views;

namespace ud04ej01disenyoMVVM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddItemNewWindow), typeof(AddItemNewWindow));
            Routing.RegisterRoute(nameof(AddItemNewWindowViewModel), typeof(AddItemNewWindowViewModel));
            Routing.RegisterRoute(nameof(MainPageViewModel), typeof(MainPageViewModel));
        }
    }
}

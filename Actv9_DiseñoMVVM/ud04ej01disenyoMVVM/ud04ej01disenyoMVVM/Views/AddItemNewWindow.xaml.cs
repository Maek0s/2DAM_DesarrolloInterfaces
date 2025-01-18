using ud04ej01disenyoMVVM.ViewModels;

namespace ud04ej01disenyoMVVM.Views;

public partial class AddItemNewWindow : ContentPage
{
    public AddItemNewWindow()
	{
		InitializeComponent();

		BindingContext = new AddItemNewWindowViewModel();
	}
}
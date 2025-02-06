using ud08EjemploMicroCharts.ViewModels;

namespace ud08EjemploMicroCharts
{
	public partial class GraficoPage : ContentPage
	{
		public GraficoPage()
		{
			InitializeComponent();
			BindingContext = new GraficoViewModel();
		}

        private async void Volver_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
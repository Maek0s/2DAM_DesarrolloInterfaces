using Microsoft.Maui.ApplicationModel.Communication;

namespace UD2Ejer5MarcosZahonero;

[QueryProperty(nameof(FormaPago), "formaPago")]
public partial class SelecCurso : ContentPage
{
    private string _formaPago = "";
    private string _nombreCurso = "";
    private int _precio = 0;
    public string FormaPago
    {
        get { return _formaPago; }
        set
        {
            _formaPago = value;
            OnPropertyChanged();
        }
    }

    public SelecCurso()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        _nombreCurso = "Jardineria";
        _precio = 5;
        await Shell.Current.GoToAsync($"//MainPage?nombreCurso=Jardineria&precio=5&formaPago={_formaPago}");

    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        _nombreCurso = "Informatica";
        _precio = 205;
        await Shell.Current.GoToAsync($"//MainPage?nombreCurso=Informatica&precio=205&formaPago={_formaPago}");
    }
}
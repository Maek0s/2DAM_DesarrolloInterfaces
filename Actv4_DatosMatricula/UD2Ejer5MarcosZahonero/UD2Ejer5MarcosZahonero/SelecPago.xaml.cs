namespace UD2Ejer5MarcosZahonero;

[QueryProperty(nameof(NombreCurso), "nombreCurso")]
[QueryProperty(nameof(Precio), "precio")]
public partial class SelecPago : ContentPage
{
    private string _formaPago;
    private string _nombreCurso;
    private int _precioCurso;

    public string NombreCurso
    {
        get { return _nombreCurso; }
        set
        {
            _nombreCurso = value;
            OnPropertyChanged();
        }
    }
    public int Precio
    {
        get { return _precioCurso; }
        set
        {
            _precioCurso = value;
            OnPropertyChanged();
        }
    }

    public SelecPago()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        _formaPago = "Efectivo";
        await Shell.Current.GoToAsync($"//MainPage?formaPago={_formaPago}&nombreCurso={_nombreCurso}&precio={_precioCurso}");

    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        _formaPago = "Tarjeta";
        await Shell.Current.GoToAsync($"//MainPage?formaPago={_formaPago}&nombreCurso={_nombreCurso}&precio={_precioCurso}");

    }
}
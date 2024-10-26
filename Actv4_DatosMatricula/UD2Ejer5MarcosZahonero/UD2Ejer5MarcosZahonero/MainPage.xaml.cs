using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UD2Ejer5MarcosZahonero
{
    [QueryProperty(nameof(NombreCurso), "nombreCurso")]
    [QueryProperty(nameof(Precio), "precio")]
    [QueryProperty(nameof(FormaPago), "formaPago")]
    public partial class MainPage : ContentPage
    {
        public Boolean calculated = false;
        public string _nombreCurso;
        public int _precioCurso;
        public string _formaPago;

        private bool _activateButton = false;
        public bool activateButton
        {
            get { return _activateButton; }
            set
            {
                if (_activateButton != value)
                {
                    _activateButton = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NombreCurso
        {
            get { return _nombreCurso; }
            set
            {
                _nombreCurso = value;
                checkButtonEnabled();
                OnPropertyChanged();
            }
        }
        public int Precio
        {
            get { return _precioCurso; }
            set
            {
                _precioCurso = value;
                calculated = false;
                OnPropertyChanged();
            }
        }
        public string FormaPago
        {
            get { return _formaPago; }
            set
            {
                if (value != null)
                {
                    _formaPago = value;
                    OnPropertyChanged();
                }
                checkButtonEnabled();
                calculated = false;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            activateButton = false;
            BindingContext = this;
        }

        private async void btnCurso_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"SelecCurso?formaPago={_formaPago}");
        }

        private async void btnPago_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"SelecPago?nombreCurso={_nombreCurso}&precio={_precioCurso}");
        }

        private void btnCalcularPrecio_Clicked(object sender, EventArgs e)
        {
            if (!calculated)
            {
                calcularPrecio();
            }
        }

        private void checkButtonEnabled()
        {
            if (!string.IsNullOrEmpty(_nombreCurso) && !string.IsNullOrEmpty(_formaPago))
            {
                activateButton = true;
            }
        }

        private void calcularPrecio()
        {
            framePrecioFinal.IsVisible = true;
            if (_formaPago == "Tarjeta")
            {
                lblPrecioFinal.Text = (_precioCurso * 0.90).ToString() + "€";
                calculated = true;
            }
            else
            {
                if (_nombreCurso == "Informatica")
                {
                    lblPrecioFinal.Text = "205" + "€";
                }
                else if (_nombreCurso == "Jardineria")
                {
                    lblPrecioFinal.Text = "5" + "€";
                }
            }

        }

    }

}

using System.Diagnostics;
using System;
using System.Xml.Linq;

namespace Actv5SeleccionIdioma
{

    public partial class MainPage : ContentPage
    {
        private int _contador;
        public int contador 
        {
            get { return _contador; }
            set
            {
                if (_contador != value)
                {
                    _contador = value;
                    OnPropertyChanged();
                }
            }
        }

        private String _nivelValenciano;
        public String nivelValenciano
        {
            get => _nivelValenciano;
            set
            {
                if (_nivelValenciano != value)
                {
                    _nivelValenciano = value;
                    OnPropertyChanged();
                }
            }
        }

        private String _nivelIngles;
        public String nivelIngles
        {
            get => _nivelIngles;
            set
            {
                if (_nivelIngles != value)
                {
                    _nivelIngles = value;
                    OnPropertyChanged();
                }
            }
        }

        private String _nivelFrances;
        public String nivelFrances
        {
            get => _nivelFrances;
            set
            {
                if (_nivelFrances != value)
                {
                    _nivelFrances = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            contador = 0;

            btnAdvancedOne.IsEnabled = false;
            btnAdvancedTwo.IsEnabled = false;
            btnAdvancedThree.IsEnabled = false;
        }

        private async void btnInsertValenc_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayPromptAsync("Nivel de valenciano", "¿Qué nivel tienes?", "OK", "Cancel");
            if (action != null && !action.Equals("Cancelar"))
            {
                nivelValenciano = action;
            }
            
        }

        private async void btnInsertIngles_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("¿Qué nivel de inglés tienes?", "Cancelar", null, "Alto", "Medio", "Bajo");

            // Saca el primer caracter de la respuesta ya que es el que nos interesa (A = Alto, M = Medio, B = Bajo)
            if (action != null && !action.Equals("Cancelar"))
            {
                nivelIngles = action[0].ToString();
            }
        }

        private async void btnInsertFrances_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("¿Qué nivel de francés tienes?", "Cancelar", "Borrar", "Alto", "Medio", "Bajo");
            //Debug.WriteLine(action);
            if (action != null)
            {
                if (action.Equals("Borrar"))
                {
                    nivelFrances = "";
                }
                else if (action.Equals("Cancelar"))
                {
                    // No debe ocurrir nada
                }
                else
                {
                    // Saca el primer caracter de la respuesta ya que es el que nos interesa (A = Alto, M = Medio, B = Bajo)
                    nivelFrances = action[0].ToString();
                }
            }
            
        }

        private async void btnCheck_Clicked(object sender, EventArgs e)
        {
            contador = 0;

            if (entryValenc.Text == "A")
                contador++;
            if (entryIngles.Text == "A")
                contador++;
            if (entryFrances.Text == "A")
                contador++;

            bool answer = await DisplayAlert("Avanzados", "¿Quieres ver el número de idiomas a nivel avanzado?", "Sí", "No");

            if (answer)
            {
                lblConteoAvanzado.Text = "Número de idiomas a nivel avanzado: " + contador;
                lblConteoAvanzado.IsVisible = true;
            } else
            {
                lblConteoAvanzado.IsVisible = false;
            }
        }

        private async void btnCredits_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Créditos", "Aplicación realizada por M.Z.M", "Ok");
        }

        
    }

}
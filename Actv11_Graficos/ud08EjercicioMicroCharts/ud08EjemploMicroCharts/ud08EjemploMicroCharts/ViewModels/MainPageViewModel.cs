using System.ComponentModel;
using System.Windows.Input;
using ud08EjemploMicroCharts.Models;

namespace ud08EjemploMicroCharts.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int _castello;
        public int Castello
        {
            get => _castello;
            set
            {
                if (_castello != value)
                {
                    _castello = value;
                    OnPropertyChanged(nameof(Castello));
                }
            }
        }

        private int _valencia;
        public int Valencia
        {
            get => _valencia;
            set
            {
                if (_valencia != value)
                {
                    _valencia = value;
                    OnPropertyChanged(nameof(Valencia));
                }
            }
        }

        private int _alicante;
        public int Alicante
        {
            get => _alicante;
            set
            {
                if (_alicante != value)
                {
                    _alicante = value;
                    OnPropertyChanged(nameof(Alicante));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand GenerarGraficoCommand { get; }

        public MainPageViewModel()
        {
            GenerarGraficoCommand = new Command(GenerarGrafico);
        }

        private async void GenerarGrafico()
        {
            var ventasAnuales = new Vendes
            {
                Castello = Castello,
                Valencia = Valencia,
                Alicante = Alicante
            };

            string datosVentas = $"{Castello}|{Valencia}|{Alicante}";
            await Shell.Current.GoToAsync($"//grafico?Ventas={datosVentas}");
        }


    }
}

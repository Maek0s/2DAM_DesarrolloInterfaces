using Microcharts;
using SkiaSharp;
using System.ComponentModel;

namespace ud08EjemploMicroCharts.ViewModels
{
    [QueryProperty(nameof(Ventas), "Ventas")]
    public class GraficoViewModel : INotifyPropertyChanged
    {
        private Chart _chart;
        public Chart Chart
        {
            get => _chart;
            set
            {
                _chart = value;
                OnPropertyChanged(nameof(Chart));
            }
        }

        private string? _ventas;
        public string Ventas
        {
            get { return _ventas; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var datos = value.Split("|");
                    if (datos.Length == 3 &&
                        int.TryParse(datos[0], out int castello) &&
                        int.TryParse(datos[1], out int valencia) &&
                        int.TryParse(datos[2], out int alacant))
                    {
                        Chart = new BarChart
                        {
                            Entries = new[]
                            {
                                new ChartEntry(castello) { Label = "Castellón", ValueLabel = castello.ToString(), Color = SKColor.Parse("#ff9999") },
                                new ChartEntry(valencia) { Label = "Valencia", ValueLabel = valencia.ToString(), Color = SKColor.Parse("#66b3ff") },
                                new ChartEntry(alacant) { Label = "Alicante", ValueLabel = alacant.ToString(), Color = SKColor.Parse("#99ff99") }
                            }
                        };
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

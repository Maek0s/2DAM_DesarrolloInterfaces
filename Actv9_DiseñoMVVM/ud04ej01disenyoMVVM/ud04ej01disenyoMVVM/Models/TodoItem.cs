using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ud04ej01disenyoMVVM.Models
{
    public class TodoItem : INotifyPropertyChanged
    {
        private String _nombreTarea;
        private bool _completada;

        public String NombreTarea
        {
            get { return _nombreTarea; }
            set 
            {
                if (_nombreTarea != value)
                {
                    _nombreTarea = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Completada
        {
            get { return _completada; }
            set
            {
                if (_completada != value)
                {
                    _completada = value;
                    OnPropertyChanged();
                }
            }
        }

        public TodoItem(String nombreTarea, bool completada)
        {
            _nombreTarea = nombreTarea;
            _completada = completada;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

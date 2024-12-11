using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace firebasepruebas
{
    public class Tarea : INotifyPropertyChanged
    {
        private string _IdTarea;
        private string _NombreTarea;
        public string IdTarea
        {
            get { return _IdTarea; }
            set
            {
                _IdTarea = value;
                OnPropertyChanged();
            }
        }
        public string NombreTarea
        {
            get { return _NombreTarea; }
            set
            {
                _NombreTarea = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
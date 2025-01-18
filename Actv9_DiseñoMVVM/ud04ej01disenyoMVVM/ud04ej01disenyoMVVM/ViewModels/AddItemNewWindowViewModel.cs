using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ud04ej01disenyoMVVM.ViewModels
{
    public class AddItemNewWindowViewModel
    {
        private string _nombreTarea;
        private bool _isCompleted;
        public string NombreTarea
        {
            get { return _nombreTarea; }
            set
            {
                if (_nombreTarea != value)
                {
                    _nombreTarea = value;
                    OnPropertyChanged(nameof(NombreTarea));
                }
            }
        }
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                }
            }
        }

        public ICommand addTareaCommand { get; set; }
        public ICommand cancelarTareaCommand { get; set; }

        public AddItemNewWindowViewModel()
        {
            addTareaCommand = new Command(addTarea);
            cancelarTareaCommand = new Command(cancelarTarea);
        }

        public void addTarea()
        {
            String tarea = "";

            String nombreTarea = NombreTarea;
            bool completed = IsCompleted;

            if (nombreTarea.Trim().Equals(""))
            {
                tarea = null;
            } else
            {
                tarea = nombreTarea + "|" + completed;
            }

            goBack(tarea);
        }

        public async void cancelarTarea()
        {
            // Lo dejo así por si llegamos a querer hacer algo especial
            await Shell.Current.GoToAsync($"///MainPage");
        }

        public async void goBack(String tarea)
        {
            await Shell.Current.GoToAsync($"///MainPage?_tarea={tarea}");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

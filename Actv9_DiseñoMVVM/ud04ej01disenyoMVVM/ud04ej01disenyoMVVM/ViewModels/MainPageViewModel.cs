using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ud04ej01disenyoMVVM.Models;

namespace ud04ej01disenyoMVVM.ViewModels
{
    [QueryProperty(nameof(Tarea), "_tarea")]
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private String _tarea;

        public String Tarea
        {
            get { return _tarea; }
            set
            {
                if (_tarea != value)
                {
                    _tarea = value;
                    addItemInList();
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<TodoItem> _listaTareas;

        public ObservableCollection<TodoItem> ListaTareas
        {
            get { return _listaTareas; }
            set
            {
                if (_listaTareas != value)
                {
                    _listaTareas = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPageViewModel()
        {
            _listaTareas = new ObservableCollection<TodoItem>();

            AddItemCommandNewWindow = new Command(addItem);
            DeleteItemCommand = new Command<TodoItem>(removeItem);
        }

        public async void addItem()
        {
            await Shell.Current.GoToAsync($"AddItemNewWindow");
        }

        public void removeItem(TodoItem tareaBorrar)
        {
            if (tareaBorrar != null)
            {
                _listaTareas.Remove(tareaBorrar);
            }
        }

        public ICommand AddItemCommandNewWindow { get; set; }

        public ICommand DeleteItemCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void addItemInList()
        {
            if (_tarea != null)
            {
                if (_tarea.Length > 0)
                {
                    String[] split = _tarea.Split("|");
                    String nombreTarea = split[0];
                    TodoItem item;

                    if (split[1].Equals("True"))
                    {
                        item = new TodoItem(nombreTarea, true);
                        _listaTareas.Add(item);
                    }
                    else if (split[1].Equals("False"))
                    {
                        item = new TodoItem(nombreTarea, false);
                        _listaTareas.Add(item);
                    }
                    else
                    {
                        Debug.WriteLine("Error al crear la tarea: " + _tarea);
                    }
                }
            }
        }
    }
}

using System.Collections.ObjectModel;
using ud04ej01disenyoMVVM.Models;
using ud04ej01disenyoMVVM.ViewModels;

namespace ud04ej01disenyoMVVM.Views
{
    public partial class MainPage : ContentPage
    {

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
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }
    }
}

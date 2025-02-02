using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ud07xUnit.Models;
using ud07xUnit.Views;

namespace ud07xUnit.ViewModels
{
    public partial class MainPageViewModel : INotifyPropertyChanged
    {
        private int _num1;
        public int Num1
        {
            get => _num1;
            set
            {
                if (_num1 == value) return;
                _num1 = value;
            }
        }

        private int _num2;
        public int Num2
        {
            get => _num2;
            set
            {
                if (_num2 == value) return;
                _num2 = value;
            }
        }

        private String _result;
        public String Result
        {
            get => _result;
            set
            {
                if (_result == value) return;
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand SumarCommand { get; set; }
        public ICommand RestarCommand { get; set; }
        public ICommand MultiplicarCommand { get; set; }
        public ICommand DividirCommand { get; set; }

        public MainPageViewModel()
        {
            SumarCommand = new Command(Sumar);
            RestarCommand = new Command(Restar);
            MultiplicarCommand = new Command(Multiplicar);
            DividirCommand = new Command(Dividir);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Sumar()
        {
            Result = Operacions.Sumar(Num1, Num2).ToString();
        }

        private void Restar()
        {
            Result = Operacions.Restar(Num1, Num2).ToString();
        }

        private void Multiplicar()
        {
            Result = Operacions.Multiplicar(Num1, Num2).ToString();
        }

        private void Dividir()
        {
            Result = Operacions.Dividir(Num1, Num2);
        }
    }

}
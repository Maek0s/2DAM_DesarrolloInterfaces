namespace UD2Ejer5MarcosZahonero
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SelecCurso), typeof(SelecCurso));
            Routing.RegisterRoute(nameof(SelecPago), typeof(SelecPago));
        }
    }
}

namespace ud08EjemploMicroCharts
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Forzar el tema claro
            Current.UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
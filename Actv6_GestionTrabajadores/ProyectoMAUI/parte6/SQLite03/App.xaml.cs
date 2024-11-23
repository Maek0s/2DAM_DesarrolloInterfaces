namespace SQLite03
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Establecer el tema en claro manualmente
            Application.Current.UserAppTheme = AppTheme.Light;

            MainPage = new AppShell();
        }
    }
}
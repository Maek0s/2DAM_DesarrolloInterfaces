using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;

namespace SQLite03
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Trabajador> _ocTrabajadores;
        public ObservableCollection<Trabajador> OcTrabajadores
        {
            get { return _ocTrabajadores;}
            set
            {
                _ocTrabajadores = value;
                OnPropertyChanged();
            }
        }

        private Trabajador _selected;
        public Trabajador selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            // Inicializamos los componentes
            InitializeComponent();

            // Lista de los trabajadores
            OcTrabajadores = new ObservableCollection<Trabajador>();

            // Crea la tabla de Trabajador sino existe
            CrearTablaTrabajador();

            // Recargar base de datos al inicio
            reloadDatabase();
            
            // Binding establecido
            BindingContext = this;
        }

        private void CrearTablaTrabajador()
        {
            using (SQLiteConnection connection = new SQLiteConnection(sacarConnection()))
            {
                connection.Open();

                // Creamos la consulta y la ejecutamos
                string query = "CREATE TABLE IF NOT EXISTS Trabajador (" +
                                     "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                     "nombre TEXT, " +
                                     "apellidos TEXT)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
           
        }

        private void btnUpdateUser_Clicked(object sender, EventArgs e)
        {
            if (eNombre.Text != "" && selected != null)
            {
                String query = "UPDATE Trabajador" + " SET nombre = \"" + eNombre.Text + 
                    "\", apellidos = \"" + eApellido.Text + "\" WHERE id = " + selected.Id;
             
                ejecutarQuery(query);
                
                lblErrores.Text = "";

                reloadDatabase();
            } else
            {
                if (selected == null)
                {
                    lblErrores.Text = "¡Selecciona un usuario!";
                }
                else if (eNombre.Text == "")
                {
                    lblErrores.Text = "¡Pon un nombre!";
                }
            }            
        }

        private void btnDeleteUser_Clicked(object sender, EventArgs e)
        {
            if (selected != null)
            {
                int idTrabajador = selected.Id;

                String query = "DELETE FROM Trabajador WHERE id = " + idTrabajador;
                ejecutarQuery(query);

                reloadDatabase();
                lblErrores.Text = "";
            } else
            {
                lblErrores.Text = "¡Selecciona un usuario!";
            }
        }

        private void btnRegistrarUser_Clicked(object sender, EventArgs e)
        {
            String query = "";
            String nombre = eNombre.Text;
            String apellido = eApellido.Text;

            if (eNombre.Text != "" && nombre != null)
            {
                query = "insert into Trabajador (nombre, apellidos) values ('" + nombre + "', '" + apellido + "')";

                ejecutarQuery(query);

                reloadDatabase();
                lblErrores.Text = "";
            }
            else
            {
                lblErrores.Text = "¡Pon un nombre!";
            }
        }

        private String sacarConnection()
        {
            string rutaDirectorioApp = System.AppContext.BaseDirectory;

            DirectoryInfo directorioApp = new DirectoryInfo(rutaDirectorioApp);

            // El objeto directorio será ahora:
            // D:\Datos\proyectos_DI2425\ud04part01ExempleSQLite\SQLite03
            directorioApp = directorioApp.Parent.Parent.Parent.Parent.Parent.Parent;

            // Creamos la ruta completa del fichero de la base de datos
            // En mi ejemplo:
            // D:\Datos\proyectos_DI2425\ud04part01ExempleSQLite\SQLite03\empresa.db
            string databasePath = Path.Combine(directorioApp.FullName, "empresa.db");

            // Creamos la cadena de conexión 
            string connectionString = $"Data Source={databasePath};Version=3;";

            return connectionString;
        }

        private void reloadDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(sacarConnection()))
            {
                connection.Open();

                // Creamos la consulta y la ejecutamos
                string sql = "SELECT * FROM Trabajador";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                OcTrabajadores.Clear();

                // Recorremos los registros devueltos del SELECT
                while (reader.Read())
                {
                    int idTrabajador = reader.GetInt32(0);
                    string nombreTrabajador = reader.GetString(1);
                    string apellidosTrabajador = reader.GetString(2);

                    // Creamos un objeto Trabajador y lo añadimos al Observable Collection
                    Trabajador trabajador = new Trabajador
                    {
                        Id = idTrabajador,
                        Nombre = nombreTrabajador,
                        Apellidos = apellidosTrabajador,
                    };

                    // Añadimos el trabajador al Observable Collection
                    OcTrabajadores.Add(trabajador);
                }

                reader.Close();
                connection.Close();
            }
        }

        private void ejecutarQuery(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(sacarConnection()))
            {
                connection.Open();
                
                // Creamos la consulta y la ejecutamos
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Ejecuta el comando SQL
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
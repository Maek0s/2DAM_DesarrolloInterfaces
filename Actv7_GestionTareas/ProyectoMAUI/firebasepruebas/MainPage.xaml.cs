using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace firebasepruebas
{
    public partial class MainPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://tareasmz-default-rtdb.europe-west1.firebasedatabase.app/");

        private Tarea _selected;
        public Tarea Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Tarea> _ocTareas;
        public ObservableCollection<Tarea> OcTareas
        {
            get { return _ocTareas; }
            set
            {
                if ( value != null)
                {
                    _ocTareas = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Log> _logs;
        public ObservableCollection<Log> Logs
        {
            get { return _logs; }
            set
            {
                if (value != null)
                {
                    _logs = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPage()
        {
            // Inicializamos los componentes
            InitializeComponent();
            
            // Creamos la tabla de Tareas
            OcTareas = new ObservableCollection<Tarea>();

            // Creamos la tabla de Logs
            Logs = new ObservableCollection<Log>();

            // Reiniciamos la base de datos para volcar la información a la tabla
            reloadDatabase();

            // Establecemos el binding
            BindingContext = this;
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(eNombre.Text))
            {
                Tarea tarea = new Tarea
                {
                    IdTarea = string.Empty, // Inicialmente vacío
                    NombreTarea = eNombre.Text
                };

                // Publicar la tarea en Firebase y obtener la respuesta
                var response = await firebaseClient.Child("Tareas").PostAsync(tarea);
                string key = response.Key; // Obtener la clave generada

                if (!string.IsNullOrEmpty(key))
                {
                    // Actualizar el ID de la tarea en Firebase
                    await firebaseClient.Child("Tareas").Child(key).PutAsync(new Tarea
                    {
                        IdTarea = key,
                        NombreTarea = tarea.NombreTarea
                    });

                    // Agrega la acción al registro
                    Logs.Add(new Log
                    {
                        Descripcion = $"Añadido: {eNombre.Text}",
                        Tipo = "Añadir"
                    });

                    // Limpiar el campo de entrada
                    eNombre.Text = string.Empty;

                    // Recargar la base de datos para actualizar la lista
                    reloadDatabase();
                }
            }
            else
            {
                await DisplayAlert("¡Error!", "Tienes que poner un nombre.", "Vale");
            }
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            // Verificar que haya una tarea seleccionada
            if (Selected != null)
            {
                // Verificar que haya texto en el eNombre
                if (!string.IsNullOrWhiteSpace(eNombre.Text))
                {
                    // Agrega la acción a la lista
                    Log registro = new Log
                    {
                        Descripcion = $"Actualizado: {Selected.NombreTarea} -> {eNombre.Text}",
                        Tipo = "Actualizar"
                    };

                    // Añade el registro a los registro de acciones
                    Logs.Add(registro);

                    // Actualizar el nombre de la tarea seleccionada
                    Selected.NombreTarea = eNombre.Text;

                    // Limpiar el campo de entrada
                    eNombre.Text = string.Empty;

                    // Actualizar la tarea en Firebase
                    await firebaseClient.Child("Tareas").Child(Selected.IdTarea).PutAsync(Selected);

                    // Refrescar la lista
                    reloadDatabase();
                }
                else
                {
                    await DisplayAlert("¡Error!", "El campo de nombre no puede estar vacío.", "Vale");
                }
            }
            else
            {
                await DisplayAlert("¡Error!", "Tienes que seleccionar una tarea primero.", "Vale");
            }
        }

        private async void btnRemove_Clicked(object sender, EventArgs e)
        {
            if (Selected != null)
            {
                var collection = firebaseClient
                //Esborra l'item de Firebase amb la clau itemseleccionado.id
                .Child("Tareas").Child(Selected.IdTarea).DeleteAsync();

                // Agrega la acción a la lista
                Log registro = new Log
                {
                    Descripcion = $"Eliminado: {Selected.NombreTarea}",
                    Tipo = "Eliminar"
                };

                Logs.Add(registro);

                // Limpiar el campo de entrada
                eNombre.Text = string.Empty;

                // Volvemos a actuar la base de datos para que se actualice la tabla
                reloadDatabase();
            } else
            {
                await DisplayAlert("¡Error!", "Tienes que seleccionar antes una tarea.", "Vale");
            }
            
            Selected = null;
        }

        /* private void reloadDatabase()
         {
             // Eliminamos la lista ya existente para volcar
             OcTareas.Clear();

             var collection = firebaseClient
             .Child("Tareas")
             .AsObservable<Tarea>()
             // Amb .Subscriu ens subscrivim als canvis en la base de dades i els afegim a la 
             .Subscribe((item) =>
             {
                 if (item.Object != null)
                 {
                     // Si l'EventType d'item.Object és Delete, l'item ha sigut esborrat de la base de dades
                     if (item.EventType == Firebase.Database.Streaming.FirebaseEventType.Delete)
                     {
                         var deletedItem = OcTareas.FirstOrDefault(tu => tu.IdTarea == item.Key);
                         // Podria haver-se escrit així:
                         //var deletedItem = (from tu in Tasques
                         // where tu.IdTarea == item.Key
                         // select tu).SingleOrDefault();
                         if (deletedItem != null)
                         {
                             // Esborrem la tasca de l'ObservableCollection perquè ja no existix
                             // en Firebaset
                             try
                             {
                                 OcTareas.Remove(deletedItem);
                             } catch (Exception e)
                             {
                                 Console.WriteLine("out " + deletedItem + " " + e.Message);
                             }

                         }
                     }
                     else
                     // L'EventType és Insert o Update, l'item ha sigut afegit o modificat en la base de dades
                     {
                         // Busquem si la tasca ja existix en l'ObservableCollection
                         var existingItem = OcTareas.FirstOrDefault(tu => tu.IdTarea == item.Key);
                         // L'item no existix en la col·lecció. Ho afegim.
                         // S'afegiran totes les tasques de la base de dades de Firebase
                         // en iniciar l'aplicació perquè es mostren en el CollectionView
                         if (existingItem == null)
                         {
                             // Afig el nou item a la col·lecció
                             OcTareas.Add(new Tarea
                             {
                                 NombreTarea = item.Object.NombreTarea,
                                 IdTarea = item.Key
                             });
                         }
                         else
                         {
                             // Actualitza la propietat NombreTarea de l'item existent
                             existingItem.NombreTarea = item.Object.NombreTarea;
                         }
                     }
                 }
             });

         }*/

        private async void reloadDatabase()
        {
            // Obtener todas las tareas desde Firebase
            var tareas = await firebaseClient.Child("Tareas").OnceAsync<Tarea>();

            var nuevasTareas = tareas.Select(t => new Tarea
            {
                IdTarea = t.Key,
                NombreTarea = t.Object.NombreTarea
            }).ToList();

            // Actualizar `OcTareas` asegurando que no se eliminen elementos visibles temporalmente
            foreach (var tarea in nuevasTareas)
            {
                if (!OcTareas.Any(t => t.IdTarea == tarea.IdTarea))
                {
                    OcTareas.Add(tarea);
                }
            }

            var tareasParaEliminar = OcTareas.Where(t => !nuevasTareas.Any(nt => nt.IdTarea == t.IdTarea)).ToList();
            foreach (var tareaParaEliminar in tareasParaEliminar)
            {
                OcTareas.Remove(tareaParaEliminar);
            }
        }

    }

}

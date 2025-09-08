using System.Net.Http.Json;

namespace ToDoApp;

public partial class MainPage : ContentPage
{
    private readonly HttpClient _client;

    public MainPage()
    {
        InitializeComponent();
        _client = new HttpClient
        {
            BaseAddress = new Uri("http://192.168.40.3:5000/api/") // 🔹 Cambia a la URL de tu API real
        };
    }

    // Cargar usuarios existentes
    private async void OnCargarUsuariosClicked(object sender, EventArgs e)
    {
        try
        {
            var usuarios = await _client.GetFromJsonAsync<List<Usuario>>("usuarios");
            UsuariosCollectionView.ItemsSource = usuarios;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    // Agregar nuevo usuario
    private async void OnAgregarUsuarioClicked(object sender, EventArgs e)
    {
        // 🔹 Crear objeto con los datos del formulario
        var nuevoUsuario = new Usuario
        {
            Nombre = EntryNombre.Text,
            Apellido = EntryApellido.Text,
            Username = EntryUsername.Text,
            Password = EntryPassword.Text,
            Email = EntryEmail.Text
        };

        try
        {
            var response = await _client.PostAsJsonAsync("usuarios", nuevoUsuario);
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Usuario agregado correctamente", "OK");

                // 🔹 Limpiar formulario
                EntryNombre.Text = "";
                EntryApellido.Text = "";
                EntryUsername.Text = "";
                EntryPassword.Text = "";
                EntryEmail.Text = "";

                // 🔹 Refrescar lista
                OnCargarUsuariosClicked(null, null);
            }
            else
            {
                await DisplayAlert("Error", $"No se pudo agregar el usuario ({response.StatusCode})", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}

// Modelo de Usuario (puede ir en otra carpeta/archivo)
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
}

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
            BaseAddress = new Uri("http://192.168.40.3:5000/api/") // Cambia a tu API
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
        var nuevoUsuario = new Usuario
        {
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
                EntryUsername.Text = EntryPassword.Text = EntryEmail.Text = ""; // Limpiar formulario
                OnCargarUsuariosClicked(null, null); // Refrescar lista
            }
            else
            {
                await DisplayAlert("Error", "No se pudo agregar el usuario", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}

// Modelo de Usuario (puede ir en otro archivo)
public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
}

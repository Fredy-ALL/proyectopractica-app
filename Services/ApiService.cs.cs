using System.Net.Http.Json;
using ToDoApp.Models;

namespace ToDoApp.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    // 👇 Cambiá la URL de tu API publicada
    private const string BaseUrl = "https://localhost:7245/swagger/index.html";

    public ApiService()
    {
        _httpClient = new HttpClient();
    }

    // Usuarios
    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>(BaseUrl + "usuarios");
    }

    public async Task CrearUsuarioAsync(Usuario usuario)
    {
        await _httpClient.PostAsJsonAsync(BaseUrl + "usuarios", usuario);
    }

    // Actividades
    public async Task<List<Actividad>> GetActividadesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Actividad>>(BaseUrl + "actividades");
    }

    public async Task CrearActividadAsync(Actividad actividad)
    {
        await _httpClient.PostAsJsonAsync(BaseUrl + "actividades", actividad);
    }

    // Seguimiento
    public async Task<List<SeguimientoActividad>> GetSeguimientosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<SeguimientoActividad>>(BaseUrl + "seguimientos");
    }

    public async Task CrearSeguimientoAsync(SeguimientoActividad seguimiento)
    {
        await _httpClient.PostAsJsonAsync(BaseUrl + "seguimientos", seguimiento);
    }
}

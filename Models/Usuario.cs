namespace ToDoApp.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }  // normalmente no lo devolvés en la API
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Imagen { get; set; }
    public string Status { get; set; }
    public string Tipo { get; set; }
    public DateTime CreatedAt { get; set; }
}

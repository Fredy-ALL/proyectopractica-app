namespace ToDoApp.Models;

public class Actividad
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Prioridad { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaEstimadaFinalizacion { get; set; }
    public string Estado { get; set; }
    public int UsuarioId { get; set; }
}

namespace ToDoApp.Models;

public class SeguimientoActividad
{
    public int Id { get; set; }
    public int ActividadId { get; set; }
    public int UsuarioId { get; set; }
    public string Accion { get; set; }
    public DateTime FechaHora { get; set; }
}

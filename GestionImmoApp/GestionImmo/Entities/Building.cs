namespace GestionImmo.Entities;

public class Building
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPrincipal{ get; set; }
    public double FloorSurface { get; set; }
}

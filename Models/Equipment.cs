namespace Wypozyczalnia.Models;

public enum EquipmentStatus
{
    Available,
    Rented,
    Unavailable
}
public abstract class Equipment
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }

    protected Equipment(string Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
        this.IsAvailable = true;
    }
}
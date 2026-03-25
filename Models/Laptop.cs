namespace Wypozyczalnia.Models;

public class Laptop : Equipment
{
    public string Processor { get; set; }
    public int RamGb { get; set; }

    public Laptop(string Id, string Name, string processor, int ramGb) :base(Id,Name)
    {
        this.Processor = processor;
        this.RamGb = ramGb;
        
    }
    
}
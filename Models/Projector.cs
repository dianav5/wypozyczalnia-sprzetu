namespace Wypozyczalnia.Models;

public class Projector : Equipment
{
    public string Resolution { get; set; }
    public int BrightnessLum { get; set; }

    public Projector(string Id, string Name, int BrightnessLum, string Resolution) : base(Id, Name)
    {
        this.Resolution = Resolution;
        this.BrightnessLum = BrightnessLum;
    }

}
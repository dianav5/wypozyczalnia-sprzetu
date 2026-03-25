namespace Wypozyczalnia.Models;

public class Camera : Equipment
{
    public int Megapixels { get; set; }
    public bool HasVideo { get; set; }


    public Camera(string Id, string Name, int Megapixels, bool HasVideo) : base(Id, Name)
    {
        this.Megapixels = Megapixels;
        this.HasVideo = HasVideo;
    }

}
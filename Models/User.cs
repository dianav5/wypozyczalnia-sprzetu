namespace Wypozyczalnia.Models;

public abstract class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public User(string Id, string firstName, string lastName)
    {
        this.Id = Id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}
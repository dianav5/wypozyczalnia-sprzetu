namespace Wypozyczalnia.Models;

public class Student : User
{
    public Student(string Id, string FirstName, string LastName) : base(Id, FirstName, LastName)
    {
    }
}
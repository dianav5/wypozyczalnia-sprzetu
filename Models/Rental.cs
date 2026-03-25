namespace Wypozyczalnia.Models;

public class Rental
{
    public string Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Penalty{get; set;}
    public bool IsReturned {
        get { return ReturnDate != null; }
    }

    public bool IsOverdue
    {
        get
        {
            return !IsReturned && DateTime.Now > DueDate;
        }
    }

    public Rental(string id, User user, Equipment equipment, DateTime rentDate, DateTime dueDate)
    {
        this.Id = id;
        this.User = user;
        this.Equipment = equipment;
        this.RentDate = rentDate;
        this.DueDate = dueDate;
    }
}
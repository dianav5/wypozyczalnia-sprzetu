using Wypozyczalnia.Models;

namespace Wypozyczalnia.Services;

public class RentalService
{
    private List<Rental> _rentals;
    private PenaltyService _penaltyService;

    public RentalService(List<Rental> rentals, PenaltyService penaltyService)
    {
        _rentals = rentals;
        _penaltyService = penaltyService;
    }

    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (!equipment.IsAvailable)
        {
            throw new Exception("Sprzet niedostepny!");
        }

        int activeRental = _rentals.Count(r => r.User.Id == user.Id && !r.IsReturned);

        int limit;

        if (user is Student)
        {
            limit = 2;
        }
        else
        {
            limit = 5;
        }

        if (activeRental >= limit)
        {
            throw new Exception("Użytkownik przekroczyl limit wypożyczeń!!!");
        }

        var rental = new Rental(Guid.NewGuid().ToString(), user, equipment, DateTime.Now, DateTime.Now.AddDays(days));
        equipment.IsAvailable = false;

        _rentals.Add(rental);
    }

    public decimal ReturnEquipment(string rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);

        if (rental == null)
        {
            throw new Exception("Nie znaleziono wypożyczenia.");
        }

        if (rental.IsReturned)
        {
            throw new Exception("Sprzęt już został zwrócony.");
        }

        decimal penalty = _penaltyService.CalculatePenalty(
            rental.DueDate,
            DateTime.Now
        );

        rental.ReturnDate = DateTime.Now;
        rental.Penalty = penalty;

        rental.Equipment.IsAvailable = true;

        return penalty;
    }

    public List<Rental> GetActiveRentalsForUser(string userId)
    {
        return _rentals
            .Where(r => r.User.Id == userId && !r.IsReturned)
            .ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals
            .Where(r => !r.IsReturned && r.IsOverdue)
            .ToList();
    
    }
}
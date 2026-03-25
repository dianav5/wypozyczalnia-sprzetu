namespace Wypozyczalnia.Services;

public class PenaltyService
{
    private const decimal PenaltyPerDay = 10m;

    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <= dueDate)
        {
            return 0m;
        }

        int daysLate = (returnDate.Date - dueDate.Date).Days;
        
        return daysLate*PenaltyPerDay;
    }
}
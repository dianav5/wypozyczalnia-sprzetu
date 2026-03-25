using Wypozyczalnia.Models;

namespace Wypozyczalnia.Services;

public class ReportService
{
    public void PrintAllEquipment(List<Equipment> equipments)
    {
        Console.WriteLine("=== Lista całego sprzętu ===");

        foreach (var equipment in equipments)
        {
            Console.WriteLine(
                $"ID: {equipment.Id}, " +
                $"Name: {equipment.Name}, " +
                $"Available: {equipment.IsAvailable}"
            );
        }
    }

    public void PrintAvailableEquipment(List<Equipment> equipments)
    {
        Console.WriteLine("=== Dostępny sprzęt ===");

        var available = equipments
            .Where(e => e.IsAvailable)
            .ToList();

        foreach (var equipment in available)
        {
            Console.WriteLine(
                $"ID: {equipment.Id}, " +
                $"Name: {equipment.Name}"
            );
        }
    }

    public void PrintActiveRentals(List<Rental> rentals)
    {
        Console.WriteLine("=== Aktywne wypożyczenia ===");

        var active = rentals
            .Where(r => !r.IsReturned)
            .ToList();

        foreach (var rental in active)
        {
            Console.WriteLine(
                $"User: {rental.User.FirstName} {rental.User.LastName}, " +
                $"Equipment: {rental.Equipment.Name}, " +
                $"Due: {rental.DueDate}"
            );
        }
    }

    public void PrintOverdueRentals(List<Rental> rentals)
    {
        Console.WriteLine("=== Przeterminowane wypożyczenia ===");

        var overdue = rentals
            .Where(r => r.IsOverdue)
            .ToList();

        foreach (var rental in overdue)
        {
            Console.WriteLine(
                $"User: {rental.User.FirstName} {rental.User.LastName}, " +
                $"Equipment: {rental.Equipment.Name}, " +
                $"Due: {rental.DueDate}"
            );
        }
    }
}
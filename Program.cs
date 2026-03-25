using Wypozyczalnia.Models;
using Wypozyczalnia.Services;

var equipments = new List<Equipment>();
var users = new List<User>();
var rentals = new List<Rental>();

var penaltyService = new PenaltyService();
var rentalService = new RentalService(rentals, penaltyService);
var reportService = new ReportService();

Console.WriteLine("=== SYSTEM WYPOŻYCZALNI SPRZĘTU ===");

// Tworzenie sprzętu
var laptop = new Laptop("E1", "Dell Latitude", "i7", 16);
var projector = new Projector("E2", "Epson X200", 3200, "Full HD");
var camera = new Camera("E3", "Canon EOS", 24, true);

equipments.Add(laptop);
equipments.Add(projector);
equipments.Add(camera);

// Tworzenie użytkowników
var student = new Student("U1", "Jan", "Kowalski");
var employee = new Employee("U2", "Anna", "Nowak");

users.Add(student);
users.Add(employee);

// Wypożyczenie
Console.WriteLine("\nWypożyczanie laptopa przez studenta...");
rentalService.RentEquipment(student, laptop, 7);

// Próba ponownego wypożyczenia tego samego sprzętu
try
{
    rentalService.RentEquipment(student, laptop, 3);
}
catch (Exception ex)
{
    Console.WriteLine($"Błąd: {ex.Message}");
}

// Wyświetlenie dostępnego sprzętu
reportService.PrintAvailableEquipment(equipments);

// Symulacja przeterminowania
var rental = rentals.First();
rental.DueDate = DateTime.Now.AddDays(-2);

// Zwrot sprzętu
Console.WriteLine("\nZwrot sprzętu...");
var penalty = rentalService.ReturnEquipment(rental.Id);

Console.WriteLine($"Kara za spóźnienie: {penalty} zł");

// Raport końcowy
reportService.PrintActiveRentals(rentals);
reportService.PrintOverdueRentals(rentals);

reportService.PrintUsers(users);

Console.WriteLine("\n=== KONIEC ===");
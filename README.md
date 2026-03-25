# System wypożyczalni sprzętu

## Opis projektu

Aplikacja konsolowa w języku C# obsługująca uczelnianą wypożyczalnię sprzętu.
System umożliwia dodawanie użytkowników i sprzętu, wypożyczanie sprzętu,
zwroty, kontrolę dostępności oraz generowanie raportów.

## Instrukcja uruchomienia

1. Otwórz projekt w Riderze
2. Uruchom aplikację (Run)
3. Program wykona scenariusz demonstracyjny w metodzie Main

## Struktura projektu

Projekt został podzielony na dwie główne części:

Models – klasy opisujące dane:
- Equipment
- Laptop
- Projector
- Camera
- User
- Student
- Employee
- Rental

Services – klasy zawierające logikę biznesową:
- RentalService
- PenaltyService
- ReportService

Program.cs – zawiera scenariusz demonstracyjny działania systemu.

## Decyzje projektowe

Zastosowano klasy abstrakcyjne Equipment oraz User, ponieważ różne typy sprzętu
i użytkowników mają część wspólnych cech oraz część specyficznych.

Logika biznesowa została przeniesiona do klas serwisowych, aby nie umieszczać
jej w Program.cs. Dzięki temu kod jest bardziej czytelny i łatwiejszy do rozwijania.

Podział na Models i Services pozwala oddzielić dane od operacji wykonywanych
na tych danych.

## Odpowiedzialności klas

Każda klasa ma określoną rolę w systemie:

Equipment – reprezentuje wspólne dane dla wszystkich typów sprzętu  
Laptop, Projector, Camera – reprezentują konkretne typy sprzętu

User – reprezentuje użytkownika systemu  
Student, Employee – reprezentują różne typy użytkowników

Rental – reprezentuje pojedyncze wypożyczenie sprzętu

RentalService – obsługuje wypożyczanie i zwroty sprzętu  
PenaltyService – odpowiada za obliczanie kary za opóźnienie  
ReportService – odpowiada za generowanie raportów

Program.cs – uruchamia aplikację i pokazuje scenariusz działania

## Kohezja

W projekcie starano się zachować kohezję poprzez przypisanie każdej klasie
jednej konkretnej odpowiedzialności.

- RentalService zajmuje się tylko operacjami wypożyczeń
- PenaltyService odpowiada tylko za obliczanie kar
- ReportService odpowiada tylko za raporty

Dzięki temu kod jest bardziej uporządkowany i łatwiejszy do zrozumienia.

## Coupling

Coupling został ograniczony poprzez rozdzielenie modeli danych od logiki biznesowej.

Klasy serwisowe korzystają z modeli, ale nie przechowują danych na stałe.
Zmiana sposobu naliczania kar wymaga modyfikacji głównie w klasie
PenaltyService, a nie w całym projekcie.

## Podsumowanie

Projekt spełnia wymagania zadania:
- obsługuje różne typy sprzętu i użytkowników
- implementuje logikę wypożyczeń i kar
- generuje raporty
- posiada podział na modele danych i logikę biznesową
- wykorzystuje repozytorium GitHub z historią commitów
Event exEvent = new Event("ciao", DateOnly.Parse("2026-3-24"), 1000);
// INTERFACCIA UTENTE

Console.WriteLine("Inserisci nome evento");
var title = Console.ReadLine();
Console.WriteLine("Inserisci data evento[January 3, 2024]");
var date = Console.ReadLine();
Console.WriteLine("Inserisci capacità evento");
var maxSeats = Console.ReadLine();
Event userEvent = new Event(title, DateOnly.Parse(date),Int32.Parse(maxSeats));

Console.WriteLine("Vuoi fare una prenotazione?[si/no]");
string response = Console.ReadLine();

if(response == "si")
{
    Console.WriteLine("Quanti posti vuoi prenotare?");
    var seatToReserve = Console.ReadLine();
    userEvent.BookSeats(Int32.Parse(seatToReserve));
    Console.WriteLine($"Posti Rimanenti {userEvent.LeftSeats()} su {userEvent.maxSeats}");
    Console.WriteLine(userEvent.reservedSeats);
;    
}

Console.WriteLine("Vuoi disdire delle prenotazioni?");
response = Console.ReadLine();

while (response == "si")
{

    Console.WriteLine("Quanti posti vuoi disdire?");
    var seatToRemove = Console.ReadLine(); 
    userEvent.RemoveSeats(Int32.Parse(seatToRemove));
    Console.WriteLine($"Posti Rimanenti {userEvent.LeftSeats()} su {userEvent.maxSeats}"); 
    Console.WriteLine("Vuoi disdire altre prenotazioni?");
    response = Console.ReadLine();
}

Console.WriteLine($"Posti Rimanenti {userEvent.LeftSeats()} su {userEvent.maxSeats}");
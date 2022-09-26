Event exEvent1 = new Event("Metallica on Tour", DateOnly.Parse("2026-3-24"), 1000);
Event exEvent2 = new Event("Guns N Roses Live", DateOnly.Parse("2023-5-24"), 1000);
Event exEvent3 = new Event("Marracash, Live in Milano", DateOnly.Parse("2023-12-2"), 1000);


////// MILESTONE #2 ///////////
///
// INTERFACCIA UTENTE

Console.WriteLine("Inserisci nome evento");
var title = Console.ReadLine();
Console.WriteLine("Inserisci data evento[January 3, 2024]");
var date = Console.ReadLine();
Console.WriteLine("Inserisci capacità evento");
var maxSeats = Console.ReadLine();
Event userEvent = new Event(title, DateOnly.Parse(date), Int32.Parse(maxSeats));

Console.WriteLine("Vuoi fare una prenotazione?[si/no]");
string response = Console.ReadLine();

if (response == "si")
{
    Console.WriteLine("Quanti posti vuoi prenotare?");
    var seatToReserve = Console.ReadLine();
    userEvent.BookSeats(Int32.Parse(seatToReserve));
    Console.WriteLine($"Posti Rimanenti {userEvent.LeftSeats()} su {userEvent.MaxSeats}");
    Console.WriteLine(userEvent.ReservedSeats);
    ;
}

Console.WriteLine("Vuoi disdire delle prenotazioni?");
response = Console.ReadLine();

while (response == "si")
{

    Console.WriteLine("Quanti posti vuoi disdire?");
    var seatToRemove = Console.ReadLine();
    userEvent.RemoveSeats(Int32.Parse(seatToRemove));
    Console.WriteLine($"Posti Rimanenti {userEvent.LeftSeats()} su {userEvent.MaxSeats}, prenotati {userEvent.ReservedSeats}");
    Console.WriteLine("Vuoi disdire altre prenotazioni?");
    response = Console.ReadLine();
}

Console.WriteLine($"Posti Rimanenti {userEvent.LeftSeats()} su {userEvent.MaxSeats}");


////// MILESTONE #3 ///////////

ProgrammaEventi exProgramma = new ProgrammaEventi("TicketOne") { };

exProgramma.addEvent(exEvent1);
exProgramma.addEvent(exEvent2);
exProgramma.addEvent(exEvent3);

foreach (string eventString in ProgrammaEventi.PrintEvents(exProgramma.events))
{
    Console.WriteLine(eventString);
};

Console.WriteLine(exProgramma.CountEvents());

exProgramma.RemoveAllEvents();


Console.WriteLine(exProgramma.CountEvents());
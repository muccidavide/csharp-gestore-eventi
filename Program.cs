using System;

Event exEvent1 = new Event("Metallica on Tour", DateOnly.Parse("2026-3-24"), 1000);
Event exEvent2 = new Event("Guns N Roses Live", DateOnly.Parse("2023-5-24"), 1000);
Event exEvent3 = new Event("Marracash, Live in Milano", DateOnly.Parse("2023-12-2"), 1000);

Conference exConference1 = new Conference("Gianni speak", DateOnly.Parse("2023-12-2"), 1000, "Gianni Loco", 56.30m);
Conference exConference2 = new Conference("Canta con noi", DateOnly.Parse("2023-12-2"), 1000, "Mario Pini", 36.30m);

ProgrammaEventi exProgramma = new ProgrammaEventi("TicketOne") { };

exProgramma.addEvent(exEvent1);
exProgramma.addEvent(exEvent2);
exProgramma.addEvent(exEvent3);

exProgramma.addEvent(exConference1);
exProgramma.addEvent(exConference2);

ProgrammaEventi.PrintList(exProgramma.events);


/*
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

*/

/**

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

//exProgramma.RemoveAllEvents();
//Console.WriteLine(exProgramma.CountEvents());

foreach(string e in exProgramma.Print()){
    Console.WriteLine(e);
}

*/

////// MILESTONE #4 ///////////



ProgrammaEventi userProgram = null;
int counter = 0;
string title;


while (userProgram == null)
{
    Console.WriteLine("Titolo programma?");
    title = Console.ReadLine();

    try
    {
        userProgram = new ProgrammaEventi(title);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

while (counter <= 0)
{
    try
    {
        Console.WriteLine(" Quanti eventi vuoi raggiungere?");
        string input = Console.ReadLine();
        counter = Int32.Parse(input);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

bool terminated = false;

while (userProgram.events.Count() < counter && !terminated)
{
    Event userEvent = null;
    Console.WriteLine("Inserisci nome evento");
    var name = Console.ReadLine();
    Console.WriteLine("Inserisci data evento[January 3, 2024]");
    var date = Console.ReadLine();
    Console.WriteLine("Inserisci capacità evento");
    var maxSeats = Console.ReadLine();

    try
    {
        userEvent = new Event(name, DateOnly.Parse(date), Int32.Parse(maxSeats));
        if (userEvent != null)
        {
            userProgram.addEvent(userEvent);
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

        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    Console.WriteLine("//////////");
    foreach (string e in userProgram.Print())
    {
        Console.WriteLine(e);
    }

    Console.WriteLine("//////////");

    if (userProgram.events.Count() == counter)
    {
        Console.WriteLine("Numero eventi totali: " + userProgram.CountEvents());
        foreach (string e in userProgram.Print())
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("In che data cerchi degli eventi?");
        var searchDate = Console.ReadLine();

        List<Event> listEvents = userProgram.EventThatDay(DateOnly.Parse(searchDate));
        Console.WriteLine($"Gli eventi presenti del {searchDate} sono:");
        ProgrammaEventi.PrintList(listEvents);

        userProgram.RemoveAllEvents();
        terminated = true;

    }
}

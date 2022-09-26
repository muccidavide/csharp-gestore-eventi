// INTERFACCIA UTENTE






public class ProgrammaEventi
{
    private string Title { get; set; }

    public List<Event> events;

    public ProgrammaEventi(string title)
    {
        Title = title;
        this.events = new List<Event> { };
    }

    public void addEvent(Event eventToAdd)
    {
        events.Add(eventToAdd);
    }
    public List<Event> EventThatDay(DateOnly date)
    {
        List<Event> eventsFilterd = new List<Event>();
        foreach (Event e in events)
        {
            DateOnly eventDate = e.Date;
            if(e.Date == date)
                eventsFilterd.Add(e);
        }

        return eventsFilterd;
    }
    public string[] PrintEvents()
    {
        string[] listEvents = new string[events.Count];

        for (int i = 0; i < listEvents.Length; i++)
        {
            listEvents[i] = events[i].ToString();
        }

        return listEvents;
    }
    public static string[] PrintEvents(List<Event>  events)
    {
        string[] listEvents = new string[events.Count];

       for(int i = 0; i < listEvents.Length; i++)
        {
            listEvents[i] = events[i].ToString();
        }

        return listEvents;
    } 


    public int CountEvents()
    {
        return events.Count();
    }

    public void RemoveAllEvents()
    {
        events = new List<Event> { };
    }
}
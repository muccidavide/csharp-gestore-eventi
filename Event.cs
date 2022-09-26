
public class Event
{
    private string title;
    private DateOnly date;
    private int maxSeats;
    public int ReservedSeats { get; private set; }

    public Event(string _title, DateOnly _date, int _maxSeats)
    {
        this.Title = _title;
        this.Date = _date;
        this.MaxSeats = _maxSeats;
        this.ReservedSeats = 0;
    }

    public string Title
    {

        get
        {
            return this.title;
        }
        set
        {

            if (value.Trim().Length != 0)
            {
                this.title = value.Trim();
            }
            else
            {
                throw new Exception("Inserisci un titolo valido");
            }     
        }

    }


    public DateOnly Date
    {

        get
        {
            return date;
        }
        set
        {

                var today = DateOnly.FromDateTime(DateTime.Today);

                if (value > today)
                    this.date = value;
                else
                    throw new Exception("Data inserita non valida");
            
        }
    }


    public int MaxSeats
    {
        get
        {
            return this.maxSeats;
        }
        set
        {
            if (value > 0)
                this.maxSeats = value;
            else
                throw new Exception("La capienza massima non può essere < 0 = a 0");
        }
    }

    // Costruttore


    // Metodi
    public void BookSeats(int seatsNumber)
    {
        if (isValidDate() && LeftSeats() > seatsNumber)
            this.ReservedSeats += seatsNumber;


    }

    public void RemoveSeats(int seatsNumber)
    {

            if (isValidDate() && ReservedSeats >= seatsNumber)
                this.ReservedSeats -= seatsNumber;
            else
            {
                throw new ArgumentOutOfRangeException("Not possible to remove this number of seats cause there no enough reserved seats to remove");
            }
    }

    public bool isValidDate()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        try
        {
            if (date.CompareTo(today) >= 0)
                return true;
            else
                throw new ArgumentException();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            Console.WriteLine("Date cannot be in the past, insert a valid date");
            return false;
        }
    }

    public int LeftSeats()
    {

            if (maxSeats - ReservedSeats >= 0)
                return maxSeats - ReservedSeats;
            else
                throw new FormatException("posti rimanenti non disponibili");
        
    }

    public override string ToString()
    {
        string dateStringFormat = date.ToString("dd/MM/yyyy");

        return dateStringFormat + " - " + Title;
    }

}



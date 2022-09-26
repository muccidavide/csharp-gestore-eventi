public class Event
{
    string title
    {
        get { return title; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                this.title = value;
            else
                throw new ArgumentException("Titile cannot be null or empty string", "value");
        }
    }

    DateOnly date
    {
        get { return date; }
        set
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            if (value > today)
                this.date = today;
            else
                throw new ArgumentException("Date cannot be in the past, insert a valid date", "value");

        }
    }

    int maxSeats
    {
        get { return maxSeats; }
        set
        {
            if (value > 0)
                this.maxSeats = value;
            else
                throw new ArgumentException("Max Seats value have to be valid number(>0)", "value");
        }
    }

    int reservedSeats { get; set; }

    public Event(string title, DateOnly date, int maxSeats)
    {
        this.title = title;
        this.date = date;
        this.maxSeats = maxSeats;
        this.reservedSeats = 0;
    }


    public void BookSeats(int seatsNumber)
    {
        if (isValidDate() && LeftSeats() < seatsNumber)
            this.reservedSeats += seatsNumber;


    }

    public void RemoveSeats(int seatsNumber)
    {
        if (isValidDate() && reservedSeats < seatsNumber)
            this.reservedSeats += seatsNumber;
        else
        {
            throw new ArgumentOutOfRangeException("Not possible to remove this number of seats cause there no enough reserved seats to remove");        }
    }

    public bool isValidDate()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        if (date > today)
            return true;
        else
            throw new ArgumentException("Date cannot be in the past, insert a valid date", "value");
    }

    public int LeftSeats()
    {
        if(maxSeats - reservedSeats >= 0)
        return maxSeats - reservedSeats;
        else
            throw new FormatException("There no enough seats available for this reservation");
    }

    public override string ToString()
    {
        string dateStringFormat = date.ToString("dd/MM/yyyy");

        return title + " - " + dateStringFormat;
    }

}



using System;
public class Event
{
    public string Title;

    public DateOnly date;
    int reservedSeats { get; set; }

    public int maxSeats;

    // Costruttore
    public Event(string title, DateOnly date, int maxSeats)
    {
        SetTitle(title);
        setDate(date);
        SetMaxSeats(maxSeats);
        this.reservedSeats = 0;
    }

    //Getters & Setters
    public string GetTitle()
    {
        return Title;
    }

    public void SetTitle(string value)
    {
        string titleTrimmed = String.Concat(value.Where(c => !Char.IsWhiteSpace(c)));
        try
        {
            if (!string.IsNullOrEmpty(titleTrimmed) && titleTrimmed != "")
                this.Title = value;
            else
            {
                throw new ArgumentException();
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            Console.WriteLine("Insert a valid concert title");
        }
    }

    public DateOnly GetDate()
    {
        return date;
    }

    public void setDate(DateOnly value)
    {

        try
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            if (value > today)
                this.date = today;
            else
                throw new ArgumentException();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            Console.WriteLine("Date cannot be in the past, insert a valid date");
        }
    }

    public int GetMaxSeats()
    {
        return maxSeats;
    }

    public void SetMaxSeats(int value)
    {
        if (value > 0)
            this.maxSeats = value;
        else
            throw new ArgumentException("Max Seats value have to be valid number(>0)", "value");
    }

    // Metodi
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
            throw new ArgumentOutOfRangeException("Not possible to remove this number of seats cause there no enough reserved seats to remove");
        }
    }

    public bool isValidDate()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        try
        {
            if (date > today)
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
        if (maxSeats - reservedSeats >= 0)
            return maxSeats - reservedSeats;
        else
            throw new FormatException("There no enough seats available for this reservation");
    }

    public override string ToString()
    {
        string dateStringFormat = date.ToString("dd/MM/yyyy");

        return Title + " - " + dateStringFormat;
    }

}


public class Conference : Event
{
    private string relator;
    private decimal price;

    public Conference(string _title, DateOnly _date, int _maxSeats, string relator, decimal price) : base(_title, _date, _maxSeats)
    {
        this.Relator = relator;
        this.Price = price;
    }

    public string Relator
    {
        get { return this.relator; }

        private set
        {


            if (value.Trim().Length != 0)
            {
                this.relator = value.Trim();
            }
            else
            {
                throw new Exception("Inserisci nome del relatore valido");
            }

        }

    }

    public decimal Price
    {
        get { return price; }

        private set
        {
            if (value >= 0)
            {
                this.price = value;
            }
            else
            {
                throw new Exception("Inserisci un prezzo valido");
            }

        }

    }

    public string GetFormattedPrice()
    {
        return price.ToString("0.00") + " euro";
    }

    public string GetFormattedDate()
    {
        return this.Date.ToString();
    }

    public override string ToString()
    {
        return $"{this.GetFormattedDate()} - {this.Title} - {this.Relator} - {this.GetFormattedPrice()}";
    }
}
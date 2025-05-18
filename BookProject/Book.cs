public class Book
{
    public string _title = "";
    public string _author = "";
    public int _yearPublished;

    public void DisplayInfo()
    {
        Console.WriteLine($"\"{_title}\" by {_author} ({_yearPublished})");
    }

    public int GetAge()
    {
        return DateTime.Now.Year - _yearPublished;
    }    
}
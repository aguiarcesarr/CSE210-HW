public class Person
{
    public string _givenName = "";
    public string _familyName = "";

    public Person() { }

    public void ShowEasternName()
    {
        Console.WriteLine($"{_familyName}, {_givenName}");
    }

    public void ShowWesternName()
    {
        Console.WriteLine($"{_givenName} {_familyName}");
    }
}

Class: Person
Attributes:
* _givenName : string
* _familyName : string

Behaviors:
* ShowEasternName() : void
* ShowWesternName() : void

Person person = new Person();
person._givenName = "Joseph";
person._familyName = "Smith";
person.ShowWesternName();  // Outputs: Joseph Smith

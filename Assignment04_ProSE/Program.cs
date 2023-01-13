// See https://aka.ms/new-console-template for more information
using Assignment04_ProSE;


public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Participant Kim = new Participant();
        List<Participant> Group1 = new List<Participant> { Kim };
        Kitty skiTrip = new Kitty(1, "asd", "skiTrip", Currency.EUR, Group1);

        skiTrip.GroupCost = 100;

        skiTrip.WhoSeen.Add(Kim);
    }
}

//Console.WriteLine("Hello, World!");


//var SktTrip = new Kitty("skitrip", List<Participant>(Tamira, Valery);
//var UsaTrip = new Kitty("skitrip", List<Participant>(Valery, Kim );]]

//var valsComment = new Comment(skiTrip, "hi");

//var Valery = new Participant();
//var Tamira = new Participant();



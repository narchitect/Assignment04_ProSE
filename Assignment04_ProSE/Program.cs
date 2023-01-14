// See https://aka.ms/new-console-template for more information
using Assignment04_ProSE;


public class Program
{
    static void Main(string[] args)
    { 
        var Kim = new Participant();
        {
            Kim.Name = "Kim";
            Kim.Seen = true;
            Kim.Total = 11.2;
            Kim.CurrentDebt = 3;
            Kim.Email = "ny.@icloud.com";
        }
        var KoreaTrip = new Kitty();
        {
            KoreaTrip.EventName = "KoreaTrip";
            KoreaTrip.Link = "url";
            KoreaTrip.HomeCurrency = Currency.KRW;
            KoreaTrip.GroupCost = 100.3;
            KoreaTrip.Pariticipants.Add(Kim);
        }

        using (var context = new KittyContext())
        {
            context.Kitties.Add(KoreaTrip);
            context.Participants.Add(Kim);
            context.SaveChanges();
        }
    }
}


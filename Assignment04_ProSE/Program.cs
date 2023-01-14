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
            Kim.Mark = true;
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

        var Comment = new Comment();
        {
            Comment.Content = "Hi, this is a comment";
            Comment.DateTime = new DateTime(2023, 1, 14, 9, 27, 0);
        }

        Kim.Comments.Add(Comment);

        var Payment = new Payment();
        {
            Payment.Purpose = "KoreanRestaurant";
            Payment.Amount = 1000;
            Payment.DateTime = DateTime.Now;
        }

        Kim.Payments.Add(Payment);

        using (var context = new KittyContext())
        {
            context.Kitties.Add(KoreaTrip);
            context.Participants.Add(Kim);
            context.Comments.Add(Comment);
            context.Payments.Add(Payment);
            context.SaveChanges();
        }
    }
}


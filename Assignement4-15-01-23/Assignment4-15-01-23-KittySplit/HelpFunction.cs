using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment4_15_01_23_KittySplit
{
    public class HelpFunction
    {
        public static void CommentOverview()
        {
            Console.WriteLine("Current Comments in the Database.");
            using (var context = new KittyContext())
            {
                var commentIds = context.Comments
                    .ToList();
                foreach (var comment in commentIds)
                {

                    Console.WriteLine("Comment: {0} , CommentId: {1} , CommentDate: {1}", comment.Content, comment.Id, comment.DateTime);
                }
            }
        }
        //Delete Comments
        public static void DeleteCommentFromDatabase()
        {
            Console.WriteLine("Current Comments in the Database.");
            using (var context = new KittyContext())
            {
                var commentIds = context.Comments
                    .ToList();
                foreach (var comment in commentIds)
                {                    
                    Console.WriteLine("Comment: {0} , CommentId: {1}", comment.Content, comment.Id);
                }
            }
            Console.WriteLine("Do you want to delet a comment? yes or no?");
            string userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                Console.WriteLine("Which Comment do you want to delete: Enter the Id:");
                int commentId = Convert.ToInt32(Console.ReadLine());

                using (var context = new KittyContext())
                {
                    List<Comment> comments = new List<Comment>()
                    {
                        new Comment{Id = commentId },
                    };
                    foreach (Comment comment in comments)
                    {
                        context.Comments.Remove(comment);
                    }
                    context.SaveChanges();
                }
                Console.WriteLine("Your comment was deleted.");
            }
            else if (userInput == "no")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong Comment Id. Try again");
                DeleteCommentFromDatabase();
            }
        }
        
        public static void AddComment()
        {
            Console.WriteLine("Do you want to add a comment? yes or no?");
            string userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                Console.WriteLine("Who are you?");
                using (var context = new KittyContext())
                {
                    var participantIds = context.Participants
                        .ToList();
                    foreach (var participant in participantIds)
                    {
                        Console.WriteLine("Name: {0} , ParticipantId: {1}", participant.Name, participant.Id);                        
                    }                    
                }
                Console.WriteLine("Enter your ParticipantId:");
                int participantId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Add a comment here: \n You can enter the text of your comment here:");
                string commentContent = Console.ReadLine();
                var YourComment = new Comment()
                {
                    Content = commentContent,
                    DateTime = new DateTime(2023, 1, 14, 9, 27, 0),
                    ParticipantId = participantId
                };
                using (var context = new KittyContext())
                {
                    context.Comments.Add(YourComment);
                    context.SaveChanges();

                }
                Console.WriteLine("Your comment was added.");
            }
            else if (userInput == "no")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong Comment Id. Try again");
                DeleteCommentFromDatabase();
            }

        }
        public static void AddParticipant()
        {
            Console.WriteLine("Do you want to add a participant? yes or no?");
            string userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                Console.WriteLine("You can add a participant here:");
                string participantName = Console.ReadLine();
                Console.WriteLine("You can add a participant email here:");
                string participantEmail = Console.ReadLine();
                Console.WriteLine("Current Kitties in the Database.");
                using (var context = new KittyContext())
                {
                    var KittiesIds = context.Kitties
                        .ToList();
                    foreach (var kitty in KittiesIds)
                    {
                        Console.WriteLine("Kitty Name: {0} , KittyID: {1}", kitty.EventName, kitty.Id);
                    }
                }
                Console.WriteLine("Enter your KittyId:");
                int kittyId = Convert.ToInt32(Console.ReadLine());
                var NewParticipant = new Participant()
                {
                    Name = participantName,
                    Seen = true,
                    Total = 0,
                    Mark = true,
                    Email = participantEmail,
                    KittyId = kittyId
                };
                using (var context = new KittyContext())
                {
                    context.Participants.Add(NewParticipant);
                    context.SaveChanges();
                }
                Console.WriteLine("Your participant was added.");
            }
            else if (userInput == "no")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong Comment Id. Try again");
                DeleteCommentFromDatabase();
            }

        }
        
        public static void CreateOverview()
        {
            //Group Cost
            //Group Cost: 
            Console.WriteLine("Do you want to see Kitty Overview? yes or no:");
            string userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                Console.WriteLine("These are the Kitties in the database.");
                using (var context = new KittyContext())
                {
                    var KittiesIds = context.Kitties
                        .ToList();
                    foreach (var kitty in KittiesIds)
                    {
                        Console.WriteLine("Kitty Name: {0} , KittyID: {1}", kitty.EventName, kitty.Id);
                    }
                }
                Console.WriteLine("Enter the Kitties name which overview you want to see:");
                string choosenKitty = Console.ReadLine();
                using (var context = new KittyContext())
                {
                    var groupCosts = context.Kitties
                        .Where(p => p.EventName == choosenKitty)
                        .ToList();
                    foreach (var groupCost in groupCosts)
                    {
                        Console.WriteLine("This event cost the group:");
                        Console.WriteLine(groupCost.GroupCost);
                    }
                }

                //Your Cost == total
                Console.WriteLine("These are the Participants in the database.");
                using (var context = new KittyContext())
                {
                    var participants = context.Participants
                        .ToList();
                    foreach (var participant in participants)
                    {
                        Console.WriteLine("Participant Name: {0} , Participant Id: {1}", participant.Name, participant.Id);
                    }
                }
                Console.WriteLine("Enter the Participant Name whose overview you want to see:");
                string choosenParticipant = Console.ReadLine();
                              
                using (var context = new KittyContext())
                {
                    var participants = context.Participants
                        .Where(p => p.Name == choosenParticipant)
                        .ToList();
                    foreach (var participant in participants)
                    {
                        Console.WriteLine("This event cost you:");
                        Console.WriteLine(participant.Total);
                    }
                }
            }

            else if (userInput == "Exit")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong startKeyWord, Write it again. To Exit, Write 'Exit'");
                CreateKitty();
            }

        }
        
        public static void ShowKittyLink()
        {
            Console.WriteLine("Do you want to invite people to your kitty?");
            string userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                Console.WriteLine("Enter the Kitties name which overview you want to see [Ski Trip/KoreaTrip/USATrip]:");
                string choosenKitty = Console.ReadLine();
                using (var context = new KittyContext())
                {
                    var links = context.Kitties
                        .Where(p => p.EventName == choosenKitty)
                        .ToList();
                    foreach (var link in links)
                    {
                        Console.WriteLine("This is your invitation link:");
                        Console.WriteLine(link.Link);
                    }
                }
            }
            else if (userInput == "Exit")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong startKeyWord, Write it again. To Exit, Write 'Exit'");
                ShowKittyLink();
            }
        }

        public static void CreateKitty()
        {
            Console.WriteLine("Welcome to KittySplit! to Start Kitty write 'Start Kitty'");
            string userInput = Console.ReadLine();

            // call the SetKittyInfos()functions
            if (userInput == "Start Kitty")
            {
                //set Eventname
                Console.WriteLine("Enter the event Name: ");
                string eventName = Console.ReadLine();


                //set SelectCurrency
                Console.WriteLine("Select Currency: ");
                List<string> currencyList = Enum.GetNames(typeof(Currency)).ToList();
                foreach (string c in currencyList)
                {
                    Console.WriteLine(c);
                }
                string userInputCurrency = Console.ReadLine();
                string homeCurrency = VaildCurrency(userInputCurrency);


                //set Participants

                //1. create participants list
                List<string> participantsNameList = new List<string>();
                //2. set creator with email
                Console.WriteLine("Enter the Creator Name: ");
                string creatorName = Console.ReadLine();

                Console.WriteLine("Enter the Creator's Email: (if you want to skip this part, write s)");
                string creatorEmail = Console.ReadLine();
                if (creatorEmail == "s")
                {
                    creatorEmail = null;
                }
                participantsNameList.Add(creatorName);

                //3. set other participant's names
                Console.WriteLine("If you want to add Participants, Write 'Add a participant's name'");
                
                string userInputParticipantName = Console.ReadLine();
                while (userInputParticipantName.IndexOf("Add") != -1)
                {
                    participantsNameList.Add(userInputParticipantName.Substring(4));
                    Console.WriteLine("Do you want to add more? or to finish, write anything");
                    userInputParticipantName = Console.ReadLine();
                }                

                //Print out the overview of the kitty
                Console.WriteLine("----- your kitty infos -----\n" +
                    "Event Name: {0}\n" +
                    "HomeCurrency: {1}\n" +
                    "Creator email: {2}\n" , eventName, homeCurrency, creatorEmail);

                for (int i = 0; i < participantsNameList.Count; i++)
                { Console.WriteLine("Participant{0} : {1}", i+1, participantsNameList[i]); }
                
                //CreateKitty();
            }

            else if (userInput == "Exit")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong startKeyWord, Write it again. To Exit, Write 'Exit'");
                CreateKitty();
            }
        }

        public static string VaildCurrency(string userInputCurrency)
        {
            var homeCurrency = new Currency();
            if (Enum.IsDefined(typeof(Currency), userInputCurrency))
            {
                homeCurrency = Enum.Parse<Currency>(userInputCurrency);
            }
            else
            {
                Console.WriteLine("Wrong Currency, Write a vaild Currency");
                userInputCurrency = Console.ReadLine();
                VaildCurrency(userInputCurrency);
            }
            return homeCurrency.ToString();
        }
    }
}

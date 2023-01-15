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
        public static void DeleteCommentFromDatabase()
        {
            Console.WriteLine("Which Comment do you want to delete ");
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
        }
        
        public static void AddComment()
        {
            Console.WriteLine("You can add a comment here:");
            string commentContent = Console.ReadLine();
            Console.WriteLine("Enter your ParticipantId[6/7]:");
            int participantId = Convert.ToInt32(Console.ReadLine());
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
        }
        public static void AddParticipant()
        {
            Console.WriteLine("You can add a participant here:");
            string participantName = Console.ReadLine();
            Console.WriteLine("You can add a participant email here:");
            string participantEmail = Console.ReadLine();
            Console.WriteLine("Enter your KittyId[10/14/15]:");
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
        }
        //public static void AddPayment()
        //{
        //    Console.WriteLine("You can add a payment here:");
        //    string purposePayment = Console.ReadLine();
        //    Console.WriteLine("You can add a participant email here:");
        //    string participantEmail = Console.ReadLine();
        //    Console.WriteLine("Enter your KittyId[10/14/15]:");
        //    int amountPayment = Convert.ToInt32(Console.ReadLine());
        //    var NewPayment = new Payment()
        //    {
        //        Purpose = purposePayment,

                
        //    };
        //    using (var context = new KittyContext())
        //    {
        //        context.Participants.Add(NewPayment);
        //        context.SaveChanges();
        //    }
        //}
        public static void CreateOverview()
        {
            //Group Cost
            //Group Cost: 
            Console.WriteLine("Do you want to see Kitty Overview? yes or no:");
            string userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                Console.WriteLine("Enter the Kitties name which overview you want to see [Ski Trip/KoreaTrip/USATrip]:");
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
                Console.WriteLine("Enter the Participant Name whose overview you want to see:");
                string choosenParticipant = Console.ReadLine();
                
                
                using (var context = new KittyContext())
                {
                    var participants = context.Participants
                        .Where(p => p.Name == "Valery")
                        .ToList();
                    foreach (var participant in participants)
                    {
                        Console.WriteLine("This event cost you:");
                        Console.WriteLine(participant.Total);
                    }
                }
            }

            else
            {
                Console.WriteLine("What do you want to do next?");
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
            else
            {
                Console.WriteLine("What do you want to do next?");
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

using System;

namespace Assignment04_ProSE
{
    public class HelpFunctions
    {
        public static Kitty CreateKitty()
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
                Currency homeCurrency = VaildCurrency(userInputCurrency);


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
                    "Creator email: {2}\n", eventName, homeCurrency.ToString(), creatorEmail);

                for (int i = 0; i < participantsNameList.Count; i++)
                { Console.WriteLine("Participant{0} : {1}", i + 1, participantsNameList[i]); }


                //Create Kitty obj
                Kitty aKitty;

                List<Participant> participants = new List<Participant>();
                var creator = new Participant(creatorName, creatorEmail);
                participants.Add(creator);
                for (int i = 1; i < participants.Count; i++)
                {
                    participants.Add(new Participant(participantsNameList[i]));
                }

                aKitty = new Kitty(eventName, homeCurrency);
                aKitty.Participants = participants;
                
                using (var context = new KittySplitContext())
                {
                    context.Kitties.Add(aKitty);
                    context.SaveChanges();
                }

                
                return aKitty;
            }

            else if (userInput == "Exit")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong startKeyWord, Write it again. To Exit, Write 'Exit'");
            }
            return null;
        }

        private static Currency VaildCurrency(string userInputCurrency)
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
            return homeCurrency;
        }

        ////Add Kitty
        //public static Kitty CreateKitty()
        //{


        //    using (var context = new KittyContext())
        //    {
        //        context.Kitties.Add(kitty);
        //        context.SaveChanges();
        //    }
        //}

        ////Add Participant
        //public static void AddParticipant(Participant participant)
        //{
        //    using (var context = new KittyContext())
        //    {
        //        context.Participants.Add(participant);
        //        context.SaveChanges();
        //    }            
        //}

        ////Add Expanses
        //public static void AddExpense(Expense expense)
        //{
        //    using (var context = new KittyContext())
        //    {
        //        context.Expenses.Add(expense);
        //        context.SaveChanges();
        //    }            


    }
}

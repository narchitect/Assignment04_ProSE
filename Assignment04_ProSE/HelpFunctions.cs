﻿using System;

namespace Assignment04_ProSE
{
    public class HelpFunctions
    {
        static Kitty aKitty { get; set; }
        static List<string> ParticipantsNames { get; set; }

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
                ParticipantsNames = participantsNameList;


                //Print out the overview of the kitty
                Console.WriteLine("----- your kitty infos -----\n" +
                    "Event Name: {0}\n" +
                    "HomeCurrency: {1}\n" +
                    "Creator email: {2}\n", eventName, homeCurrency.ToString(), creatorEmail);

                for (int i = 0; i < participantsNameList.Count; i++)
                { Console.WriteLine("Participant{0} : {1}", i + 1, participantsNameList[i]); }


                //Create Kitty obj
                List<Participant> participants = new List<Participant>();
                var creator = new Participant(creatorName, creatorEmail);
                participants.Add(creator);
                for (int i = 1; i < participantsNameList.Count; i++)
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


        //Add expense
        public static void AddPayment()
        {
            using (var context = new KittySplitContext())
            {
                var kitties = context.Kitties.ToList();

                //set the event

                //1. primt
                foreach (Kitty k in kitties)
                { Console.WriteLine("Event Lists: {0}", k.EventName); }

                Console.WriteLine("Select the event: ");
                string eventName = Console.ReadLine();

                Kitty currentKitty;
                while (true)
                {
                    currentKitty = VaildEventName(kitties, eventName);
                    if (currentKitty != null)
                    {
                        break;
                    }
                    Console.WriteLine("select a right eventName");
                    eventName = Console.ReadLine();
                }

                //set the owner
                var participants = context.Participants.Where(p => p.KittyId == currentKitty.Id)
                    .ToList();
                foreach (Participant p in participants)
                { Console.WriteLine("Participants : {0}", p.Name); }

                Console.WriteLine("Enter the ower of the payment: ");
                string ownerName = Console.ReadLine();
                while (VaildParticipantName(participants, ownerName) == null)
                {
                    Console.WriteLine("select a right participant");
                    ownerName = Console.ReadLine();
                }

                Console.WriteLine("Enter the payment purpose: ");
                string purpose = Console.ReadLine();

                Console.WriteLine("Enter the amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the DateTime: Example(mm/dd/yyyy)");
                string dateTimeName = Console.ReadLine();
                DateTime dateTime;
                while (true)
                {
                    dateTime = VaildDateTime(dateTimeName);
                    if (dateTime != null)
                    {
                        break;
                    }
                    dateTimeName = Console.ReadLine();
                }

                var ownerId = participants.Where(p => p.Name == ownerName)
                    .Select(p => p.Id).First();

                var aPayment = new Payment()
                {
                    Purpose = purpose,
                    Amount = amount,
                    DateTime = dateTime,
                    ParticipantId = ownerId
                };

                context.Payments.Add(aPayment);
                context.SaveChanges();

            }
        }
        
        private static DateTime VaildDateTime(string userInput)
        {
            DateTime dateTime;
            if (DateTime.TryParse(userInput, out dateTime))
            {
                dateTime = DateTime.Parse(userInput);
                return dateTime;
            }
            else
            {
                Console.WriteLine("wrong DateTime format. Try it again. Example(mm/dd/yyyy)");
                userInput = Console.ReadLine();
                VaildDateTime(userInput);
            }

            return dateTime;
        }

        private static Kitty VaildEventName(List<Kitty> kitties,string eventName)
        {
            foreach(Kitty k in kitties)
            {
                if (k.EventName == eventName) return k;
            }
            return null;
        }

        private static Participant VaildParticipantName(List<Participant> participants, string participantName)
        {
            foreach (Participant p in participants)
            {
                if (p.Name == participantName) return p;
            }
            return null;
        }

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
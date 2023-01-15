using Assignment4_15_01_23_KittySplit;
using Assignment4150123KittySplit.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;

public class Program
{
    static void Main(string[] args)
    {
        //HelpFunction.AddParticipant();
        //HelpFunction.AddComment();
        //HelpFunction.CreateOverview();
        HelpFunction.DeleteCommentFromDatabase();
        //HelpFunction.ShowKittyLink();

        //var Tony = new Participant()
        //{
        //    Name = "Tony",
        //    Seen = true,
        //    Total = 0,
        //    Mark = true,
        //    Email = "tony@email.com",
        //    KittyId = 1
        //};
        //var TonyComment = new Comment()
        //{
        //    Content = "I am tony",
        //    DateTime = new DateTime(2023, 1, 14, 9, 27, 0),
        //    ParticipantId = 5
                        
        //};
        //HelpFunction.CreateOverview();
        
        //
        //using (var context = new KittyContext())
        //{
            //Delete Items
            //List<Kitty> kitties = new List<Kitty>()
            //{
            //    new Kitty{Id = 3},
                
            //};
            //foreach(Kitty kitty in kitties)
            //{
            //    context.Kitties.Remove(kitty);
            //}
            
            //var comments = context.Comments
            //    .Where(c => c.Content == TonyComment.Content)
            //    .ToList();
            //foreach (var comment in comments)
            //{
            //    Console.WriteLine(comment.Content);
            //}
            //var participants = context.Participants
            //    .Where(p => p.Name == "Valery")
            //    .ToList();
            //foreach(var participant in participants)
            //{
            //    Console.WriteLine(participant.Total);
            //}
                  
            //context.SaveChanges();
        //}
       
        
    }
}

        

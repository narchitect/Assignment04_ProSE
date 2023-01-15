// See https://aka.ms/new-console-template for more information
using Assignment04_ProSE;


public class Program
{
    static void Main(string[] args)
    {
        //UseCase1. Create a Kitty
        HelpFunctions.CreateKitty();

        //UseCase2. Add a Payment
        HelpFunctions.AddPayment();

        //UseCase3. Add a Comment and Edit a Comment
        HelpFunctions.AddComment();
        HelpFunctions.DeleteCommentFromDatabase();
        HelpFunctions.CommentOverview();

        //UseCase4. Overview the kitty
        HelpFunctions.OverviwKitty();

        //UseCase5. Show the link
        HelpFunctions.ShowKittyLink();
    }
}


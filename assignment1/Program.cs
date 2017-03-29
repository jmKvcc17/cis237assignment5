//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();
            BeverageItemCollection BevAPI = new BeverageItemCollection();
            //Beverage searchBev;


            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:// **************IN UI
                        userInterface.PrintList();
                        break;
                    case 2: // **************in UI
                        userInterface.SearchDB();
                        break;
                    case 3:// **************in UI
                        BevAPI.AddToDB(userInterface.IDToAdd(), 
                                       userInterface.NameToAdd(), 
                                       userInterface.PackToAdd(), 
                                       userInterface.PriceToAdd(), 
                                       userInterface.ActiveToAdd());

                        break;
                    case 4:// **************Fix up***
                        userInterface.UpdateItem();
                        break;
                    case 5:
                        userInterface.deleteItem();
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}

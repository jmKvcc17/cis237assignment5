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

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Print the list of wine items
                        userInterface.PrintList();
                        break;
                    case 2:
                        // Search through the database by id
                        userInterface.SearchDB();
                        break;
                    case 3:
                        // Add an item to the database
                        userInterface.AddItem();
                        break;
                    case 4:
                        // Updates an existing in the database
                        userInterface.UpdateItem();
                        break;
                    case 5:
                        // Delete any item in the database
                        userInterface.deleteItem();
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}

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
                        Console.WriteLine(BevAPI.ToString());
                        /*
                        //Load the CSV File
                        bool success = true; //csvProcessor.ImportCSV(wineItemCollection, pathToCSVFile);
                        if (success)
                        {
                            //Display Success Message
                            userInterface.DisplayImportSuccess();
                        }
                        else
                        {
                            //Display Fail Message
                            userInterface.DisplayImportError();
                        }
                        */
                        break;

                    case 2:
                        string searchID = userInterface.IDToSearch();

                        Console.WriteLine();

                        Beverage searchBev = BevAPI.SearchForItem(searchID);

                        if (searchBev == null)
                            userInterface.NullError(searchID);
                        else
                        {
                            userInterface.DisplaySearch(searchBev);
                        }

                        break;

                    case 3:
                        BevAPI.AddToDB(userInterface.IDToAdd(), 
                                       userInterface.NameToAdd(), 
                                       userInterface.PackToAdd(), 
                                       userInterface.PriceToAdd(), 
                                       userInterface.ActiveToAdd());

                        break;

                    case 4:
                        //Add A New Item To The List
                        //string[] newItemInformation = userInterface.GetNewItemInformation();
                        //if (wineItemCollection.FindById(newItemInformation[0]) == null)
                       // {
                       //     wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2]);
                       //     userInterface.DisplayAddWineItemSuccess();
                       // }
                       // else
                       // {
                       //     userInterface.DisplayItemAlreadyExistsError();
                       // }
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}

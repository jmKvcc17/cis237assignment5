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
            //Set a constant for the size of the collection
            //const int wineItemCollectionSize = 4000;

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();
            BeverageItemCollection BevAPI = new BeverageItemCollection();

            //Create an instance of the WineItemCollection class
            //IBeverageCollection wineItemCollection = new BeverageItemCollection(wineItemCollectionSize);

            //BeverageJMeachumEntities testEntities = new BeverageJMeachumEntities();

           // foreach(Beverage bev in testEntities.Beverages)
            //{
           //     Console.WriteLine(bev.id);
           // }
            


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
                        //Print Entire List Of Items
                        //string[] allItems = wineItemCollection.GetPrintStringsForAllItems();
                        //if (allItems.Length > 0)
                       // {
                            //Display all of the items
                            //userInterface.DisplayAllItems(allItems);
                       // }
                        //else
                       // {
                            //Display error message for all items
                       //     userInterface.DisplayAllItemsError();
                       // }
                        break;

                    case 3:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        //string itemInformation = wineItemCollection.FindById(searchQuery);
                        //if (itemInformation != null)
                        //{
                       //     userInterface.DisplayItemFound(itemInformation);
                       // }
                       // else
                       // {
                       //     userInterface.DisplayItemFoundError();
                       // }
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

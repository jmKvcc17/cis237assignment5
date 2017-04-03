//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 6;

        private BeverageItemCollection BevAPI = new BeverageItemCollection(); // API object to interact with the database
        private Beverage searchBev;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        // *******Assignment 5 methods*******************
        // Displays instructions to update the database
        public void DisplayUpdateInfo()
        {
            Console.WriteLine();
            Console.WriteLine("You can update an item by entering in the ID.");
            Console.WriteLine("You cannot update the ID.");
        }

        // Allows the user to enter in a string to search for
        public string IDToSearch()
        {
            string userID = "";

            Console.WriteLine();
            Console.WriteLine("Enter in an ID to search for: ");
            displayArrow();
            userID = Console.ReadLine();

            while (userID == string.Empty)
            {
                Console.WriteLine("Enter in an ID to search for: ");
                userID = Console.ReadLine();
            }

            return userID;
        }

        // Displays error when the database is null
        public void NullError(string usrSrch)
        {
            Console.WriteLine();
            Console.WriteLine($"ID: {usrSrch} not found.");
        }

        // Displays the beverage info the user searched for
        public void DisplaySearch(Beverage userBev)
        {
            Console.WriteLine("ID: " + userBev.id);
            Console.WriteLine("\tName: " + userBev.name);
            Console.WriteLine("\tPack: " + userBev.pack);
            Console.WriteLine("\tCost: " + userBev.price.ToString("C"));
            Console.WriteLine("\tAvailable: " + userBev.active);
            DisplayDashes();
        }

        //Gets the id to add to the database
        public string IDToAdd()
        {
            string userID = "";

            Console.WriteLine("Enter in an ID to add: ");
            displayArrow();
            userID = Console.ReadLine();

            while (userID == string.Empty)
            {
                Console.WriteLine("Enter in an ID to add (cannot be emtpy): ");
                displayArrow();
                userID = Console.ReadLine();
            }

            return userID;
        }

        // Name to add to the databse
        public string NameToAdd()
        {
            string userName = "";

            Console.WriteLine("Enter in the name to add: ");
            displayArrow();
            userName = Console.ReadLine();

            while (userName == string.Empty)
            {
                Console.WriteLine("Enter in the name to add (cannot be emtpy): ");
                displayArrow();
                userName = Console.ReadLine();
            }

            return userName;
        }

        // Gets the pack to add to the database
        public string PackToAdd() // ***If time concat ml or lit to end
        {
            string userPack = "";

            Console.WriteLine("Enter in the pack to add: ");
            displayArrow();
            userPack = Console.ReadLine();

            while (userPack == string.Empty)
            {
                Console.WriteLine("Enter in the pack to add (cannot be emtpy): ");
                displayArrow();
                userPack = Console.ReadLine();
            }

            return userPack;
        }

        // Gets the price to add to the database
        public decimal PriceToAdd()
        {
            decimal userPrice = 0m;
            bool badInput = false;
            string temp;

            while (!badInput)
            {
                Console.WriteLine("Enter in the price: ");
                displayArrow();
                temp = Console.ReadLine();
                if (decimal.TryParse(temp, out userPrice))
                {
                    userPrice = decimal.Parse(temp);
                    badInput = true;
                }
            }

            return userPrice;
        }

        // Asks the user if the product 
        // Is still active
        public bool ActiveToAdd()
        {
            bool isActive;
            string temp;

            Console.WriteLine("Is the product still active? (y/n)");
            displayArrow();
            temp = Console.ReadLine();

            // While the the choice isn't y or n
            while (temp != "y" && temp != "n")
            {
                Console.WriteLine("Is the product still active? (y/n)");
                displayArrow();
                temp = Console.ReadLine();
            }

            if (temp == "y")
                isActive = true;
            else
                isActive = false;


            return isActive;
        }

        // **************UPDATING
        // Get the update string, check to make sure
        // it exists, then pass the object to UpdateExistItem
        public void UpdateItem()
        {
            string updateString = "";
            this.DisplayUpdateInfo();
            updateString = this.IDToSearch();

            searchBev = BevAPI.SearchForItem(updateString);

            // If the item is null, the item does not exist
            if (searchBev == null)
                this.NullError(updateString);
            else
            {
                // Display the item, then pass it
                Console.WriteLine();
                this.DisplaySearch(searchBev);

                this.UpdateExistItem(searchBev);
            }
        }

        // Displays update informatoin, gets the ID to search for
        public void UpdateExistItem(Beverage updateBev)
        {
            int userChoice;
            string userString;

            Console.WriteLine();
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Pack");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Availability");
            displayArrow();

            userString = Console.ReadLine();

            // The input is bad, loop until it is correct
            while (!this.checkInput(userString))
            {
                Console.WriteLine("Input error. Try again.");
                displayArrow();
                userString = Console.ReadLine();
            }

            userChoice = int.Parse(userString); 

            // Pass the userChoice and beverage var to UpdateChoice
            this.UpdateChoice(userChoice, updateBev);
        }

        // Ges the name, pack, price and availability and adds
        // it the userBev, then passes userBev to BevAPI
        public void UpdateChoice(int userChoice, Beverage userBev) // ******* Looop
        {
            switch (userChoice)
            {
                // If userChoice is...
                case 1:
                    // Update the name, add the name to userBev
                    string name = this.NameToAdd();
                    userBev.name = name;
                    break;
                case 2:
                    string pack = this.PackToAdd();
                    userBev.pack = pack;
                    break;
                case 3:
                    decimal price = this.PriceToAdd();
                    userBev.price = price;
                    break;
                case 4:
                    bool active = this.ActiveToAdd();
                    userBev.active = active;
                    break;
            }

            // Once all the changes have been made, add the item to 
            // UpdateExistItem
            BevAPI.UpdateExistItem(userBev);
            DisplayDashes();

        }

        // Checks the input of the update function
        // to make sure it is correct
        public bool checkInput(string temp)
        {
            bool input = false;
            int num;

            try
            {
                num = int.Parse(temp);

                // if the number is between 1-4
                if (num > 0 && num < 5)
                {
                    input = true;
                }
            }
            catch
            {
                Console.WriteLine("Input error.");
            }

            return input;
        }

        // Displays deletion instructions, 
        // gets the ID to delete and sends it to
        // DeleteItem
        public void deleteItem()
        {
            Console.WriteLine();
            Console.WriteLine("Enter an ID for deletion.");
            displayArrow();
            string userSearch = this.IDToSearch();

            BevAPI.DeleteItem(userSearch);
            DisplayDashes();
        }

        // Prints the entire database list
        public void PrintList()
        {
            Console.WriteLine(BevAPI.ToString());
            DisplayDashes();
        }

        // All the user to search through the database
        public void SearchDB()
        {
            // Get the ID to search for
            string searchID = this.IDToSearch();

            Console.WriteLine();

            // Search function in BevAPI returns 
            // the found Beverage
            searchBev = BevAPI.SearchForItem(searchID);

            // if it is null the search failed, 
            // else display the serach information
            if (searchBev == null)
                this.NullError(searchID);
            else
            {
                this.DisplaySearch(searchBev);
            }
        }

        // Adds the item to the database
        public void AddItem()
        {
            BevAPI.AddToDB(this.IDToAdd(),
                                       this.NameToAdd(),
                                       this.PackToAdd(),
                                       this.PriceToAdd(),
                                       this.ActiveToAdd());

            DisplayDashes();
        }

        // STATIC METHODS**********
        // Error methods

        // Displays when a product has been removed
        static public void DisplayDeletedItem(string uID)
        {
            Console.WriteLine($"ID: {uID} has been removed.");
            Console.WriteLine();
        }

        // Displays when a searched ID cannot be removed
        static public void DisplayDeleteError()
        {
            Console.WriteLine("ID does not exist. Cannot remove.");
        }

        // Displays error when an item cannot be added
        static public void DisplayUpdateError()
        {
            Console.WriteLine("Error. Item cannot be added.");
            Console.WriteLine("Item may be null");
        }

        // Displays when an item cannot be added
        static public void DisplayAddError()
        {
            Console.WriteLine("ERROR. Item cannot be added.");
        }

        // Displays astericks for neatness
        static private void DisplayDashes()
        {
            Console.WriteLine("***********************************");
        }

        // Displays an arrow to show where input is
        static private void displayArrow()
        {
            Console.Write(">");
        }


        // **************End assignment5 methods********************************

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the beverage program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();
            displayArrow();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();
                displayArrow();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }


        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Print the list of items.");
            Console.WriteLine("2. Search for a beverage by item ID");
            Console.WriteLine("3. Add a new beverage");
            Console.WriteLine("4. Update an existing beverage");
            Console.WriteLine("5. Delete a beverage");
            Console.WriteLine("6. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }
    }
}

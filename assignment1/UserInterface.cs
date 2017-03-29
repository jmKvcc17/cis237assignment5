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

        private BeverageItemCollection BevAPI = new BeverageItemCollection();
        private Beverage searchBev;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        // *******Assignment 5 methods*******************
        public void DisplayUpdateInfo()
        {
            Console.WriteLine();
            Console.WriteLine("You can update an item by entering in the ID.");
            Console.WriteLine("You cannot update the ID.");
        }

        public string IDToSearch()
        {
            string userID = "";

            Console.WriteLine();
            Console.WriteLine("Enter in an ID to search for: ");
            userID = Console.ReadLine();

            while (userID == string.Empty)
            {
                Console.WriteLine("Enter in an ID to search for: ");
                userID = Console.ReadLine();
            }

            return userID;
        }

        public void NullError(string usrSrch)
        {
            Console.WriteLine();
            Console.WriteLine($"ID: {usrSrch} not found.");
        }

        public void DisplaySearch(Beverage userBev)
        {
            Console.WriteLine("ID: " + userBev.id);
            Console.WriteLine("Name: " + userBev.name);
            Console.WriteLine("Pack: " + userBev.pack);
            Console.WriteLine("Cost: " + userBev.price.ToString("C"));
            Console.WriteLine("Available: " + userBev.active);
        }

        public string IDToAdd()
        {
            string userID = "";

            Console.WriteLine("Enter in an ID to add: ");
            userID = Console.ReadLine();

            while (userID == string.Empty)
            {
                Console.WriteLine("Enter in an ID to add (cannot be emtpy): ");
                userID = Console.ReadLine();
            }

            return userID;
        }

        public string NameToAdd()
        {
            string userName = "";

            Console.WriteLine("Enter in the name to add: ");
            userName = Console.ReadLine();

            while (userName == string.Empty)
            {
                Console.WriteLine("Enter in the name to add (cannot be emtpy): ");
                userName = Console.ReadLine();
            }

            return userName;
        }

        public string PackToAdd() // ***If time concat ml or lit to end
        {
            string userPack = "";

            Console.WriteLine("Enter in the pack to add: ");
            userPack = Console.ReadLine();

            while (userPack == string.Empty)
            {
                Console.WriteLine("Enter in the pack to add (cannot be emtpy): ");
                userPack = Console.ReadLine();
            }

            return userPack;
        }

        public decimal PriceToAdd()
        {
            decimal userPrice = 0m;
            bool badInput = false;
            string temp;

            while (!badInput)
            {
                Console.WriteLine("Enter in the price: ");
                temp = Console.ReadLine();
                if (decimal.TryParse(temp, out userPrice))
                {
                    userPrice = decimal.Parse(temp);
                    badInput = true;
                }
            }

            return userPrice;
        }

        public bool ActiveToAdd()
        {
            bool isActive;
            string temp;

            Console.WriteLine("Is the product still active? (y/n)");
            temp = Console.ReadLine();

            while (temp != "y" && temp != "n")
            {
                Console.WriteLine("Is the product still active? (y/n)");
                temp = Console.ReadLine();
            }

            if (temp == "y")
                isActive = true;
            else
                isActive = false;


            return isActive;
        }

        public void UpdateExistItem(Beverage updateBev)
        {
            int userChoice;
            string userString;

            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Pack");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Availability");

            userString = Console.ReadLine();

            while (!this.checkInput(userString))
            {
                Console.WriteLine("Input error. Try again.");
                userString = Console.ReadLine();
            }

            userChoice = int.Parse(userString);

            this.UpdateChoice(userChoice, updateBev);
        }

        public void UpdateChoice(int userChoice, Beverage userBev)
        {
            switch (userChoice)
            {
                case 1:
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

            BevAPI.UpdateExistItem(userBev);

        }

        public bool checkInput(string temp)
        {
            bool input = false;
            int num;

            try
            {
                num = int.Parse(temp);

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

        public void deleteItem()
        {
            Console.WriteLine();
            Console.WriteLine("Enter an ID for deletion.");
            string userSearch = this.IDToSearch();

            BevAPI.DeleteItem(userSearch);
        }

        public void PrintList()
        {
            Console.WriteLine(BevAPI.ToString());
        }

        public void SearchDB()
        {
            string searchID = this.IDToSearch();

            Console.WriteLine();

            searchBev = BevAPI.SearchForItem(searchID);

            if (searchBev == null)
                this.NullError(searchID);
            else
            {
                this.DisplaySearch(searchBev);
            }
        }

        public void UpdateItem()
        {
            string updateString = "";
            this.DisplayUpdateInfo();
            updateString = this.IDToSearch();

            searchBev = BevAPI.SearchForItem(updateString);

            if (searchBev == null)
                this.NullError(updateString);
            else
            {
                this.DisplaySearch(searchBev);

                this.UpdateExistItem(searchBev);
            }
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

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

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
            Console.Write("Enter Your Choice: ");
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

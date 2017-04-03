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
    class BeverageItemCollection
    {
        private BeverageJMeachumEntities bevEntities = new BeverageJMeachumEntities(); // Entity Framework object to access database rows
        private Beverage searchBeverage = new Beverage(); // object to hold the searched beverage
        private Beverage bevToAdd = new Beverage(); // object to hold the beverage the user wants to add
       
        public BeverageItemCollection() { } // Default constructor

        // Override the ToString method to print the entire database
        public override string ToString()
        {
            string returnString = "";

            foreach(Beverage bev in bevEntities.Beverages)
            {
                if (bev != null)
                    returnString += "-----------------------------------" + Environment.NewLine  +
                        "ID: " + bev.id + Environment.NewLine +
                        "\t" + "Item Name: " + bev.name + Environment.NewLine +
                        "\t" + "Item pack: " + bev.pack + Environment.NewLine +
                        "\t" + "Item cost: " + bev.price.ToString("C") + Environment.NewLine + 
                        "\t" + "Item available: " + bev.active + Environment.NewLine + Environment.NewLine;
            }

            return returnString;
        }
        // Takes a string from the user, then uses bevEntities to search
        // for the item, then return it
        public Beverage SearchForItem(string userSearch)
        {
            searchBeverage = bevEntities.Beverages.Find(userSearch);

            return searchBeverage;
        }
         // Accepts the user input (id, name, pack, price, availability) and adds the item
         // to the database
        public void AddToDB(string Uid, string Uname, string Upack, decimal Uprice, bool Uactive)
        {
            bevToAdd.id = Uid;
            bevToAdd.name = Uname;
            bevToAdd.pack = Upack;
            bevToAdd.price = Uprice;
            bevToAdd.active = Uactive;

            // Try to add the item, if it fails remove it and display
            // an error message
            try
            {
                bevEntities.Beverages.Add(bevToAdd);

                bevEntities.SaveChanges();
            }
            catch
            {
                UserInterface.DisplayAddError();
                bevEntities.Beverages.Remove(bevToAdd);
            }
        }

        // Updates an existing beverage
        public void UpdateExistItem(Beverage updateBev)
        {
            // Finds the beverage to update with updateBev's id
            Beverage updateVar = bevEntities.Beverages.Where(beverage => beverage.id == updateBev.id).First();

            // Adds updateBev's data to updateVar's
            if (updateVar != null)
            {
                updateVar.name = updateBev.name;
                updateVar.pack = updateBev.pack;
                updateVar.price = updateBev.price;
                updateVar.active = updateBev.active;

                bevEntities.SaveChanges();
            }
            else
            {
                UserInterface.DisplayUpdateError();
            }
        }

        // Deletes the specified item 
        public void DeleteItem(string BevID)
        {
            // Find the user-specified item, remove it, save changes
            try
            {
                Beverage delBev = bevEntities.Beverages.Find(BevID);
                bevEntities.Beverages.Remove(delBev);
                bevEntities.SaveChanges();
                UserInterface.DisplayDeletedItem(BevID);
            }
            // If there's an error, display message
            catch
            {
                UserInterface.DisplayDeleteError();
            }
            
        }

    }
}

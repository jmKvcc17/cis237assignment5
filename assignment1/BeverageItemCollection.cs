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
        private BeverageJMeachumEntities bevEntities = new BeverageJMeachumEntities();
        private Beverage searchBeverage = new Beverage();
        private Beverage bevToAdd = new Beverage();
        

        public BeverageItemCollection() { }

        public override string ToString()
        {
            string returnString = "";

            foreach(Beverage bev in bevEntities.Beverages)
            {
                if (bev != null)
                    returnString += "------------------------------" + Environment.NewLine  +
                        "ID: " + bev.id + Environment.NewLine +
                        "\t" + "Item Name: " + bev.name + Environment.NewLine +
                        "\t" + "Item pack: " + bev.pack + Environment.NewLine +
                        "\t" + "Item cost: " + bev.price.ToString("C") + Environment.NewLine + 
                        "\t" + "Item available: " + bev.active + Environment.NewLine + Environment.NewLine;
            }

            return returnString;
        }

        public Beverage SearchForItem(string userSearch)
        {
            searchBeverage = bevEntities.Beverages.Find(userSearch);

            return searchBeverage;
        }

        public void AddToDB(string Uid, string Uname, string Upack, decimal Uprice, bool Uactive)
        {
            bevToAdd.id = Uid;
            bevToAdd.name = Uname;
            bevToAdd.pack = Upack;
            bevToAdd.price = Uprice;
            bevToAdd.active = Uactive;

            try
            {
                bevEntities.Beverages.Add(bevToAdd);

                bevEntities.SaveChanges();
            }
            catch
            {
                Console.WriteLine("ERROR. Entry cannot be added. ID conflict."); // ********UI
                bevEntities.Beverages.Remove(bevToAdd);
            }
        }

        public void UpdateExistItem(Beverage updateBev)
        {
            Beverage updateVar = bevEntities.Beverages.Where(beverage => beverage.id == updateBev.id).First();

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
                Console.WriteLine("Error"); // *******UI
            }
        }

        public void DeleteItem(string BevID) // **********UI
        {
            try
            {
                Beverage delBev = bevEntities.Beverages.Find(BevID);
                bevEntities.Beverages.Remove(delBev);
                bevEntities.SaveChanges();
                Console.WriteLine($"ID: {BevID} has been removed.");
                Console.WriteLine();
            }
            catch // *****Efficiency
            {
                Console.WriteLine("ID does not exist. Cannot remove.");
            }
            
        }

    }
}

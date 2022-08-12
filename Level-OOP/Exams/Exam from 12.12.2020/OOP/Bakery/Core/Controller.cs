namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IList<IBakedFood> bakedFoods;
        private readonly IList<IDrink> drinks;
        private readonly IList<ITable> tables;

        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            switch (type)
            {
                case nameof(Tea): drink = new Tea(name, portion, brand); break;
                case nameof(Water): drink = new Water(name, portion, brand); break;
            }

            drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;

            switch (type)
            {
                case nameof(Bread): bakedFood = new Bread(name, price); break;
                case nameof(Cake): bakedFood = new Cake(name, price); break;
            }

            bakedFoods.Add(bakedFood);
            return string.Format(OutputMessages.FoodAdded, name, bakedFood.GetType().Name);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            switch (type)
            {
                case nameof(InsideTable): table = new InsideTable(tableNumber, capacity); break;
                case nameof(OutsideTable): table = new OutsideTable(tableNumber, capacity); break;
            }

            tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();

            var freeTables = tables.Where(x => x.IsReserved == false).ToList();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables
                .FirstOrDefault(x => x.IsReserved == false
                && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}

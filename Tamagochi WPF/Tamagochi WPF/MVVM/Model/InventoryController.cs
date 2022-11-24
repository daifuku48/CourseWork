using System;
//using Internal;
using System.Collections.Generic;

namespace Tamagochi_WPF
{
    public class Item
    {
        public IFood food;
        public int amount;
        public Item() { }
        public Item(IFood food_, int amount_ = 1)
        {
            food = food_;
            amount = amount_;
        }
        public static bool operator ==(Item this_, Item other_)
        {
            return this_.food == other_.food;
        }
        public static bool operator !=(Item this_, Item other_)
        {
            return this_.food != other_.food;
        }
    }
    public class InventoryController // (-_*)
    {
        public List<Item> items_ = new List<Item>();
        // Список продуктів у інвентарі
        // Список кількості продуктів
        public List<Item> products_ = new List<Item>();

        public void FillProducts(IFood[] food)
        {
            for (int i = 0; i < food.Length; i++)
            {
                products_.Add(new Item(food[i]));
            }
        }

        public String Crafting(IFood food_, int amount_ = 1)
        {
            try
            {
                if (!food_.HasRecipe())
                {
                    throw new ExceptionController("Error: Base class product could not de instantiated.");
                }
                // помилка базового продукту не може бути створено.

                //if (!CheckCrafting(food_)) return "trash";
                // помилка не має потрібних інгредієнтів.

                foreach (string item_name in food_.Recipe)
                {
                    items_.Find(obj => obj.food.Name == item_name).amount -= 1;
                    if (items_.Find(obj => obj.food.Name == item_name).amount == 0)
                        items_.Remove(items_.Find(obj => obj.food.Name == item_name));
                }
                // вилучення всіх інгредієнтів із інвентарю

                Add(food_, amount_);
                // додавання продукту(_food) до інвентарю

                return food_.Name;
            }
            catch (ExceptionController ex) 
            {
                Console.WriteLine(ex.Message);
                return "trash";
            }
        }

        public String Craft(IFood[] items, string itemName1, string itemName2)
        {

            try
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].HasRecipe())
                    {
                        string[] recipe = items[i].Recipe;
                        if ((recipe[0] == itemName1 && recipe[1] == itemName2) || 
                            (recipe[1] == itemName1 && recipe[0] == itemName2))
                        {
                            return Crafting(items[i]);
                        }
                    }
                }
                throw new ExceptionController("Error: Udefined item.");
            }
            catch (ExceptionController ex)
            {
                Console.WriteLine(ex.Message);
                return "trash";
            }
        }

        public void Add(IFood food_, int amount_ = 1)
        {
            if (CheckItem(food_))
            {
                for (int index = 0; index < amount_; index++)
                {
                    items_.Find(obj => obj.food.Name == food_.Name).amount += 1;
                }
            }
            else
            {
                items_.Add(new Item(food_, amount_));
            }
        }

        public void Remove(IFood food_)
        {
            try
            {
                if (items_.Count == 0)
                {
                    throw new ExceptionController("Error: Product list is empty.");
                }
                // помилка список продуктів порожній.

                items_.Remove(items_.Find(obj => obj.food == food_));
                //видалення продукту із інвентарю
            }
            catch (ExceptionController ex) 
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public bool CheckItem(IFood food_)
        {
            foreach (Item item in items_)
                if (item.food.Name == food_.Name && item.amount > 0) return true;
            return false;
        }

        public bool CheckItem(string name_)
        {
            foreach (Item item in items_)
                if (item.food.Name == name_ && item.amount > 0) return true;
            return false;
        }

        private bool CheckCrafting(IFood food_)
        {
            foreach (string name in food_.Recipe)
                if (CheckItem(name)) return false;
            return true;
        }
        // перевірка наявності всіх інгредієнтів для крафту продукту

        public void Debug()
        {
            for (int index = 0; index < items_.Count; index++)
                Console.WriteLine($"Name: {items_[index].food.Name} | Count: {items_[index].amount}");
        }
    }
}
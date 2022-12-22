using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tamagochi_WPF;

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
        public List<Item> _items = new List<Item>();
        // Список продуктів у інвентарі

        public InventoryController(List<IFood> foods_)
        {
            foreach (IFood food in foods_)
            {
                _items.Add(new Item(food));
            }
        }

        // Test U( t _ t )U
        public IFood Craft(string ingredient_right_, string ingredient_left_)
        {
            if (!CheckItem(ingredient_right_) || !CheckItem(ingredient_left_))
            {
                return new Trash();
            }

            foreach (Item item in this._items)
            {
                if (item.food.Recipe == null)
                {
                    continue;
                }
                if ((item.food.Recipe[0] == ingredient_right_ && item.food.Recipe[1] == ingredient_left_) || (item.food.Recipe[1] == ingredient_right_ && item.food.Recipe[0] == ingredient_left_))
                {
                    foreach (string item_name in item.food.Recipe)
                    {
                        this._items.Find(obj => obj.food.Name == item_name).amount -= 1;

                        if (_items.Find(obj => obj.food.Name == item_name).amount == 0)
                        {
                            _items.Remove(_items.Find(obj => obj.food.Name == item_name));
                        }
                    }
                    return item.food;
                }
            }
            return new Trash();
        }

/*        private bool CheckItem(IFood item_, int amount_ = 1)
        {
            foreach (Item item in this._items)
            {
                if (item_.Name == item.food.Name && item.amount >= amount_)
                {
                    return true;
                }
            }
            return false;
        }
*/
        public void Add(IFood food_, int amount_ = 1)
        {
            if (CheckItem(food_))
            {
                for (int index = 0; index < amount_; index++)
                {
                    _items.Find(obj => obj.food.Name == food_.Name).amount += 1;
                }
            }
            else
            {
                _items.Add(new Item(food_, amount_));
            }
        }

        public void Remove(IFood food_)
        {
            try
            {
                if (_items.Count == 0)
                {
                    throw new ExceptionController("Error: Product list is empty.");
                }
                // помилка список продуктів порожній.

                _items.Remove(_items.Find(obj => obj.food == food_));
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
            foreach (Item item in _items)
                if (item.food.Name == food_.Name && item.amount > 0) return true;
            return false;
        }

        public bool CheckItem(string name_)
        {
            foreach (Item item in _items)
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
        public void Clear()
        {
            _items.Clear();
        }
    }
}
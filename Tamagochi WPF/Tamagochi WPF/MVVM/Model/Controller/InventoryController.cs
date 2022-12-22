using System;
using System.Collections.Generic;
/*using System.Reflection;
using System.Runtime.InteropServices;
using Tamagochi_WPF;
*/
namespace Tamagochi_WPF
{
    public class InventoryController // (-_*)
    {
        //=VARS==============================================================
        #region [ VARS ]
        // Список продуктів у інвентарі
        public List<Item>       _items = new List<Item>();
        private List<IFood>     _food_list = new List<IFood>();
        #endregion
        //=END_VARS==========================================================


        //=FUNCTIONS=========================================================
        #region [ FUNCTIONS ]
        public InventoryController()
        {
            init_food_list();
        }
        
        public InventoryController(List<IFood> foods_)
        {
            init_food_list();
            foreach (IFood food in foods_)
            {
                _items.Add(new Item(food));
            }
        }

        private void init_food_list() 
        {
            _food_list.Add(new Sugar());
            _food_list.Add(new Salt());
            _food_list.Add(new Water());
            _food_list.Add(new Fire());
            _food_list.Add(new Duck());
            _food_list.Add(new Corn());
            _food_list.Add(new Fish());
            _food_list.Add(new Egg());
            _food_list.Add(new Mushroom());
            _food_list.Add(new Marshmallow());
            _food_list.Add(new Vegetable());
            _food_list.Add(new Flakes());
            _food_list.Add(new Bread());
            _food_list.Add(new Pie());
            _food_list.Add(new Jam());
            _food_list.Add(new Compote());
            _food_list.Add(new Jelly());
            _food_list.Add(new Omelette());
            _food_list.Add(new Pancake());
            _food_list.Add(new Toast());
            _food_list.Add(new GrilledVegetables());
            _food_list.Add(new Salad());
            _food_list.Add(new Steak());
            _food_list.Add(new Rice());
            _food_list.Add(new RiceVegetables());
            _food_list.Add(new Popcorn());
            _food_list.Add(new VegetableSoup());
            _food_list.Add(new MushroomSoup());
            _food_list.Add(new FishSoup());
            _food_list.Add(new Trash());
        }

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

        public void Remove(string name_)
        {
            try
            {
                if (_items.Count == 0)
                {
                    throw new ExceptionController("Error: Product list is empty.");
                }
                // помилка список продуктів порожній.
                if (CheckItem(name_))
                {
                    for (int index = 0;
                        index < _items.Count;
                        index++)
                    {
                        if (_items[index].food.Name == name_)
                        {
                            _items[index].amount -= 1;
                        }
                    }
                }
            }
            catch (ExceptionController ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public IFood Craft(string ingredient_right_, string ingredient_left_)
        {
            if (!CheckItem(ingredient_right_) || !CheckItem(ingredient_left_))
            {
                Remove(ingredient_right_);
                Remove(ingredient_left_);
                return new Trash();
            }

            for (int index = 0;
                index < _food_list.Count;
                index++)
            {
                if (_food_list[index].Recipe == null)
                {
                    continue;
                }
                if ((_food_list[index].Recipe[0] == ingredient_right_ && _food_list[index].Recipe[1] == ingredient_left_) ||
                    (_food_list[index].Recipe[0] == ingredient_left_ && _food_list[index].Recipe[1] == ingredient_right_))
                {
                    Remove(ingredient_right_);
                    Remove(ingredient_left_);
                    return _food_list[index];
                }
            }

            Remove(ingredient_right_);
            Remove(ingredient_left_);
            return new Trash();
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
        #endregion
        //=END_FUNCTIONS=====================================================
    }
}
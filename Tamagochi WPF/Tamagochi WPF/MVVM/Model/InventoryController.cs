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
        // список продуктов в инвентаре
        // список количества продуктoв

        public bool Crafting(IFood food_, int amount_ = 1)
        {
            if (!food_.HasRecipe()) return false;
            // ошибка базовый продукт не может быть создан.

            if (!CheckCrafting(food_)) return false;
            // ошибка нет нужных ингридиентов.

            foreach (string item_name in food_.Recipe)
            {
                items_.Find(obj => obj.food.Name == item_name).amount -= 1;
                // спросишь что это за хуйня?
                if (items_.Find(obj => obj.food.Name == item_name).amount == 0)
                    items_.Remove(items_.Find(obj => obj.food.Name == item_name));
                // очистка инвентаря от хуйни(всех продуктов количество которых == 0)
            }
            // изятие всех ингридиентов из инвентаря

            Add(food_, amount_);
            // добавление продукта(_food) в инвентарь

            return true;
        }

        public void Add(IFood food_, int amount_ = 1)
        {
            if (CheckItem(food_))
                for (int index = 0; index < amount_; index++)
                    items_.Find(obj => obj.food.Name == food_.Name).amount += 1;
            else
                items_.Add(new Item(food_, amount_));
        }

        public void Remove(IFood food_)
        {
            if (items_.Count == 0) return;
            // ошибка список продуктов пуст. 

            items_.Remove(items_.Find(obj => obj.food == food_));
            // удаление продукта из инвентаря
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
        // проверка наличия всех ингридиентов для крафта продукта

        public void Debug()
        {
            for (int index = 0; index < items_.Count; index++)
                Console.WriteLine($"Name: {items_[index].food.Name} | Count: {items_[index].amount}");
        }
        // тут понятно
    }
}
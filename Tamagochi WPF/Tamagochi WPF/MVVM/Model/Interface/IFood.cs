namespace Tamagochi_WPF
{
    public interface IFood
    {
        // имя продукта
        string Name { get; }
        // количество здоровья которое востанавливает продукт
        int Heal { get; }
        // количество отравление продуктом
        int Poison { get; }
        // количество счастья
        int Happy { get; }
        // количество насыщения
        int Satiety { get; }
        // рецепт а точнеее список необходимых ингредиентов
        string[] Recipe { get; }
        // является ли объект приготовляемый(true) или базовым(false) продуктом
        bool HasRecipe(); 
    }
}

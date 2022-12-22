namespace Tamagochi_WPF
{
    class TamagochiJson
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public TamagochiJson(string name, int timeOflife)
        {
            Name = name;
            Rating = timeOflife;
        }
        public TamagochiJson()
        {
            Name = "";
            Rating = 0;
        }
    }
}

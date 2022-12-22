namespace Tamagochi_WPF
{
    public class TamagochiXml
    {
        public TamagochiXml() { }
        public TamagochiXml(Tamagochi t, int timeOfLife)
        {
            Name = t.Name;
            Happines = t.Happines;
            Poisoning = t.Poisoning;
            Saturation = t.Saturation;
            Heal = t.Heal;
            this.timeOflife = timeOfLife;
        }
        public string Name { get; set; }
        public int Happines { get; set; }
        public int Poisoning { get; set; }
        public int Saturation { get; set; }
        public int Heal { get; set; }
        public int timeOflife { get; set; }
    }
}

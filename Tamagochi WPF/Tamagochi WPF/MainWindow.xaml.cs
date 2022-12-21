using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;
using System.Text.Json;
using System.Reflection;
using System.Xml.Serialization;

namespace Tamagochi_WPF
{
    /// <summary>
    /// Логіка взаємодії для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer, timerstart, timerEnd, timerTop , timerDevelopers, timerInstruction, timerForTamagochi, timerForTakeEat, timerOfLife, timerForGifPetting, timerForEatGif;

        double MenuWidth , StartGameHeight, EndGameHeight, DelevopersGameHeight , InstructionGameHeight, TopGameHeight;
        bool hiddenMenu , StartGamehidden , EndGamehidden, DelevopersGamehidden , InstructionGamehidden, TopGamehidden;
        Tamagochi tamagochi;
        InventoryController inventoryController;
        int timeOflife;
        List<IFood> food;
        Random randomIndex;
        TamagochiXml tamagochiXml;
        string tamagochiFileName = "tamagochi.xml";
        public MainWindow()
        {
            food = new List<IFood>();
            food.Add(new Sugar());
            food.Add(new Salt());
            food.Add(new Water());
            food.Add(new Fire());
            food.Add(new Duck());
            food.Add(new Corn());
            food.Add(new Fish());
            food.Add(new Egg());
            food.Add(new Mushroom());
            food.Add(new Marshmallow());
            food.Add(new Vegetable());
            food.Add(new Flakes());
            food.Add(new Bread());
            food.Add(new Pie());
            food.Add(new Jam());
            food.Add(new Compote());
            food.Add(new Jelly());
            food.Add(new Omelette());
            food.Add(new Pancake());
            food.Add(new Toast());
            food.Add(new GrilledVegetables());
            food.Add(new Salad());
            food.Add(new Steak());
            food.Add(new Rice());
            food.Add(new RiceVegetables());
            food.Add(new Popcorn());
            food.Add(new VegetableSoup());
            food.Add(new MushroomSoup());
            food.Add(new FishSoup());
            food.Add(new Trash());

            inventoryController = new InventoryController(food);

            tamagochi = new Tamagochi(food);
            InitializeComponent();

            FileInfo info = new FileInfo(leadersFileName);
            if (info.Exists)
            {
                using (FileStream fs = new FileStream(leadersFileName, FileMode.Open))
                {
                    List<TamagochiJson> ls = JsonSerializer.Deserialize<List<TamagochiJson>>(fs);

                    ls.Sort(CompareTamagochJson);


                    for (int i = 0; i < 8; i++)
                    {
                        if (i == ls.Count) break;
                        Grid grid = new Grid();

                        grid.HorizontalAlignment = HorizontalAlignment.Stretch;

                        grid.ColumnDefinitions.Add(new ColumnDefinition());
                        grid.ColumnDefinitions.Add(new ColumnDefinition());

                        grid.ColumnDefinitions[0].MinWidth = 550;

                        //grid.ShowGridLines = true;

                        Label name = new Label();
                        name.Content = ls[i].Name;

                        Label rating = new Label();
                        rating.Content = ls[i].Rating.ToString();
                        Grid.SetColumn(rating, 1);

                        grid.Children.Add(name);
                        grid.Children.Add(rating);

                        TopListBox.Items.Add(grid);
                    }
                }
            }

            info = new FileInfo(tamagochiFileName);
            if (info.Exists)
            {
                using (FileStream fs = new FileStream(tamagochiFileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TamagochiXml));
                    tamagochiXml = serializer.Deserialize(fs) as TamagochiXml;

                    if (tamagochiXml.Name != null)
                    {
                        if (tamagochiXml.Name.Length >= 2) loadGame.Visibility = Visibility.Visible;
                    }
                }
            }

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0 , 1);
            timer.Tick += Timer_Tick;
            timerstart = new DispatcherTimer();
            timerstart.Interval = new TimeSpan (0, 0, 0, 0 , 1);
            timerstart.Tick += Start_Tick;
            timerEnd = new DispatcherTimer();
            timerEnd.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerEnd.Tick += End_Tick;
            timerDevelopers = new DispatcherTimer();
            timerDevelopers.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerDevelopers.Tick += Developers_Tick;
            timerInstruction = new DispatcherTimer();
            timerInstruction.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerInstruction.Tick += Instruction_Tick;
            timerTop = new DispatcherTimer();
            timerTop.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerTop.Tick += Top_Tick;

            EndGameHeight = EndGamePanel.Height;
            StartGameHeight = StartGamePanel.Height;
            DelevopersGameHeight = DevelopersGamePanel.Height;
            InstructionGameHeight = InstructionGamePanel.Height;
            TopGameHeight = TopGamePanel.Height;
            MenuWidth = sideMenu.Width;

            timerForTamagochi = new DispatcherTimer();
            timerForTamagochi.Interval = new TimeSpan(0, 0, 0, 2);
            timerForTamagochi.Tick += Timer_Eat;

            timerForTakeEat = new DispatcherTimer();
            timerForTakeEat.Interval = new TimeSpan(0, 0, 0, 5);
            timerForTakeEat.Tick += Timer_Take_Eat;

            timerOfLife = new DispatcherTimer();
            timerOfLife.Interval = new TimeSpan(0, 0, 0, 15);
            timerOfLife.Tick += TimerOfLife_Tick;

            timerForGifPetting = new DispatcherTimer();
            timerForGifPetting.Interval = new TimeSpan(0, 0, 0, 3);
            timerForGifPetting.Tick += TimerOfPetting_Tick;

            timerForEatGif = new DispatcherTimer();
            timerForEatGif.Interval = new TimeSpan(0, 0, 0, 3);
            timerForEatGif.Tick += TimerEatGif_Tick;
            
            randomIndex = new Random();
            
        }

        private int CompareTamagochJson(TamagochiJson t1, TamagochiJson t2)
        {
            return t2.Rating - t1.Rating;
        }

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            loadGame.Visibility = Visibility.Hidden;

            tamagochi.Name = tamagochiXml.Name;
            tamagochi.Poisoning = tamagochiXml.Poisoning;
            tamagochi.Saturation = tamagochiXml.Saturation;
            tamagochi.Heal = tamagochiXml.Heal;
            tamagochi.Happines = tamagochiXml.Happines;
            NameOfDuck.Text = tamagochi.Name;
            timeOflife = tamagochiXml.timeOflife;
            Label_AgeText.Content = "Age: " + Convert.ToString(tamagochiXml.timeOflife) + " years";
            Start_Game(sender, e);
            //timerstart.Start();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            using (FileStream fs = new FileStream(tamagochiFileName, FileMode.Create))
            {
                TamagochiXml tXml = new TamagochiXml(tamagochi, timeOflife);

                XmlSerializer serializer = new XmlSerializer(typeof(TamagochiXml));
                serializer.Serialize(fs, tXml);
            }
        }

        private void TimerOfLife_Tick(object sender, EventArgs e)
        {
            timeOflife++;
            Label_AgeText.Content = "Age: " + Convert.ToString(timeOflife) + " years";
        }

        string leadersFileName = "leaders.txt";
        private void Timer_Eat(object sender, EventArgs e)
        {
            /*tamagochi.ProgressBarOfHappy.Value;*/
            tamagochi.StateUpdate();
            ProgressBarOfHungry.Value = tamagochi.Saturation;
            Label_HugerIndex.Content = tamagochi.Saturation;
            ProgressBarOfHappy.Value = tamagochi.Happines;
            Label_HappinessIndex.Content = tamagochi.Happines;
            ProgressBarOfHeal.Value = tamagochi.Heal;
            Label_healIndex.Content = tamagochi.Heal;
            ProgressBarOfPoison.Value = tamagochi.Poisoning;
            Label_PoisoningIndex.Content = tamagochi.Poisoning;
            if (!tamagochi.IsAlive)
            {
                FileInfo fileInfo = new FileInfo(leadersFileName);
                if (fileInfo.Exists)
                {
                    List<TamagochiJson> ls;

                    using (StreamReader sr = new StreamReader(leadersFileName))
                    {
                        ls = JsonSerializer.Deserialize<List<TamagochiJson>>(sr.ReadToEnd());

                        ls.Add(new TamagochiJson(tamagochi.Name, timeOflife));
                    }

                    using (StreamWriter sw = new StreamWriter(leadersFileName))
                    {
                        sw.Write(JsonSerializer.Serialize(ls));
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(leadersFileName))
                    {
                        List<TamagochiJson> ls = new List<TamagochiJson>();
                        ls.Add(new TamagochiJson(tamagochi.Name, timeOflife));

                        sw.Write(JsonSerializer.Serialize(ls));
                    }
                }

                tamagochi.StateDestroy();
                eat_List.Items.Clear();
                EndGamehidden = true;
                timerForTamagochi.Stop();
                timerForTakeEat.Stop();
                timerEnd.Start();
            }
        }


        private void Start_Tick(object sender, EventArgs e)
        {
            if (StartGamehidden)
            {
                StartGamePanel.Visibility = Visibility.Visible;
                StartGamePanel.Height += StartGameHeight / 5;
                if (StartGamePanel.Height >= StartGameHeight)
                {
                    timerstart.Stop();
                    StartGamehidden = false;
                }
            }
            else
            {
                StartGamePanel.Height -= StartGameHeight / 5;
                if (StartGamePanel.Height <= 0)
                {
                    timerstart.Stop();
                    StartGamehidden = true;
                    StartGamePanel.Visibility = Visibility.Hidden;
                    timerForTamagochi.Start();
                    timerOfLife.Start();
                    timerForTakeEat.Start();
                }
            }
        }
        //таймер для виведення панелі на початку гри для задання імені персонажу
        private void End_Tick(object sender, EventArgs e)
        {
            if (EndGamehidden)
            {
                EndGamePanel.Visibility = Visibility.Visible;
                EndGamePanel.Height += EndGameHeight / 5;
                if (EndGamePanel.Height >= EndGameHeight)
                {
                    timerEnd.Stop();
                    EndGamehidden = false;
                }
            }
            else
            {
                EndGamePanel.Height -= EndGameHeight / 5;
                if (EndGamePanel.Height <= 0)
                {
                    timerEnd.Stop();
                    EndGamehidden = true;
                    EndGamePanel.Visibility = Visibility.Hidden;
                    tamagochi.StateCreate();
                    timerstart.Start();
                    StartGamehidden = true;
                }
            }
        }
        //рестарт гри (якщо захочемо, можна сюди ще допиляти панель з результатами, скільки їжі сів і скільки хвилин прожив
        private void eat_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string s = eat_List.SelectedItem.ToString();
            if (foodText.Text == "")
            {
                foodText.Text = s;
            } else if (foodText.Text.EndsWith("+ ") || foodText.Text.EndsWith("+"))
            {
                foodText.Text = foodText.Text + s;
            }
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (foodText.Text != "")
            {
                if (!foodText.Text.EndsWith("+ "))
                {
                    foodText.Text = foodText.Text + " + ";
                }
                else if (foodText.Text.EndsWith("+"))
                {
                    foodText.Text = foodText.Text + " + ";
                }
               
            }
        }
        bool isPetting = false;
        private void GifOfDuckStandart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isPetting)
            {
                isPetting = true;
                GifOfDuckPat.Visibility = Visibility.Visible;
                GifOfDuckStandart.Visibility = Visibility.Hidden;
                GifOfDuckEat1.Visibility = Visibility.Hidden;
                GifOfDuckEat2.Visibility = Visibility.Hidden;
                GifOfDuckEat3.Visibility = Visibility.Hidden; 
                GifOfDuckEatTrash.Visibility = Visibility.Hidden;
                timerForGifPetting.Start();
            }
        }


        private void TimerOfPetting_Tick(object sender, EventArgs e)
        {
            timerForGifPetting.Stop();
            GifOfDuckStandart.Visibility = Visibility.Visible;
            GifOfDuckPat.Visibility = Visibility.Hidden;
            GifOfDuckEat1.Visibility = Visibility.Hidden;
            GifOfDuckEat2.Visibility = Visibility.Hidden;
            GifOfDuckEat3.Visibility = Visibility.Hidden;
            GifOfDuckEatTrash.Visibility = Visibility.Hidden;
            isPetting =false;
        }

        private void TimerEatGif_Tick(object sender, EventArgs e)
        {
            timerForGifPetting.Stop();
            GifOfDuckPat.Visibility = Visibility.Hidden;
            GifOfDuckStandart.Visibility = Visibility.Visible;
            GifOfDuckEat1.Visibility = Visibility.Hidden;
            GifOfDuckEat2.Visibility = Visibility.Hidden;
            GifOfDuckEat3.Visibility = Visibility.Hidden;
            GifOfDuckEatTrash.Visibility = Visibility.Hidden;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hiddenMenu)
            {
                sideMenu.Visibility = Visibility.Visible;
                sideMenu.Width += MenuWidth/5;
                if (sideMenu.Width >= MenuWidth)
                {
                    timer.Stop();
                    hiddenMenu = false;
                }
            }
            else
            {    
                sideMenu.Width -= MenuWidth/5;       
                if (sideMenu.Width <= 0)
                {
                    timer.Stop();
                    hiddenMenu = true;
                    sideMenu.Visibility = Visibility.Hidden;
                }
            }
        }
        private bool checkPause = false;
        private void Pause(bool check)
        {
            if (check)
            {
                timerForTamagochi.Stop();
                timerForTakeEat.Stop();
                timerOfLife.Stop();
            }
        }

        private void UnPause()
        {
            timerForTamagochi.Start();
            timerForTakeEat.Start();
            timerOfLife.Start();
        }
        private void Developers_Tick(object sender, EventArgs e)
        {
            if (DelevopersGamehidden)
            {
                if (checkPause == false) { checkPause = true; Pause(checkPause); }
                DevelopersGamePanel.Visibility = Visibility.Visible;
                DevelopersGamePanel.Height += DelevopersGameHeight / 5;
                if (DevelopersGamePanel.Height >= DelevopersGameHeight)
                {
                    timerDevelopers.Stop();
                    DelevopersGamehidden = false;
                }
            }
            else
            {
                DevelopersGamePanel.Height -= DelevopersGameHeight / 5;
                if (DevelopersGamePanel.Height <= 0)
                {
                    checkPause = false;
                    UnPause();
                    timerDevelopers.Stop();
                    DelevopersGamehidden = true;
                    DevelopersGamePanel.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Instruction_Tick(object sender, EventArgs e)
        {
            if (InstructionGamehidden)
            {
                if (checkPause == false) { checkPause = true; Pause(checkPause); }
                InstructionGamePanel.Visibility = Visibility.Visible;
                InstructionGamePanel.Height += InstructionGameHeight / 5;
                if (InstructionGamePanel.Height >= InstructionGameHeight)
                {
                    timerInstruction.Stop();
                    InstructionGamehidden = false;
                }
            }
            else
            {
                InstructionGamePanel.Height -= InstructionGameHeight / 5;
                if (InstructionGamePanel.Height <= 0)
                {
                    checkPause = false;
                    UnPause();
                    timerInstruction.Stop();
                    InstructionGamehidden = true;
                    InstructionGamePanel.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Top_Tick(object sender, EventArgs e)
        {
            if (TopGamehidden)
            {
                if (checkPause == false) { checkPause = true; Pause(checkPause); }
                TopGamePanel.Visibility = Visibility.Visible;
                TopGamePanel.Height += TopGameHeight / 5;
                if (TopGamePanel.Height >= TopGameHeight)
                {
                    timerTop.Stop();
                    TopGamehidden = false;
                }
            }
            else
            {
                TopGamePanel.Height -= TopGameHeight / 5;
                if (TopGamePanel.Height <= 0)
                {
                    checkPause = false;
                    UnPause();
                    timerTop.Stop();
                    TopGamehidden = true;
                    TopGamePanel.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Restart_Game(object sender, RoutedEventArgs e)
        {
            // loadGame.Visibility = Visibility.Visible;
            timerEnd.Start();
            Label_Name.Content = "Name: " + tamagochi.Name;
            ProgressBarOfHeal.Value = tamagochi.Heal;
            ProgressBarOfHappy.Value = tamagochi.Happines;
            ProgressBarOfHungry.Value = tamagochi.Saturation;
            ProgressBarOfPoison.Value = tamagochi.Poisoning;
            Label_healIndex.Content = tamagochi.Heal;
            Label_HappinessIndex.Content = tamagochi.Happines;
            Label_HugerIndex.Content = tamagochi.Saturation;
            Label_PoisoningIndex.Content = tamagochi.Poisoning;
        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        private void Developers_Btn(object sender, RoutedEventArgs e)
        {
            timerDevelopers.Start();
        }
        private void instruction_Btn(object sender, RoutedEventArgs e)
        {
            timerInstruction.Start();
        }
        private void Top_Btn(object sender, RoutedEventArgs e)
        {
            timerTop.Start();
        }

        private void Start_Game(object sender, RoutedEventArgs e)
        {
            if (NameOfDuck.Text.Length >= 3 && NameOfDuck.Text.Length <= 20)
            {
                inventoryController.Clear();
                timerstart.Start();
                Take_Eat();
                tamagochi.Happines = 100;
                tamagochi.Heal = 100;
                tamagochi.Name = "";
                tamagochi.Poisoning = 0;
                tamagochi.Saturation = 100;
                timeOflife = 0;
                tamagochi.Name = NameOfDuck.Text;
                Label_Name.Content = "Name: " + tamagochi.Name;
                ProgressBarOfHeal.Value = tamagochi.Heal;         
                ProgressBarOfHappy.Value = tamagochi.Happines;
                ProgressBarOfHungry.Value = tamagochi.Saturation;
                ProgressBarOfPoison.Value = tamagochi.Poisoning;
                Label_healIndex.Content = tamagochi.Heal;
                Label_HappinessIndex.Content = tamagochi.Happines;
                Label_HugerIndex.Content = tamagochi.Saturation;
                Label_PoisoningIndex.Content = tamagochi.Poisoning;
            }
        }
        //передача початкових параметрів в інтерфейс
        private void leftDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //вихід з проги 
        private void MenuPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Timer_Take_Eat(object sender, EventArgs e)
        {
            int index = randomIndex.Next(0,29);
            eat_List.Items.Add(food[index].Name);
            inventoryController.Add(food[index]);
        }
        private void Take_Eat()
        {
            int index;
            for (int i = 0; i < 5; i++)
            {
                index = randomIndex.Next(0, 29);
                eat_List.Items.Add(food[index].Name);
                inventoryController.Add(food[index]);
            }
        }
        //видає їжу
        private void GetFood(object sender, RoutedEventArgs e)
        {
            String str = foodText.Text.ToLower();
            if (str == "")
            {
                labelErrorsWithList.Content = "Error";
                return;
            }
            if (str[str.Length - 1] == '+')
            {
                labelErrorsWithList.Content = "Error";
                return;
            }
            String[] masStr = str.Split('+');
            if (masStr.Length >= 3)
            {
                labelErrorsWithList.Content = "Error";
                return;
            }
            if (masStr.Length == 2)
            {
                for (int i = 0; i < masStr.Length; i++)
                {
                    if (masStr[i].Substring(0, 1) == " ")
                    {
                        masStr[i] = masStr[i].Remove(0, 1);
                    }
                    int ind = masStr[i].LastIndexOf(" ");
                    if (ind == masStr[i].Length - 1)
                    {
                        masStr[i] = masStr[i].Remove(masStr[i].Length - 1, 1);
                    }
                }
                if (!inventoryController.CheckItem(masStr[1]) || !inventoryController.CheckItem(masStr[0]))
                {
                    labelErrorsWithList.Content = "Error";
                    return;
                }
                if (masStr[0] == masStr[1])
                {
                    labelErrorsWithList.Content = "Product are same";
                    return;
                }
                string newFood = inventoryController.Craft(masStr[0], masStr[1]).Name;
                eat_List.Items.Remove(masStr[0]);
                eat_List.Items.Remove(masStr[1]);
                eat_List.Items.Add(newFood);
                IFood dish = null;
                for (int i = 0; i < food.Count; i++)
                {
                    if (newFood == food[i].Name) { dish = food[i]; break; }
                }
                inventoryController.Add(dish);
                foodText.Text = "";
            } 
            else if (masStr.Length == 1)
            {
                if (masStr[0].Substring(0, 1) == " ")
                {
                    masStr[0] = masStr[0].Remove(0, 1);
                }
                int ind = masStr[0].LastIndexOf(" ");
                if (ind == masStr[0].Length - 1)
                {
                    masStr[0] = masStr[0].Remove(masStr[0].Length - 1, 1);
                }
                if (!inventoryController.CheckItem(masStr[0]))
                {
                    labelErrorsWithList.Content = "Error";
                    return;
                }
                IFood dish = null;
                int index = 30;
                for (int i = 0; i < food.Count; i++)
                {
                    if (masStr[0] == food[i].Name) { dish = food[i]; index = i; break; } 
                }
                if (index >= 0 && index <=10)
                {
                    GifOfDuckPat.Visibility = Visibility.Hidden;
                    GifOfDuckStandart.Visibility = Visibility.Hidden;
                    GifOfDuckEat1.Visibility = Visibility.Visible;
                    GifOfDuckEat2.Visibility = Visibility.Hidden;
                    GifOfDuckEat3.Visibility = Visibility.Hidden;
                    GifOfDuckEatTrash.Visibility = Visibility.Hidden;
                    timerForEatGif.Start();
                } else if (index >10 && index <= 20)
                {
                    GifOfDuckPat.Visibility = Visibility.Hidden;
                    GifOfDuckStandart.Visibility = Visibility.Hidden;
                    GifOfDuckEat1.Visibility = Visibility.Hidden;
                    GifOfDuckEat2.Visibility = Visibility.Visible;
                    GifOfDuckEat3.Visibility = Visibility.Hidden;
                    GifOfDuckEatTrash.Visibility = Visibility.Hidden;
                    timerForEatGif.Start();
                } else if (index > 20 && index <= 28)
                {
                    GifOfDuckPat.Visibility = Visibility.Hidden;
                    GifOfDuckStandart.Visibility = Visibility.Hidden;
                    GifOfDuckEat1.Visibility = Visibility.Hidden;
                    GifOfDuckEat2.Visibility = Visibility.Hidden;
                    GifOfDuckEat3.Visibility = Visibility.Visible;
                    GifOfDuckEatTrash.Visibility = Visibility.Hidden;
                    timerForEatGif.Start();
                } else 
                {
                    GifOfDuckPat.Visibility = Visibility.Hidden;
                    GifOfDuckStandart.Visibility = Visibility.Hidden;
                    GifOfDuckEat1.Visibility = Visibility.Hidden;
                    GifOfDuckEat2.Visibility = Visibility.Hidden;
                    GifOfDuckEat3.Visibility = Visibility.Hidden;
                    GifOfDuckEatTrash.Visibility = Visibility.Visible;
                    timerForEatGif.Start();
                }
                inventoryController.Remove(dish);
                tamagochi.Eat(dish);
                eat_List.Items.Remove(masStr[0]);
                foodText.Text = "";
            }
        }
        //їсть їжу
    }
}

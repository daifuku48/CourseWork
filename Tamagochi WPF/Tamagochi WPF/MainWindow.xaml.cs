using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;


namespace Tamagochi_WPF
{
    // Логіка взаємодії для MainWindow.xaml
    public partial class MainWindow : Window
    {
        //=VARS==============================================================
        #region [ VARS ]
        DispatcherTimer     timer,
                            timerStart,
                            timerEnd,
                            timerTop,
                            timerDevelopers,
                            timerInstruction,
                            timerForTamagochi,
                            timerForTakeEat,
                            timerOfLife,
                            timerForGifPetting,
                            timerForEatGif;

        double              MenuWidth,
                            StartGameHeight,
                            EndGameHeight,
                            DelevopersGameHeight,
                            InstructionGameHeight,
                            TopGameHeight;

        bool                hiddenMenu,
                            StartGamehidden,
                            EndGamehidden,
                            DelevopersGamehidden,
                            InstructionGamehidden,
                            TopGamehidden;

        bool                isPetting = false,
                            gifeat1 = false,
                            gifeat2 = false,
                            gifeat3 = false,
                            gifeat4 = false;

        bool                checkPause = false;

        Random              randomIndex;
        TamagochiXml        tamagochiXml;
        string              tamagochiFileName = "tamagochi.xml";
        string              leadersFileName = "leaders.txt";
        int                 timeOflife;

        List<IFood>         food;
        Tamagochi           tamagochi;

        //InventoryController inventoryController;
        #endregion
        //=END_VARS==========================================================

        //=SYSTEM============================================================
        #region [ SYSTEM ]
        public MainWindow()
        {
            init_food_list();
            init_object();

            // base functions;
            InitializeComponent();

            // ???;
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
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timerStart = new DispatcherTimer();
            timerStart.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerStart.Tick += Start_Tick;
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
            timerForTakeEat.Interval = new TimeSpan(0, 0, 0, 8);
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
            for (int i = 0; i < 5; i++)
            {
                int index = randomIndex.Next(0, 29);
                tamagochi.Inventory.Add(food[index]);

                eat_List.Items.Clear();
                foreach (Item item in tamagochi.Inventory._items)
                {
                    if (item.amount > 0)
                    {
                        eat_List.Items.Add(item.food.Name);
                    }
                }
            }
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
            //timerStart.Start();
        }

        // initialize food list
        void init_food_list()
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
        }

        // initialize all controller
        void init_object()
        {
            tamagochi = new Tamagochi();
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

        private void Restart_Game(object sender, RoutedEventArgs e)
        {
            // loadGame.Visibility = Visibility.Visible;
            timerEnd.Start();
        }

        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        //передача початкових параметрів в інтерфейс;
        private void Start_Game(object sender, RoutedEventArgs e)
        {
            if (NameOfDuck.Text.Length >= 3 && NameOfDuck.Text.Length <= 20)
            {
                timerStart.Start();
                tamagochi.Name = NameOfDuck.Text;
                Label_Name.Content = "Name: " + tamagochi.Name;
                timeOflife = 0;
                Label_AgeText.Content = "Age: " + Convert.ToString(timeOflife) + " years";
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

        //вихід з проги;
        private void leftDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }


        #endregion
        //=END_SYSTEM========================================================


        //=BUTTON_ACTION=====================================================
        #region [ BUTTON ACTION ]
        
        private void eat_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (eat_List.SelectedItem != null)
            {
                string s = eat_List.SelectedItem.ToString();
                if (foodText.Text == "")
                {
                    foodText.Text = s;
                }
                else if (foodText.Text.EndsWith("+ ") || foodText.Text.EndsWith("+"))
                {
                    foodText.Text = foodText.Text + s;
                }
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

        private void MenuPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //їсть їжу;
        private void GetFood(object sender, RoutedEventArgs e)
        {
            labelErrorsWithList.Content = "";
            // error
            if (foodText.Text == null)
            {
                return;
            }
            if (foodText.Text.Contains('+'))
            {
                crafting();
            }
            else
            {
                eating();
            }
        }

        private void eating()
        {
            string food_name = foodText.Text;
            foodText.Text = "";
            eat_List.Items.Remove(food_name);

            if (!tamagochi.Inventory.CheckItem(food_name))
            {
                labelErrorsWithList.Content = "Error";
                return;
            }

            IFood food_ = new Trash();
            for (int index = 0;
                index < food.Count;
                index++)
            {
                if (food_name == food[index].Name) 
                {
                    food_ = food[index];
                    break;
                }
            }

            tamagochi.Inventory.Remove(food_name);
            tamagochi.Eat(food_);

            // animation
            int chose_animation = randomIndex.Next(0, 3);
            GifOfDuckPat.Visibility = Visibility.Hidden;
            GifOfDuckStandart.Visibility = Visibility.Hidden;
            switch (chose_animation)
            {
                case 0:
                    GifOfDuckEat1.Visibility = Visibility.Visible;

                    GifOfDuckEat2.Visibility = Visibility.Hidden;
                    GifOfDuckEat3.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    GifOfDuckEat2.Visibility = Visibility.Visible;

                    GifOfDuckEat1.Visibility = Visibility.Hidden;
                    GifOfDuckEat3.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    GifOfDuckEat3.Visibility = Visibility.Visible;

                    GifOfDuckEat1.Visibility = Visibility.Hidden;
                    GifOfDuckEat2.Visibility = Visibility.Hidden;
                    break;
            }
            GifOfDuckEatTrash.Visibility = Visibility.Hidden;
            timerForEatGif.Start();
        }

        private void crafting()
        {
            string[] recipe = foodText.Text.Trim().Split('+');
            foodText.Text = "";
            // error
            if (recipe[0].Length == 0 || recipe[1].Length == 0)
            {
                labelErrorsWithList.Content = "Error";
                return;
            }

            IFood food = tamagochi.Inventory.Craft(recipe[0].Trim(), recipe[1].Trim());

            tamagochi.Inventory.Add(food);

            eat_List.Items.Remove(recipe[0].Trim());
            eat_List.Items.Remove(recipe[1].Trim());
            eat_List.Items.Add(food.Name);
        }
        #endregion
        //=END_BUTTON_ACTION=================================================


        //=TIMER=============================================================
        #region [ TIMER ]
        //видає їжу
        private void Timer_Take_Eat(object sender, EventArgs e)
        {
            int index = randomIndex.Next(0, 29);
            tamagochi.Inventory.Add(food[index]);

            eat_List.Items.Clear();
            foreach (Item item in tamagochi.Inventory._items)
            {
                if (item.amount > 0)
                {
                    eat_List.Items.Add(item.food.Name);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hiddenMenu)
            {
                sideMenu.Visibility = Visibility.Visible;
                sideMenu.Width += MenuWidth / 5;
                if (sideMenu.Width >= MenuWidth)
                {
                    timer.Stop();
                    hiddenMenu = false;
                }
            }
            else
            {
                sideMenu.Width -= MenuWidth / 5;
                if (sideMenu.Width <= 0)
                {
                    timer.Stop();
                    hiddenMenu = true;
                    sideMenu.Visibility = Visibility.Hidden;
                }
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
            isPetting = false;
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

        //таймер для виведення панелі на початку гри для задання імені персонажу
        private void Start_Tick(object sender, EventArgs e)
        {
            if (StartGamehidden)
            {
                StartGamePanel.Visibility = Visibility.Visible;
                StartGamePanel.Height += StartGameHeight / 5;
                if (StartGamePanel.Height >= StartGameHeight)
                {
                    timerStart.Stop();
                    StartGamehidden = false;
                }
            }
            else
            {
                StartGamePanel.Height -= StartGameHeight / 5;
                if (StartGamePanel.Height <= 0)
                {
                    timerStart.Stop();
                    StartGamehidden = true;
                    StartGamePanel.Visibility = Visibility.Hidden;
                    timerForTamagochi.Start();
                    timerOfLife.Start();
                    timerForTakeEat.Start();
                }
            }
        }
        
        //рестарт гри (якщо захочемо, можна сюди ще допиляти панель з результатами, скільки їжі сів і скільки хвилин прожив
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
                    timerStart.Start();
                    StartGamehidden = true;
                }
            }
        }
        
        private void TimerOfLife_Tick(object sender, EventArgs e)
        {
            timeOflife++;
            Label_AgeText.Content = "Age: " + Convert.ToString(timeOflife) + " years";
        }

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
        #endregion
        //=END_TIMER=========================================================
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Testing.UserControls;
using Testing.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testing.SubMenus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SkillsNProficiencies : Page
    {
        public SkillsNProficiencies()
        {
            this.InitializeComponent();
            acrobatics.DataContext = "Acrobatics";
            animalHandling.DataContext = "AnimalHandling";
            arcana.DataContext = "Arcana";
            athletics.DataContext = "Athletics";
            deception.DataContext = "Deception";
            history.DataContext = "History";
            insight.DataContext = "Insight";
            intimidation.DataContext = "Intimidation";
            investigation.DataContext = "Investigation";
            medicine.DataContext = "Medicine";
            nature.DataContext = "Nature";
            perception.DataContext = "Perception";
            performance.DataContext = "Performance";
            persuassion.DataContext = "Persuassion";
            religion.DataContext = "Religion";
            sleightOfHand.DataContext = "Sleight Of Hand";
            stealth.DataContext = "Stealth";

            strengthSaveMod.DataContext = "Strength";
            dexteritySaveMod.DataContext = "Dexterity";
            constitutionSaveMod.DataContext = "Constitution";
            intelligenceSaveMod.DataContext = "Intelligence";
            wisdomSaveMod.DataContext = "Wisdom";
            charismaSaveMod.DataContext = "Charisma";
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Skill[] modData = (App.Current as App).Character.SnPData.SkillModifiers;
            int i = 0;
            foreach(var mod in modPanel.Children)
            {
                int tmpVal;
                int.TryParse((mod as SkillsDisplay).Text, out tmpVal);
                modData[i++].Modifier = tmpVal;
            }

            modData = (App.Current as App).Character.SnPData.SavingThrows;
            i = 0;
            foreach (var mod in savingThrows.Children)
            {
                int tmpVal;
                int.TryParse((mod as SkillsDisplay).Text, out tmpVal);
                modData[i++].Modifier = tmpVal;
            }

            this.Frame.Navigate(typeof(MainPage));
        }

        private void addProficiency_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Create new shape and brush
            TextBlock item = new TextBlock();
            SolidColorBrush color = new SolidColorBrush();

            //Set color
            color.Color = Colors.Black;
            item.Foreground = color;
            item.FontSize = 55;
            if (proficiencyInput.Text.Trim() != "")
            {
                Grid grid = new Grid();
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);
                item.Text = proficiencyInput.Text;
                grid.Children.Add(item);
                proficiency.Children.Add(grid);
                (App.Current as App).Character.SnPData.Proficiencies.Add(proficiencyInput.Text);
                proficiencyInput.Text = "";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if ((App.Current as App).Character.SnPData.Proficiencies != null)
            {
                proficiency.Children.Clear();
                foreach (string itemObject in (App.Current as App).Character.SnPData.Proficiencies)
                {
                    //Create new shape and brush
                    TextBlock item = new TextBlock();
                    SolidColorBrush color = new SolidColorBrush();

                    //Set color
                    color.Color = Colors.Black;
                    item.Foreground = color;
                    item.FontSize = 55;
                    Grid grid = new Grid();
                    SolidColorBrush brush = new SolidColorBrush();
                    brush.Color = Colors.DarkGray;
                    grid.BorderBrush = brush;
                    grid.BorderThickness = new Thickness(3);
                    grid.CornerRadius = new CornerRadius(8);
                    item.Text = itemObject;
                    grid.Children.Add(item);
                    proficiency.Children.Add(grid);
                }
            }
            if((App.Current as App).Character.SnPData.SkillModifiers != null)
            {
                Skill[] modData = (App.Current as App).Character.SnPData.SkillModifiers;
                int i = 0;
                foreach (var mod in modPanel.Children)
                {
                    (mod as SkillsDisplay).Text = modData[i++].ToString();
                }
            }
            if ((App.Current as App).Character.SnPData.SavingThrows != null)
            {
                Skill[] modData = (App.Current as App).Character.SnPData.SavingThrows;
                int i = 0;
                foreach (var mod in savingThrows.Children)
                {
                    (mod as SkillsDisplay).Text = modData[i++].ToString();
                }
            }

        }
    }
}

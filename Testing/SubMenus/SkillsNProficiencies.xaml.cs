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
                    item.TextWrapping = TextWrapping.Wrap;
                    grid.Children.Add(item);
                    grid.RightTapped += Grid_RightTapped;
                    proficiency.Children.Add(grid);
                }
            }
            if((App.Current as App).Character.SnPData.SkillModifiers != null)
            {
                Skill[] modData = (App.Current as App).Character.SnPData.SkillModifiers;
                int i = 0;
                foreach (var mod in modPanel.Children)
                {
                    (mod as SkillsDisplay).DataContext = modData[i];
                    (mod as SkillsDisplay).Text = modData[i].Modifier.ToString();
                    (mod as SkillsDisplay).CheckBox = modData[i++].Proficient;
                }
            }
            if ((App.Current as App).Character.SnPData.SavingThrows != null)
            {
                Skill[] modData = (App.Current as App).Character.SnPData.SavingThrows;
                int i = 0;
                foreach (var mod in savingThrows.Children)
                {
                    (mod as SkillsDisplay).DataContext = modData[i];
                    (mod as SkillsDisplay).Text = modData[i].Modifier.ToString();
                    (mod as SkillsDisplay).CheckBox = modData[i++].Proficient;
                }
            }

        }

        private void Grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            (App.Current as App).Character.SnPData.Proficiencies.Remove(((sender as Grid).Children.ElementAt(0) as TextBlock).Text);
            proficiency.Children.Remove((UIElement)sender);
        }
    }
}

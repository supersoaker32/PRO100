using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Testing.SubMenus;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Testing
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            //Make the thing
            //Write code for the thing
            //Publish the thing
            //Test the thing before you publish (Hope you read everything first)
            //Present the thing
            //Ignore this
        }

        private void CharInfo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CharacterInfo));
        }       
        private void SkillsNProficiencies_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SkillsNProficiencies));
        }        
        private void ActiveStats_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ActiveStats));
        }        
        private void Spellbook_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Spellbook));
        }        
        private void Features_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Features));
        }        
        private void Inventory_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Inventory));
        }
<<<<<<< HEAD
=======

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            #region DisplaySpells
            Spells.Children.Clear();
            foreach (Spell spell in (App.Current as App).Character.Spellbook)
            {
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                SolidColorBrush color = new SolidColorBrush();
                color.Color = Colors.Black;

                TextBlock spellName = new TextBlock();
                spellName.Foreground = color;
                spellName.FontSize = 32;
                spellName.Text = spell.SpellName;
                Grid.SetRow(spellName, 0);
                grid.Children.Add(spellName);

                TextBlock spellDescription = new TextBlock();
                spellDescription.Foreground = color;
                spellDescription.FontSize = 32;
                spellDescription.Text = spell.SpellDescription;
                Grid.SetRow(spellDescription, 1);
                grid.Children.Add(spellDescription);

                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);

                Spells.Children.Add(grid);
            }
            #endregion

            #region DisplayFeatures
            Features.Children.Clear();
            foreach (Feature feature in (App.Current as App).Character.FeatureList)
            {
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                SolidColorBrush color = new SolidColorBrush();
                color.Color = Colors.Black;

                TextBlock featureName = new TextBlock();
                featureName.Foreground = color;
                featureName.FontSize = 32;
                featureName.Text = feature.FeatureName;
                Grid.SetRow(featureName, 0);
                grid.Children.Add(featureName);

                TextBlock featureDescription = new TextBlock();
                featureDescription.Foreground = color;
                featureDescription.FontSize = 32;
                featureDescription.Text = feature.FeatureDescription;
                Grid.SetRow(featureDescription, 1);
                grid.Children.Add(featureDescription);

                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);

                Features.Children.Add(grid);
            }
            #endregion

            #region DisplayInventory
            inventory.Children.Clear();
            if ((App.Current as App).Character.Inventory.Items != null)
            {
                foreach (Item itemObject in (App.Current as App).Character.Inventory.Items)
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
                    item.Text = itemObject.Name;
                    grid.Children.Add(item);
                    inventory.Children.Add(grid);
                }
            }
            if ((App.Current as App).Character.Inventory.Money != null)
            {
                int sum = 0;
                foreach (int money in (App.Current as App).Character.Inventory.Money)
                {
                    sum += money;
                }
                moneyVal.Text = sum.ToString();
            }
            #endregion

        }
>>>>>>> master
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Testing.Models;
using Testing.SubMenus;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
        public static InventoryData inventoryElements = new InventoryData();
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
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
            this.Frame.Navigate(typeof(Inventory), inventoryElements);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            #region SetAndDisplayInventory
            if (e.Parameter as InventoryData != null)
            {
                InventoryData par = e.Parameter as InventoryData;
                if (par.Items != null)
                {
                    inventory.Children.Clear();
                    inventoryElements.Items.Clear();
                    foreach (Item itemObject in par.Items)
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
                        inventoryElements.Items.Add(itemObject);

                    }
                }
                if (par.Money != null)
                {
                    int sum = 0;
                    foreach (int money in par.Money)
                    {
                        sum += money;
                    }
                    moneyVal.Text = sum.ToString();
                    inventoryElements.Money[0] = sum;
                }

            }
            #endregion

        }
    }
}

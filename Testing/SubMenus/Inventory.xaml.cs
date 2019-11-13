using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Testing.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testing.SubMenus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Inventory : Page
    {
        public Inventory()
        {
            this.InitializeComponent();
        }

        private void inputEntered_Click(object sender, RoutedEventArgs e)
        {
            //Create new shape and brush
            TextBlock item = new TextBlock();
            SolidColorBrush color = new SolidColorBrush();

            //Set color
            color.Color = Colors.Black;
            item.Foreground = color;
            item.FontSize = 55;
            if (input.Text.Trim() != "")
            {
                Grid grid = new Grid();
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);
                item.Text = input.Text;
                grid.Children.Add(item);
                inventory.Children.Add(grid);
                (App.Current as App).Character.Inventory.Items.Add(new Item(input.Text));
                input.Text = "";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if ((App.Current as App).Character.Inventory.Items != null)
            {
                inventory.Children.Clear();
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
                moneyDisplay.Text = sum.ToString();
            }



        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void moneyEntered_Click(object sender, RoutedEventArgs e)
        {
            int initialVal;
            int.TryParse(moneyDisplay.Text, out initialVal);
            StringBuilder sb = new StringBuilder();
            bool negative = false;
            char[] money = moneyInput.Text.ToCharArray();
            for (int i = 0; i < money.Length; i++)
            {
                if (money[i] >= 48 || money[i] <= 57 || money[i] == '-')
                {
                    if (money[i] >= 48 || money[i] <= 57)
                    {
                        sb.Append(money[i]);
                    }
                    else if (money[i] == '-' && negative)
                    {
                        sb.Append(money[i]);
                    }
                }
            }
            int val;
            int.TryParse(sb.ToString(), out val);
            initialVal += val;
            moneyDisplay.Text = initialVal.ToString();
            (App.Current as App).Character.Inventory.Money[0] = initialVal;
            moneyInput.Text = "";
        }
    }
}

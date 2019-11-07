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
            if(input.Text.Trim() != "")
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
                input.Text = "";
            }
        }
    }
}

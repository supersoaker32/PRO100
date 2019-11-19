using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class ActiveStats : Page
    {
        public ActiveStats()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void maxHPButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (maxHPBox.Text.Trim().Length > 0 && int.TryParse(maxHPBox.Text, out result))
            {
                if (result > 0)
                {
                    maxHPBlock.Text = result.ToString();
                    maxHPBox.Text = "";

                }
                else
                {
                    maxHPBlock.Text = "";
                    maxHPBox.Text = "";
                }
            }
            else
            {
                classBox.Text = "";
            }
        }

        private void tempHPButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text.Trim().Length > 0)
            {
                name.Text = nameBox.Text;
                nameBox.Text = "";
            }
            else
            {
                nameBox.Text = "";
            }
        }

        private void armorClassButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text.Trim().Length > 0)
            {
                name.Text = nameBox.Text;
                nameBox.Text = "";
            }
            else
            {
                nameBox.Text = "";
            }
        }
    }
}

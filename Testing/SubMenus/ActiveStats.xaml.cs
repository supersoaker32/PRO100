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
                if (result >= 0)
                {
                    maxHPBlock.Text = result.ToString();
                    maxHPBox.Text = "";

                }
                else
                {
                    maxHPBlock.Text = "0";
                    maxHPBox.Text = "";
                }
            }
            else
            {
                maxHPBox.Text = "";
            }
        }

        private void tempHPButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (tempHPBox.Text.Trim().Length > 0 && int.TryParse(tempHPBox.Text, out result))
            {
                if (result >= 0)
                {
                    tempHPBlock.Text = result.ToString();
                    tempHPBox.Text = "";
                }
                else
                {
                    tempHPBox.Text = "";
                    tempHPBlock.Text = "0";
                }
            }
            else
            {
                tempHPBox.Text = "";
            }
        }

        private void armorClassButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (armorClassBox.Text.Trim().Length > 0 && int.TryParse(armorClassBox.Text, out result))
            {
                if (result >= 0)
                {
                    armorClassBlock.Text = result.ToString();
                    armorClassBox.Text = "";
                }
                else
                {
                    armorClassBox.Text = "";
                    armorClassBlock.Text = "0";
                }
            }
            else
            {
                armorClassBox.Text = "";
            }
        }

        private void initiativeButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (initiativeBox.Text.Trim().Length > 0 && int.TryParse(initiativeBox.Text, out result))
            {
                initiativeBlock.Text = result.ToString();
                initiativeBox.Text = "";
            }
            else
            {
                initiativeBox.Text = "";
                initiativeBlock.Text = "0";
            }
        }

        private void speedButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (speedBox.Text.Trim().Length > 0 && int.TryParse(speedBox.Text, out result))
            {
                if (result >= 0)
                {
                    speedBlock.Text = result.ToString();
                    speedBox.Text = "";
                }
                else
                {
                    speedBox.Text = "";
                    speedBlock.Text = "0";
                }
            }
            else
            {
                speedBox.Text = "";
            }
        }
    }
}

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

            armorClassBlock.Text = (App.Current as App).Character.ActiveStats.ArmorClass.ToString();
            speedBlock.Text = (App.Current as App).Character.ActiveStats.Speed.ToString();
            initiativeBlock.Text = (App.Current as App).Character.ActiveStats.Initiative.ToString();

            maxHPBlock.Text = (App.Current as App).Character.ActiveStats.MaxHP.ToString();
            currentHPBlock.Text = (App.Current as App).Character.ActiveStats.CurrentHP.ToString();
            tempHPBlock.Text = (App.Current as App).Character.ActiveStats.TempHP.ToString();

            if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 3)
            {
                succ1.IsChecked = true;
                succ2.IsChecked = true;
                succ3.IsChecked = true;
            }
            else if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 2)
            {
                succ1.IsChecked = true;
                succ2.IsChecked = true;
            }
            else if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 1)
            {
                succ1.IsChecked = true;
            }


            if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 3)
            {
                fail1.IsChecked = true;
                fail2.IsChecked = true;
                fail3.IsChecked = true;
            }
            else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 2)
            {
                fail1.IsChecked = true;
                fail2.IsChecked = true;
            }
            else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 1)
            {
                fail1.IsChecked = true;
            }
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
                    (App.Current as App).Character.ActiveStats.MaxHP = result;

                }
                else
                {
                    maxHPBlock.Text = "0";
                    (App.Current as App).Character.ActiveStats.MaxHP = 0;
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
                    (App.Current as App).Character.ActiveStats.TempHP = result;
                }
                else
                {
                    tempHPBox.Text = "";
                    tempHPBlock.Text = "0";
                    (App.Current as App).Character.ActiveStats.TempHP = 0;
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
                    (App.Current as App).Character.ActiveStats.ArmorClass = result;
                }
                else
                {
                    armorClassBox.Text = "";
                    armorClassBlock.Text = "0";
                    (App.Current as App).Character.ActiveStats.ArmorClass = 0;
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
                (App.Current as App).Character.ActiveStats.Initiative = result;
            }
            else
            {
                initiativeBox.Text = "";
                initiativeBlock.Text = "0";
                (App.Current as App).Character.ActiveStats.Initiative = 0;
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
                    (App.Current as App).Character.ActiveStats.Speed = result;
                }
                else
                {
                    speedBox.Text = "";
                    speedBlock.Text = "0";
                    (App.Current as App).Character.ActiveStats.Speed = 0;
                }
            }
            else
            {
                speedBox.Text = "";
            }
        }

        private void succ1_Click(object sender, RoutedEventArgs e)
        {
            if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 0)
            {
                (App.Current as App).Character.ActiveStats.Success_SavingThrows++;
            }
            else if((App.Current as App).Character.ActiveStats.Success_SavingThrows == 1)
            {
                (App.Current as App).Character.ActiveStats.Success_SavingThrows--;
            }
            else
            {
                succ1.IsChecked = true;
            }
        }

        private void succ2_Click(object sender, RoutedEventArgs e)
        {
            if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 0)
            {
                succ1.IsChecked = true;
                succ2.IsChecked = false;
                (App.Current as App).Character.ActiveStats.Success_SavingThrows++;
            }
            else if((App.Current as App).Character.ActiveStats.Success_SavingThrows == 1)
            {
                (App.Current as App).Character.ActiveStats.Success_SavingThrows++;
            }
            else if(((App.Current as App).Character.ActiveStats.Success_SavingThrows == 2))
            {
                (App.Current as App).Character.ActiveStats.Success_SavingThrows--;
            }
            else
            {
                succ2.IsChecked = true;
            }
        }

        private void succ3_Click(object sender, RoutedEventArgs e)
        {
            if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 0)
            {
                succ1.IsChecked = true;
                succ3.IsChecked = false;
                (App.Current as App).Character.ActiveStats.Success_SavingThrows++;
            }
            else if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 1)
            {
                succ2.IsChecked = true;
                succ3.IsChecked = false;
                (App.Current as App).Character.ActiveStats.Success_SavingThrows++;
            }
            else if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 2)
            {
                (App.Current as App).Character.ActiveStats.Success_SavingThrows++;
            }
            else if((App.Current as App).Character.ActiveStats.Success_SavingThrows == 3)
            {
                (App.Current as App).Character.ActiveStats.Success_SavingThrows--;
            }
            else
            {
                succ3.IsChecked = true;
            }
        }

        private void fail1_Click(object sender, RoutedEventArgs e)
        {
            if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 0)
            {
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows++;
            }
            else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 1)
            {
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows--;
            }
            else
            {
                fail1.IsChecked = true;
            }
        }

        private void fail2_Click(object sender, RoutedEventArgs e)
        {
            if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 0)
            {
                fail1.IsChecked = true;
                fail2.IsChecked = false;
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows++;
            }
            else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 1)
            {
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows++;
            }
            else if (((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 2))
            {
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows--;
            }
            else
            {
                fail2.IsChecked = true;
            }
        }

        private void fail3_Click(object sender, RoutedEventArgs e)
        {
            if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 0)
            {
                fail1.IsChecked = true;
                fail3.IsChecked = false;
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows++;
            }
            else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 1)
            {
                fail2.IsChecked = true;
                fail3.IsChecked = false;
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows++;
            }
            else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 2)
            {
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows++;
            }
            else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 3)
            {
                (App.Current as App).Character.ActiveStats.Failure_SavingThrows--;
            }
            else
            {
                fail3.IsChecked = true;
            }
        }

        private void currentHPButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (currentHPBox.Text.Trim().Length > 0 && int.TryParse(currentHPBox.Text, out result))
            {
                if (result >= 0)
                {
                    currentHPBlock.Text = result.ToString();
                    currentHPBox.Text = "";
                    (App.Current as App).Character.ActiveStats.CurrentHP = result;

                }
                else
                {
                    currentHPBlock.Text = "0";
                    (App.Current as App).Character.ActiveStats.CurrentHP = 0;
                    currentHPBox.Text = "";
                }
            }
            else
            {
                currentHPBox.Text = "";
            }
        }
    }
}

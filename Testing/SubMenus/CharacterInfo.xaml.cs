using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
    public sealed partial class CharacterInfo : Page
    {
        public CharacterInfo()
        {
            this.InitializeComponent();
        }

        private void nameOk_Click(object sender, RoutedEventArgs e)
        {
            if(nameBox.Text.Trim().Length > 0)
            {
                name.Text = nameBox.Text;
                nameBox.Text = "";
            }
            else
            {
                nameBox.Text = "";
            }
            
        }

        private void titleOk_Click(object sender, RoutedEventArgs e)
        {
            title.Text = titleBox.Text;
            titleBox.Text = "";
        }

        private void classOk_Click(object sender, RoutedEventArgs e)
        {
            if (classBox.Text.Trim().Length > 0)
            {
                classBlock.Text = classBox.Text;
                classBox.Text = "";
            }
            else
            {
                classBox.Text = "";
            }
        }

        private void levelOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (levelBox.Text.Trim().Length > 0)
            {
                char[] levelAsChar = levelBox.Text.Trim().ToCharArray();
                for(int i = 0; i < levelAsChar.Length; i++)
                {
                    if(levelAsChar[i] >= 48 && levelAsChar[i] <= 57)
                    {
                        sb.Append(levelAsChar[i]);
                    }
                }

                string text = sb.ToString();
                int x = 0;
                Int32.TryParse(text, out x);

                if(x > 0 && x <= 20)
                {
                    levelBlock.Text = text;
                    levelBox.Text = "";
                }
                else
                {
                    levelBox.Text = "";
                }
                    
            }
            else
            {
                levelBox.Text = "";
            }
        }

        private void bgOk_Click(object sender, RoutedEventArgs e)
        {
            if (bgBox.Text.Trim().Length > 0)
            {
                bgBlock.Text = bgBox.Text;
                bgBox.Text = "";
            }
            else
            {
                bgBox.Text = "";
            }
        }

        private void pnOk_Click(object sender, RoutedEventArgs e)
        {
            if (pnBox.Text.Trim().Length > 0)
            {
                pnBlock.Text = pnBox.Text;
                pnBox.Text = "";
            }
            else
            {
                pnBox.Text = "";
            }
        }

        private void raceOk_Click(object sender, RoutedEventArgs e)
        {
            if (raceBox.Text.Trim().Length > 0)
            {
                raceBlock.Text = raceBox.Text;
                raceBox.Text = "";
            }
            else
            {
                raceBox.Text = "";
            }
        }

        private void alignmentOk_Click(object sender, RoutedEventArgs e)
        {
            if (alignmentBox.Text.Trim().Length > 0)
            {
                alignmentBlock.Text = alignmentBox.Text;
                alignmentBox.Text = "";
            }
            else
            {
                alignmentBox.Text = "";
            }
        }

        private void currentEXPOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (currentBox.Text.Trim().Length > 0)
            {
                char[] currentAsChar = currentBox.Text.Trim().ToCharArray();
                for (int i = 0; i < currentAsChar.Length; i++)
                {
                    if (currentAsChar[i] >= 48 && currentAsChar[i] <= 57)
                    {
                        sb.Append(currentAsChar[i]);
                    }
                }

                currentBlock.Text = sb.ToString();
                currentBox.Text = "";


            }
            else
            {
                currentBox.Text = "";
            }
        }

        private void goalEXPOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (goalBox.Text.Trim().Length > 0)
            {
                char[] goalAsChar = goalBox.Text.Trim().ToCharArray();
                for (int i = 0; i < goalAsChar.Length; i++)
                {
                    if (goalAsChar[i] >= 48 && goalAsChar[i] <= 57)
                    {
                        sb.Append(goalAsChar[i]);
                    }
                }

                goalBlock.Text = sb.ToString();
                goalBox.Text = "";
                

            }
            else
            {
                goalBox.Text = "";
            }
        }
    }
}

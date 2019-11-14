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

        private void strengthOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (strengthBox.Text.Trim().Length > 0)
            {
                char[] goalAsChar = strengthBox.Text.Trim().ToCharArray();
                for (int i = 0; i < goalAsChar.Length; i++)
                {
                    if (goalAsChar[i] >= 48 && goalAsChar[i] <= 57)
                    {
                        sb.Append(goalAsChar[i]);
                    }
                }

                StrBlock.Text = sb.ToString();
                strengthBox.Text = "";

                int mod = 0;
                int statnum = 0;
                string stat = sb.ToString();

                Int32.TryParse(stat, out statnum);
                statnum -= 10;
                mod = statnum / 2;
                if(mod >= 0)
                {
                    strModBlock.Text =  "+" + mod.ToString();
                }
                else if (mod < 0 && sb.ToString().Length > 0)
                {
                    strModBlock.Text = mod.ToString();
                }


            }
            else
            {
                strengthBox.Text = "";
                strModBlock.Text = "";
            }
        }

        private void dexOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (dexBox.Text.Trim().Length > 0)
            {
                char[] goalAsChar = dexBox.Text.Trim().ToCharArray();
                for (int i = 0; i < goalAsChar.Length; i++)
                {
                    if (goalAsChar[i] >= 48 && goalAsChar[i] <= 57)
                    {
                        sb.Append(goalAsChar[i]);
                    }
                }

                dexBlock.Text = sb.ToString();
                dexBox.Text = "";

                int mod = 0;
                int statnum = 0;
                string stat = sb.ToString();

                Int32.TryParse(stat, out statnum);
                statnum -= 10;
                mod = statnum / 2;
                if (mod >= 0)
                {
                    dexModBlock.Text = "+" + mod.ToString();
                }
                else if (mod < 0 && sb.ToString().Length > 0)
                {
                    dexModBlock.Text = mod.ToString();
                }


            }
            else
            {
                dexBox.Text = "";
                dexModBlock.Text = "";
            }
        }

        private void conOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (conBox.Text.Trim().Length > 0)
            {
                char[] goalAsChar = conBox.Text.Trim().ToCharArray();
                for (int i = 0; i < goalAsChar.Length; i++)
                {
                    if (goalAsChar[i] >= 48 && goalAsChar[i] <= 57)
                    {
                        sb.Append(goalAsChar[i]);
                    }
                }

                conBlock.Text = sb.ToString();
                conBox.Text = "";

                int mod = 0;
                int statnum = 0;
                string stat = sb.ToString();

                Int32.TryParse(stat, out statnum);
                statnum -= 10;
                mod = statnum / 2;
                if (mod >= 0)
                {
                    conModBlock.Text = "+" + mod.ToString();
                }
                else if (mod < 0 && sb.ToString().Length > 0)
                {
                    conModBlock.Text = mod.ToString();
                }


            }
            else
            {
                conBox.Text = "";
                conModBlock.Text = "";
            }
        }

        private void intOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (intBox.Text.Trim().Length > 0)
            {
                char[] goalAsChar = intBox.Text.Trim().ToCharArray();
                for (int i = 0; i < goalAsChar.Length; i++)
                {
                    if (goalAsChar[i] >= 48 && goalAsChar[i] <= 57)
                    {
                        sb.Append(goalAsChar[i]);
                    }
                }

                intBlock.Text = sb.ToString();
                intBox.Text = "";

                int mod = 0;
                int statnum = 0;
                string stat = sb.ToString();

                Int32.TryParse(stat, out statnum);
                statnum -= 10;
                mod = statnum / 2;
                if (mod >= 0)
                {
                    intModBlock.Text = "+" + mod.ToString();
                }
                else if (mod < 0 && sb.ToString().Length > 0)
                {
                    intModBlock.Text = mod.ToString();
                }


            }
            else
            {
                intBox.Text = "";
                intModBlock.Text = "";
            }
        }

        private void wisOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (wisBox.Text.Trim().Length > 0)
            {
                char[] goalAsChar = wisBox.Text.Trim().ToCharArray();
                for (int i = 0; i < goalAsChar.Length; i++)
                {
                    if (goalAsChar[i] >= 48 && goalAsChar[i] <= 57)
                    {
                        sb.Append(goalAsChar[i]);
                    }
                }

                wisBlock.Text = sb.ToString();
                wisBox.Text = "";

                int mod = 0;
                int statnum = 0;
                string stat = sb.ToString();

                Int32.TryParse(stat, out statnum);
                statnum -= 10;
                mod = statnum / 2;
                if (mod >= 0)
                {
                    wisModBlock.Text = "+" + mod.ToString();
                }
                else if (mod < 0 && sb.ToString().Length > 0)
                {
                    wisModBlock.Text = mod.ToString();
                }


            }
            else
            {
                wisBox.Text = "";
                wisModBlock.Text = "";
            }
        }

        private void chaOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (chaBox.Text.Trim().Length > 0)
            {
                char[] goalAsChar = chaBox.Text.Trim().ToCharArray();
                for (int i = 0; i < goalAsChar.Length; i++)
                {
                    if (goalAsChar[i] >= 48 && goalAsChar[i] <= 57)
                    {
                        sb.Append(goalAsChar[i]);
                    }
                }

                chaBlock.Text = sb.ToString();
                chaBox.Text = "";

                int mod = 0;
                int statnum = 0;
                string stat = sb.ToString();

                Int32.TryParse(stat, out statnum);
                statnum -= 10;
                mod = statnum / 2;
                if (mod >= 0)
                {
                    chaModBlock.Text = "+" + mod.ToString();
                }
                else if (mod < 0 && sb.ToString().Length > 0)
                {
                    chaModBlock.Text = mod.ToString();
                }


            }
            else
            {
                chaBox.Text = "";
                chaModBlock.Text = "";
            }
        }

        private void flawOk_Click(object sender, RoutedEventArgs e)
        {
            flawBlock.Text = flawBox.Text;
            flawBox.Text = "";
        }

        private void bondOk_Click(object sender, RoutedEventArgs e)
        {
            bondBlock.Text = bondBox.Text;
            bondBox.Text = "";
        }

        private void idealOk_Click(object sender, RoutedEventArgs e)
        {
            idealBlock.Text = idealBox.Text;
            idealBox.Text = "";
        }

        private void personalityOk_Click(object sender, RoutedEventArgs e)
        {
            personalityBlock.Text = personalityBox.Text;
            personalityBox.Text = "";
        }

        private void CIBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

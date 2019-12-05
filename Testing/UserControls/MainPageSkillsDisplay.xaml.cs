using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Testing.UserControls
{
    public sealed partial class MainPageSkillsDisplay : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainPageSkillsDisplay()
        {
            this.InitializeComponent();
            if(CheckBox == "true")
            {
                
            }
        }
        public string Text
        {
            get { return mod.Text; }
            set { mod.Text = value; }
        }

        public string CheckBox
        {
            get { return proficiency.Text; }
            set
            {
                proficiency.Text = value;
                FieldChanged();
            }
        }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
            if (field == "CheckBox")
            {
                if (CheckBox == "False")
                {
                    proficiency.Text = "";
                }
                else
                {
                    proficiency.Text = "☑";
                }
            }
        }

        private void mod_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}

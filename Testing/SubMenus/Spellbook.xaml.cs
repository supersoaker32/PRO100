using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Testing.Models;
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
    public sealed partial class Spellbook : Page
    {
        public Spellbook()
        {
            this.InitializeComponent();
            foreach (Spell spell in (App.Current as App).Spells)
            {
                TextBox row1TextBox = new TextBox();
                row1TextBox.Text = spell.SpellName;

                TextBox row2TextBox = new TextBox();
                row2TextBox.Text = spell.SpellName;

                Grid newGrid = new Grid();
                RowDefinition row1 = new RowDefinition();
                RowDefinition row2 = new RowDefinition();
                newGrid.RowDefinitions.Add(row1);
                newGrid.RowDefinitions.Add(row2);
                newGrid.Children.Add(row1TextBox);

                Grid.SetRow(row2TextBox, 1);

                Spells.Children.Add(newGrid);
            }
        }
    }
}

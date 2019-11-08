using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Spellbook : Page
    {

        List<Spell> spells;
        public Spellbook()
        {
            this.InitializeComponent();
            spells = new List<Spell>();
            foreach (Spell spell in spells)
            {
                Grid newGrid = new Grid();
                newGrid.DataContext = spell;
                RowDefinition row1 = new RowDefinition();
                RowDefinition row2 = new RowDefinition();
                newGrid.RowDefinitions.Add(row1);
                newGrid.RowDefinitions.Add(row2);
                newGrid.Background = new SolidColorBrush(Colors.PapayaWhip);
                newGrid.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 16, 46, 102));
                newGrid.BorderThickness = new Thickness(8);
                newGrid.Margin = new Thickness(3);
                newGrid.CornerRadius = new CornerRadius(20);

                TextBox row1TextBox = new TextBox();
                Binding binding = new Binding();
                binding.Path = new PropertyPath("SpellName");
                binding.Mode = BindingMode.TwoWay;
                row1TextBox.SetBinding(TextBox.TextProperty, binding);

                row1TextBox.Text = spell.SpellName;

                TextBox row2TextBox = new TextBox();
                binding = new Binding();
                binding.Path = new PropertyPath("SpellName");
                binding.Mode = BindingMode.TwoWay;
                row2TextBox.SetBinding(TextBox.TextProperty, binding);

                row2TextBox.Text = spell.SpellDescription;

                newGrid.Children.Add(row1TextBox);

                Grid.SetRow(row2TextBox, 1);

                Spells.Children.Add(newGrid);
            }
        }

        private void Spells_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Spell newSpell = new Spell();
            Grid newGrid = new Grid();
            newGrid.DataContext = newSpell;
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(9, GridUnitType.Star);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(1, GridUnitType.Star);
            newGrid.RowDefinitions.Add(row1);
            newGrid.RowDefinitions.Add(row2);
            newGrid.ColumnDefinitions.Add(col1);
            newGrid.ColumnDefinitions.Add(col2);
            newGrid.Background = new SolidColorBrush(Colors.PapayaWhip);
            newGrid.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 16, 46, 102));
            newGrid.BorderThickness = new Thickness(8);
            newGrid.Margin = new Thickness(3);
            newGrid.CornerRadius = new CornerRadius(20);

            TextBox row1TextBox = new TextBox();

            Binding binding = new Binding();
            binding.Path = new PropertyPath("SpellName");
            binding.Mode = BindingMode.TwoWay;
            row1TextBox.SetBinding(TextBox.TextProperty, binding);

            row1TextBox.TextWrapping = TextWrapping.Wrap;
            row1TextBox.AcceptsReturn = true;

            row1TextBox.Text = newSpell.SpellName;
            newGrid.Children.Add(row1TextBox);

            TextBox row2TextBox = new TextBox();
            Grid.SetRow(row2TextBox, 1);

            binding = new Binding();
            binding.Path = new PropertyPath("SpellDescription");
            binding.Mode = BindingMode.TwoWay;
            row2TextBox.SetBinding(TextBox.TextProperty, binding);

            row2TextBox.TextWrapping = TextWrapping.Wrap;
            row2TextBox.AcceptsReturn = true;

            row2TextBox.Text = newSpell.SpellDescription;
            newGrid.Children.Add(row2TextBox);

            Button newButton = new Button();

            newButton.Content = "Remove";
            newButton.FontSize = 24;
            newButton.Click += Remove_Click;
            newButton.HorizontalContentAlignment = HorizontalAlignment.Center;
            newButton.HorizontalAlignment = HorizontalAlignment.Center;
            newButton.VerticalContentAlignment = VerticalAlignment.Center;
            newButton.VerticalAlignment = VerticalAlignment.Center;
            newButton.Height = 50;

            Grid.SetColumn(newButton, 1);
            Grid.SetRowSpan(newButton, 2);
            newGrid.Children.Add(newButton);

            Spells.Children.Add(newGrid);
            spells.Add(newSpell);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Spells.Children.Remove((sender as Button).Parent as Grid);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            spells = e.Parameter as List<Spell>;
        }
    }
}

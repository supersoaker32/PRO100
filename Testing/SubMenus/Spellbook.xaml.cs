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
        Grid editedGrid;
        public Spellbook()
        {
            this.InitializeComponent();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (replaceSpellButton.Visibility == Visibility.Collapsed)
            {
                (App.Current as App).Character.Spellbook.Remove(((sender as Button).Parent as Grid).DataContext as Spell);
                Spells.Children.Remove((sender as Button).Parent as Grid);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            foreach (Object child in ((sender as Button).Parent as Grid).Children)
            {
                if ((child as Border) != null)
                {
                    if (((child as Border).Child as TextBlock).Name == "spellsName")
                    {
                        spellDictionary.Text = ((child as Border).Child as TextBlock).Text;
                    }
                    else if (((child as Border).Child as TextBlock).Name == "spellsDescription")
                    {
                        spellDescription.Text = ((child as Border).Child as TextBlock).Text;
                    }
                }
                editedGrid = ((sender as Button).Parent as Grid);
            }
            replaceSpellButton.Visibility = Visibility.Visible;

            addSpellButton.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (Spell spell in (App.Current as App).Character.Spellbook)
            {
                Grid newGrid = new Grid();
                newGrid.DataContext = spell;

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

                Border textBlock1Border = new Border();
                textBlock1Border.BorderBrush = new SolidColorBrush(Colors.DarkGray);
                textBlock1Border.BorderThickness = new Thickness(3);
                textBlock1Border.HorizontalAlignment = HorizontalAlignment.Stretch;

                bonusBlock.Text = (App.Current as App).Character.SpellSave.ToString();
                saveBlock.Text = (App.Current as App).Character.SpellMod.ToString();

                firstSlots.Text = (App.Current as App).Character.SpellSlots[0].ToString();
                secondSlots.Text = (App.Current as App).Character.SpellSlots[1].ToString();
                thirdSlots.Text = (App.Current as App).Character.SpellSlots[2].ToString();
                fourthSlots.Text = (App.Current as App).Character.SpellSlots[3].ToString();
                fifthSlots.Text = (App.Current as App).Character.SpellSlots[4].ToString();
                sixthSlots.Text = (App.Current as App).Character.SpellSlots[5].ToString();
                seventhSlots.Text = (App.Current as App).Character.SpellSlots[6].ToString();
                eighthSlots.Text = (App.Current as App).Character.SpellSlots[7].ToString();
                ninthSlots.Text = (App.Current as App).Character.SpellSlots[8].ToString();

                TextBlock row1TextBlock = new TextBlock();
                row1TextBlock.Name = "spellsName";
                Binding binding = new Binding();
                binding.Path = new PropertyPath("SpellName");
                binding.Mode = BindingMode.OneWay;
                row1TextBlock.FontSize = 25;
                row1TextBlock.TextWrapping = TextWrapping.Wrap;
                row1TextBlock.SetBinding(TextBlock.TextProperty, binding);

                row1TextBlock.Text = spell.SpellName;
                textBlock1Border.Child = row1TextBlock;
                newGrid.Children.Add(textBlock1Border);

                Border textBlock2Border = new Border();
                textBlock2Border.BorderBrush = new SolidColorBrush(Colors.DarkGray);
                textBlock2Border.BorderThickness = new Thickness(3);
                textBlock2Border.HorizontalAlignment = HorizontalAlignment.Stretch;

                TextBlock row2TextBlock = new TextBlock();
                row2TextBlock.Name = "spellsDescription";
                Grid.SetRow(textBlock2Border, 1);

                binding = new Binding();
                binding.Path = new PropertyPath("SpellName");
                binding.Mode = BindingMode.OneWay;
                row2TextBlock.FontSize = 25;
                row2TextBlock.TextWrapping = TextWrapping.Wrap;
                row2TextBlock.SetBinding(TextBlock.TextProperty, binding);

                row2TextBlock.Text = spell.SpellDescription;
                textBlock2Border.Child = row2TextBlock;
                newGrid.Children.Add(textBlock2Border);

                Button removeButton = new Button();

                removeButton.Content = "Remove";
                removeButton.FontSize = 24;
                removeButton.Click += Remove_Click;
                removeButton.HorizontalContentAlignment = HorizontalAlignment.Center;
                removeButton.HorizontalAlignment = HorizontalAlignment.Stretch;
                removeButton.VerticalContentAlignment = VerticalAlignment.Center;
                removeButton.VerticalAlignment = VerticalAlignment.Stretch;
                removeButton.BorderBrush = new SolidColorBrush(Colors.Black);
                removeButton.BorderThickness = new Thickness(3);

                Grid.SetColumn(removeButton, 1);

                newGrid.Children.Add(removeButton);
                Button editButton = new Button();

                editButton.Content = "Edit";
                editButton.FontSize = 24;
                editButton.Click += Edit_Click;
                editButton.HorizontalContentAlignment = HorizontalAlignment.Center;
                editButton.HorizontalAlignment = HorizontalAlignment.Stretch;
                editButton.VerticalContentAlignment = VerticalAlignment.Center;
                editButton.VerticalAlignment = VerticalAlignment.Stretch;
                editButton.BorderBrush = new SolidColorBrush(Colors.Black);
                editButton.BorderThickness = new Thickness(3);

                Grid.SetColumn(editButton, 1);
                Grid.SetRow(editButton, 1);

                newGrid.Children.Add(editButton);

                Spells.Children.Add(newGrid);
            }

            spellDictionary.ItemsSource = (App.Current as App).Dictionary.SpellNames;
        }

        private void addSpellButton_Click(object sender, RoutedEventArgs e)
        {
            AddSpell(sender);
        }

        private void replaceSpellButton_Click(object sender, RoutedEventArgs e)
        {
            AddSpell(sender, true);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private Grid ConstructSpellDisplay(Spell newSpell)
        {
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


            Border textBlock1Border = new Border();
            textBlock1Border.BorderBrush = new SolidColorBrush(Colors.DarkGray);
            textBlock1Border.BorderThickness = new Thickness(3);
            textBlock1Border.HorizontalAlignment = HorizontalAlignment.Stretch;

            TextBlock row1TextBlock = new TextBlock();
            row1TextBlock.Name = "spellsName";
            Binding binding = new Binding();
            binding.Path = new PropertyPath("SpellName");
            binding.Mode = BindingMode.OneWay;
            row1TextBlock.SetBinding(TextBlock.TextProperty, binding);
            row1TextBlock.FontSize = 25;
            row1TextBlock.TextWrapping = TextWrapping.Wrap;

            row1TextBlock.Margin = new Thickness(5);

            row1TextBlock.Text = newSpell.SpellName;
            textBlock1Border.Child = row1TextBlock;
            newGrid.Children.Add(textBlock1Border);

            Border textBlock2Border = new Border();
            textBlock2Border.BorderBrush = new SolidColorBrush(Colors.DarkGray);
            textBlock2Border.BorderThickness = new Thickness(3);
            textBlock2Border.HorizontalAlignment = HorizontalAlignment.Stretch;

            TextBlock row2TextBlock = new TextBlock();
            row2TextBlock.Name = "spellsDescription";
            Grid.SetRow(textBlock2Border, 1);

            binding = new Binding();
            binding.Path = new PropertyPath("SpellDescription");
            binding.Mode = BindingMode.OneWay;
            row2TextBlock.SetBinding(TextBlock.TextProperty, binding);
            row2TextBlock.FontSize = 25;
            row2TextBlock.TextWrapping = TextWrapping.Wrap;

            row2TextBlock.Margin = new Thickness(5);

            row2TextBlock.Text = newSpell.SpellDescription;
            textBlock2Border.Child = row2TextBlock;
            newGrid.Children.Add(textBlock2Border);

            Button removeButton = new Button();

            removeButton.Content = "Remove";
            removeButton.FontSize = 24;
            removeButton.Click += Remove_Click;
            removeButton.HorizontalContentAlignment = HorizontalAlignment.Center;
            removeButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            removeButton.VerticalContentAlignment = VerticalAlignment.Center;
            removeButton.VerticalAlignment = VerticalAlignment.Stretch;
            removeButton.BorderBrush = new SolidColorBrush(Colors.Black);
            removeButton.BorderThickness = new Thickness(3);

            Grid.SetColumn(removeButton, 1);

            newGrid.Children.Add(removeButton);
            Button editButton = new Button();

            editButton.Content = "Edit";
            editButton.FontSize = 24;
            editButton.Click += Edit_Click;
            editButton.HorizontalContentAlignment = HorizontalAlignment.Center;
            editButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            editButton.VerticalContentAlignment = VerticalAlignment.Center;
            editButton.VerticalAlignment = VerticalAlignment.Stretch;
            editButton.BorderBrush = new SolidColorBrush(Colors.Black);
            editButton.BorderThickness = new Thickness(3);

            Grid.SetColumn(editButton, 1);
            Grid.SetRow(editButton, 1);

            newGrid.Children.Add(editButton);
            return newGrid;
        }

        private void AddSpell(object sender, bool replace = false)
        {
            if (!replace)
            {
                Spell newSpell = new Spell();
                newSpell.SpellName = spellDictionary.Text;
                newSpell.SpellDescription = spellDescription.Text;
                Grid newGrid = ConstructSpellDisplay(newSpell);

                Spells.Children.Add(newGrid);
                (App.Current as App).Character.Spellbook.Add(newSpell);
                spellDictionary.Text = "";
                spellDictionary.SelectedIndex = -1;
                spellDescription.Text = "";
            }
            if (replace)
            {
                Grid newGrid = null;
                Spell newSpell = new Spell();
                Spell replacedSpell = editedGrid.DataContext as Spell;
                foreach (object spellsChild in Spells.Children)
                {
                    foreach (object sendersChild in ((sender as Button).Parent as Grid).Children)
                    {
                        if ((sendersChild as TextBox) != null)
                        {
                            if ((sendersChild as TextBox).Name == "spellDescription")
                            {
                                newSpell.SpellDescription = (sendersChild as TextBox).Text;
                            }
                        }
                        if ((sendersChild as ComboBox) != null)
                        {
                            if ((sendersChild as ComboBox).Name == "spellDictionary")
                            {
                                newSpell.SpellName = (sendersChild as ComboBox).Text;
                            }
                        }
                    }
                    if (newGrid == null && Spells.Children.IndexOf((spellsChild as Grid)) == Spells.Children.IndexOf(editedGrid))
                    {
                        newGrid = ConstructSpellDisplay(newSpell);
                    }
                }
                Spells.Children.Insert(Spells.Children.IndexOf(editedGrid), newGrid);
                Spells.Children.RemoveAt(Spells.Children.IndexOf(editedGrid));
                addSpellButton.Visibility = Visibility.Visible;
                replaceSpellButton.Visibility = Visibility.Collapsed;

                spellDictionary.Text = "";
                spellDictionary.SelectedIndex = -1;
                spellDescription.Text = "";

                (App.Current as App).Character.Spellbook.Insert((App.Current as App).Character.Spellbook.IndexOf(replacedSpell), newSpell);
                (App.Current as App).Character.Spellbook.RemoveAt((App.Current as App).Character.Spellbook.IndexOf(replacedSpell));
            }
        }

        private void spellDictionary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = 0;
            for(int i = 0; i< (App.Current as App).Dictionary.SpellNames.Count; i++)
            {
                if((App.Current as App).Dictionary.SpellNames.ElementAt(i) == spellDictionary.Text)
                {
                    index = i;
                }
            }
            spellDescription.Text = (App.Current as App).Dictionary.SpellDescriptions.ElementAt(index);
        }

        private void bonusOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(bonusBox.Text, out stat);
            bonusBox.Text = "";

            bonusBlock.Text = stat.ToString();
        }

        private void saveOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(saveBox.Text, out stat);
            saveBox.Text = "";

            saveBlock.Text = stat.ToString();
        }

        private void firstOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(firstBox.Text, out stat);
            firstBox.Text = "";

            firstSlots.Text = stat.ToString();
        }

        private void secondOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(secondBox.Text, out stat);
            secondBox.Text = "";

            secondSlots.Text = stat.ToString();
        }

        private void thirdOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(thirdBox.Text, out stat);
            thirdBox.Text = "";

            thirdSlots.Text = stat.ToString();
        }

        private void fourthOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(fourthBox.Text, out stat);
            fourthBox.Text = "";

            fourthSlots.Text = stat.ToString();
        }

        private void fifthOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(fifthBox.Text, out stat);
            fifthBox.Text = "";

            fifthSlots.Text = stat.ToString();
        }

        private void sixthOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(sixthBox.Text, out stat);
            sixthBox.Text = "";

            sixthSlots.Text = stat.ToString();
        }

        private void seventhOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(seventhBox.Text, out stat);
            seventhBox.Text = "";

            seventhSlots.Text = stat.ToString();
        }

        private void eighthOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(eighthBox.Text, out stat);
            eighthBox.Text = "";

            eighthSlots.Text = stat.ToString();
        }

        private void ninthOK_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            Int32.TryParse(ninthBox.Text, out stat);
            ninthBox.Text = "";

            ninthSlots.Text = stat.ToString();
        }
    }
}

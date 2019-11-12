﻿using System;
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
                (App.Current as App).SpellsList.Remove(((sender as Button).Parent as Grid).DataContext as Spell);
                Spells.Children.Remove((sender as Button).Parent as Grid);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            foreach (Object child in ((sender as Button).Parent as Grid).Children)
            {
                if ((child as Border) != null)
                {
                    if(((child as Border).Child as TextBlock).Name == "spellsName")
                    {
                        spellName.Text = ((child as Border).Child as TextBlock).Text;
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
            foreach (Spell spell in (App.Current as App).SpellsList)
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

                TextBlock row1TextBlock = new TextBlock();
                row1TextBlock.Name = "spellsName";
                Binding binding = new Binding();
                binding.Path = new PropertyPath("SpellName");
                binding.Mode = BindingMode.OneWay;
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
        }

        private void addSpellButton_Click(object sender, RoutedEventArgs e)
        {
            Spell newSpell = new Spell();
            newSpell.SpellName = spellName.Text;
            newSpell.SpellDescription = spellDescription.Text;

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

            Spells.Children.Add(newGrid);
            (App.Current as App).SpellsList.Add(newSpell);

            spellName.Text = "";
            spellDescription.Text = "";
        }

        private void replaceSpellButton_Click(object sender, RoutedEventArgs e)
        {
            Grid newGrid = null;
            Spell replacedSpell = new Spell();
            foreach (object spellsChild in Spells.Children)
            {
                foreach (object sendersChild in ((sender as Button).Parent as Grid).Children)
                {
                    if ((sendersChild as TextBox) != null)
                    {
                        if ((sendersChild as TextBox).Name == "spellName")
                        {
                            replacedSpell.SpellName = (sendersChild as TextBox).Text;
                        }
                        else if ((sendersChild as TextBox).Name == "spellDescription")
                        {
                            replacedSpell.SpellDescription = (sendersChild as TextBox).Text;
                        }
                    }
                }

                if (newGrid == null && Spells.Children.IndexOf((spellsChild as Grid)) == Spells.Children.IndexOf(editedGrid))
                {
                    newGrid = new Grid();
                    newGrid.DataContext = replacedSpell;

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

                    row1TextBlock.TextWrapping = TextWrapping.Wrap;

                    row1TextBlock.Margin = new Thickness(5);

                    row1TextBlock.Text = replacedSpell.SpellName;
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

                    row2TextBlock.TextWrapping = TextWrapping.Wrap;

                    row2TextBlock.Margin = new Thickness(5);

                    row2TextBlock.Text = replacedSpell.SpellDescription;
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
                }
            }
            Spells.Children.Insert(Spells.Children.IndexOf(editedGrid), newGrid);
            Spells.Children.RemoveAt(Spells.Children.IndexOf(editedGrid));
            addSpellButton.Visibility = Visibility.Visible;
            replaceSpellButton.Visibility = Visibility.Collapsed;

            spellName.Text = "";
            spellDescription.Text = "";
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

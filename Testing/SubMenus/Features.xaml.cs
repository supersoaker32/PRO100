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
    public sealed partial class Features : Page
    {
        Grid editedGrid;
        public Features()
        {
            this.InitializeComponent();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (replaceFeatureButton.Visibility == Visibility.Collapsed)
            {
                (App.Current as App).Character.FeatureList.Remove(((sender as Button).Parent as Grid).DataContext as Feature);
                FeaturesList.Children.Remove((sender as Button).Parent as Grid);
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
                        featureName.Text = ((child as Border).Child as TextBlock).Text;
                    }
                    else if (((child as Border).Child as TextBlock).Name == "spellsDescription")
                    {
                        featureDescription.Text = ((child as Border).Child as TextBlock).Text;
                    }
                }
                editedGrid = ((sender as Button).Parent as Grid);
            }
            replaceFeatureButton.Visibility = Visibility.Visible;

            addFeatureButton.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (Feature feature in (App.Current as App).Character.FeatureList)
            {
                Grid newGrid = new Grid();
                newGrid.DataContext = feature;

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
                binding.Path = new PropertyPath("FeatureName");
                binding.Mode = BindingMode.OneWay;
                row1TextBlock.SetBinding(TextBlock.TextProperty, binding);

                row1TextBlock.Text = feature.FeatureName;
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
                binding.Path = new PropertyPath("FeatureName");
                binding.Mode = BindingMode.OneWay;
                row2TextBlock.SetBinding(TextBlock.TextProperty, binding);

                row2TextBlock.Text = feature.FeatureDescription;
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

                FeaturesList.Children.Add(newGrid);
            }
        }

        private void addFeatureButton_Click(object sender, RoutedEventArgs e)
        {
            Feature newFeature = new Feature();
            newFeature.FeatureName = featureName.Text;
            newFeature.FeatureDescription = featureDescription.Text;

            Grid newGrid = new Grid();
            newGrid.DataContext = newFeature;

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
            binding.Path = new PropertyPath("FeatureName");
            binding.Mode = BindingMode.OneWay;
            row1TextBlock.SetBinding(TextBlock.TextProperty, binding);

            row1TextBlock.TextWrapping = TextWrapping.Wrap;

            row1TextBlock.Margin = new Thickness(5);

            row1TextBlock.Text = newFeature.FeatureName;
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
            binding.Path = new PropertyPath("FeatureDescription");
            binding.Mode = BindingMode.OneWay;
            row2TextBlock.SetBinding(TextBlock.TextProperty, binding);

            row2TextBlock.TextWrapping = TextWrapping.Wrap;

            row2TextBlock.Margin = new Thickness(5);

            row2TextBlock.Text = newFeature.FeatureDescription;
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

            FeaturesList.Children.Add(newGrid);
            (App.Current as App).Character.FeatureList.Add(newFeature);

            featureName.Text = "";
            featureDescription.Text = "";
        }

        private void replaceFeatureButton_Click(object sender, RoutedEventArgs e)
        {
            Grid newGrid = null;
            Feature newFeature = new Feature();
            Feature replacedFeature = editedGrid.DataContext as Feature;

            foreach (object featuresChild in FeaturesList.Children)
            {
                foreach (object sendersChild in ((sender as Button).Parent as Grid).Children)
                {
                    if ((sendersChild as TextBox) != null)
                    {
                        if ((sendersChild as TextBox).Name == "featureName")
                        {
                            newFeature.FeatureName = (sendersChild as TextBox).Text;
                        }
                        else if ((sendersChild as TextBox).Name == "featureDescription")
                        {
                            newFeature.FeatureDescription = (sendersChild as TextBox).Text;
                        }
                    }
                }

                if (newGrid == null && FeaturesList.Children.IndexOf((featuresChild as Grid)) == FeaturesList.Children.IndexOf(editedGrid))
                {
                    newGrid = new Grid();
                    newGrid.DataContext = newFeature;

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
                    binding.Path = new PropertyPath("FeatureName");
                    binding.Mode = BindingMode.OneWay;
                    row1TextBlock.SetBinding(TextBlock.TextProperty, binding);

                    row1TextBlock.TextWrapping = TextWrapping.Wrap;

                    row1TextBlock.Margin = new Thickness(5);

                    row1TextBlock.Text = newFeature.FeatureName;
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
                    binding.Path = new PropertyPath("FeatureDescription");
                    binding.Mode = BindingMode.OneWay;
                    row2TextBlock.SetBinding(TextBlock.TextProperty, binding);

                    row2TextBlock.TextWrapping = TextWrapping.Wrap;

                    row2TextBlock.Margin = new Thickness(5);

                    row2TextBlock.Text = newFeature.FeatureDescription;
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
            FeaturesList.Children.Insert(FeaturesList.Children.IndexOf(editedGrid), newGrid);
            FeaturesList.Children.RemoveAt(FeaturesList.Children.IndexOf(editedGrid));
            addFeatureButton.Visibility = Visibility.Visible;
            replaceFeatureButton.Visibility = Visibility.Collapsed;

            featureName.Text = "";
            featureDescription.Text = "";

            (App.Current as App).Character.FeatureList.Insert((App.Current as App).Character.FeatureList.IndexOf(replacedFeature), newFeature);
            (App.Current as App).Character.FeatureList.RemoveAt((App.Current as App).Character.FeatureList.IndexOf(replacedFeature));
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}


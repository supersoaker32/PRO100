﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using Testing.Models;
using Testing.SubMenus;
using Testing.UserControls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core.Preview;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Testing
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            if ((App.Current as App).Character.Spellbook == null)
            {
                (App.Current as App).Character.Spellbook = new List<Spell>();
            }
            if ((App.Current as App).Character.Inventory == null)
            {
                (App.Current as App).Character.Inventory = new InventoryData();
            }
            if ((App.Current as App).Character.SnPData == null)
            {
                (App.Current as App).Character.SnPData = new SkillsAndProficienciesData();
            }
            
        }

        private void CharInfo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CharacterInfo));
        }

        private void SkillsNProficiencies_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Skill[] modData = (App.Current as App).Character.SnPData.SkillModifiers;
            int i = 0;
            foreach (var mod in skillMods.Children)
            {
                int tmpVal;
                int.TryParse((mod as SkillsDisplay).Text, out tmpVal);
                modData[i++].Modifier = tmpVal;
            }
            modData = (App.Current as App).Character.SnPData.SavingThrows;
            i = 0;
            foreach (var mod in savingThrowMods.Children)
            {
                int tmpVal;
                int.TryParse((mod as SkillsDisplay).Text, out tmpVal);
                modData[i++].Modifier = tmpVal;
            }
            this.Frame.Navigate(typeof(SkillsNProficiencies));
        }

        private void ActiveStats_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ActiveStats));
        }

        private void Spellbook_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Spellbook));
        }

        private void Features_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Features));
        }

        private void Inventory_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Inventory));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            #region DisplaySpells
            Spells.Children.Clear();
            foreach (Spell spell in (App.Current as App).Character.Spellbook)
            {
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                SolidColorBrush color = new SolidColorBrush();
                color.Color = Colors.Black;

                TextBlock spellName = new TextBlock();
                spellName.Foreground = color;
                spellName.FontSize = 32;
                spellName.Text = spell.SpellName;
                Grid.SetRow(spellName, 0);
                grid.Children.Add(spellName);

                TextBlock spellDescription = new TextBlock();
                spellDescription.Foreground = color;
                spellDescription.FontSize = 32;
                spellDescription.Text = spell.SpellDescription;
                Grid.SetRow(spellDescription, 1);
                grid.Children.Add(spellDescription);

                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);

                Spells.Children.Add(grid);
            }
            #endregion

            #region DisplayFeatures
            Features.Children.Clear();
            foreach (Feature feature in (App.Current as App).Character.FeatureList)
            {
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                SolidColorBrush color = new SolidColorBrush();
                color.Color = Colors.Black;

                TextBlock featureName = new TextBlock();
                featureName.Foreground = color;
                featureName.FontSize = 32;
                featureName.Text = feature.FeatureName;
                Grid.SetRow(featureName, 0);
                grid.Children.Add(featureName);

                TextBlock featureDescription = new TextBlock();
                featureDescription.Foreground = color;
                featureDescription.FontSize = 32;
                featureDescription.Text = feature.FeatureDescription;
                Grid.SetRow(featureDescription, 1);
                grid.Children.Add(featureDescription);

                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);

                Features.Children.Add(grid);
            }
            #endregion

            #region DisplayInventory
            inventory.Children.Clear();
            if ((App.Current as App).Character.Inventory.Items != null)
            {
                foreach (Item itemObject in (App.Current as App).Character.Inventory.Items)
                {

                    //Create new shape and brush
                    TextBlock item = new TextBlock();
                    SolidColorBrush color = new SolidColorBrush();

                    //Set color
                    color.Color = Colors.Black;
                    item.Foreground = color;
                    item.FontSize = 55;
                    Grid grid = new Grid();
                    SolidColorBrush brush = new SolidColorBrush();
                    brush.Color = Colors.DarkGray;
                    grid.BorderBrush = brush;
                    grid.BorderThickness = new Thickness(3);
                    grid.CornerRadius = new CornerRadius(8);
                    item.Text = itemObject.Name;
                    grid.Children.Add(item);
                    inventory.Children.Add(grid);
                }
            }
            if ((App.Current as App).Character.Inventory.Money != null)
            {
                int sum = 0;
                foreach (int money in (App.Current as App).Character.Inventory.Money)
                {
                    sum += money;
                }
                moneyVal.Text = sum.ToString();
            }
            #endregion

            #region DisplayProficienciesAndSkills
            if ((App.Current as App).Character.SnPData.Proficiencies != null)
            {
                foreach (string proficiency in (App.Current as App).Character.SnPData.Proficiencies)
                {
                    TextBlock item = new TextBlock();
                    SolidColorBrush color = new SolidColorBrush();

                    //Set color
                    color.Color = Colors.Black;
                    item.Foreground = color;
                    item.FontSize = 44;
                    Grid grid = new Grid();
                    SolidColorBrush brush = new SolidColorBrush();
                    brush.Color = Colors.DarkGray;
                    grid.BorderBrush = brush;
                    grid.BorderThickness = new Thickness(3);
                    grid.CornerRadius = new CornerRadius(8);
                    item.Text = proficiency;
                    item.TextWrapping = TextWrapping.Wrap;
                    grid.Children.Add(item);
                    proficiencies.Children.Add(grid);
                }
            }
            if ((App.Current as App).Character.SnPData.SkillModifiers != null)
            {
                Skill[] modData = (App.Current as App).Character.SnPData.SkillModifiers;
                int i = 0;
                foreach (var mod in skillMods.Children)
                {
                    (mod as SkillsDisplay).DataContext = modData[i];
                    (mod as SkillsDisplay).Text = modData[i].Modifier.ToString();
                    (mod as SkillsDisplay).CheckBox = modData[i++].Proficient;
                }
            }
            if ((App.Current as App).Character.SnPData.SavingThrows != null)
            {
                Skill[] modData = (App.Current as App).Character.SnPData.SavingThrows;
                int i = 0;
                foreach (var mod in savingThrowMods.Children)
                {
                    (mod as SkillsDisplay).DataContext = modData[i];
                    (mod as SkillsDisplay).Text = modData[i].Modifier.ToString();
                    (mod as SkillsDisplay).CheckBox = modData[i++].Proficient;
                }
            }
            #endregion

            #region DisplayCharacterInfo
            charName.Text = (App.Current as App).Character.CharactersInfo.CharacterName;
            charTitle.Text = (App.Current as App).Character.CharactersInfo.Title;

            charClass.Text = (App.Current as App).Character.CharactersInfo.CharacterClass;
            charLevel.Text = (App.Current as App).Character.CharactersInfo.Level.ToString();
            charBG.Text = (App.Current as App).Character.CharactersInfo.Background[0];
            charPN.Text = (App.Current as App).Character.CharactersInfo.PlayerName;
            charRace.Text = (App.Current as App).Character.CharactersInfo.Race;
            charAlign.Text = (App.Current as App).Character.CharactersInfo.Allignment;
            charCurrent.Text = (App.Current as App).Character.CharactersInfo.CurrentEXP.ToString();
            charGoal.Text = (App.Current as App).Character.CharactersInfo.GoalEXP.ToString();

            charStr.Text = (App.Current as App).Character.CharactersInfo.Stats[0].ToString();
            if ((App.Current as App).Character.CharactersInfo.StatMods[0] >= 0)
            {
                charStrMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[0].ToString();
            }
            else
            {
                charStrMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[0].ToString();
            }

            charDex.Text = (App.Current as App).Character.CharactersInfo.Stats[1].ToString();
            if ((App.Current as App).Character.CharactersInfo.StatMods[1] >= 0)
            {
                charDexMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[1].ToString();
            }
            else
            {
                charDexMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[1].ToString();
            }

            charCon.Text = (App.Current as App).Character.CharactersInfo.Stats[2].ToString();
            if ((App.Current as App).Character.CharactersInfo.StatMods[2] >= 0)
            {
                charConMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[2].ToString();
            }
            else
            {
                charConMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[2].ToString();
            }

            charInt.Text = (App.Current as App).Character.CharactersInfo.Stats[3].ToString();
            if ((App.Current as App).Character.CharactersInfo.StatMods[3] >= 0)
            {
                charIntMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[3].ToString();
            }
            else
            {
                charIntMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[3].ToString();
            }

            charWis.Text = (App.Current as App).Character.CharactersInfo.Stats[4].ToString();
            if ((App.Current as App).Character.CharactersInfo.StatMods[4] >= 0)
            {
                charWisMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[4].ToString();
            }
            else
            {
                charWisMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[4].ToString();
            }

            charChar.Text = (App.Current as App).Character.CharactersInfo.Stats[5].ToString();
            if ((App.Current as App).Character.CharactersInfo.StatMods[5] >= 0)
            {
                charCharMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[5].ToString();
            }
            else
            {
                charCharMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[5].ToString();
            }
            #endregion
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveCharacter();
        }

        private async void SaveCharacter()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            Windows.Storage.Pickers.FileSavePicker picker = new Windows.Storage.Pickers.FileSavePicker();
            picker.FileTypeChoices.Add("Character File", new List<string> { ".char" });
            var file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                Stream stream = await file.OpenStreamForWriteAsync();
                serializer.Serialize(stream, (App.Current as App).Character);
            }
            else
            {
                saveloadText.Text = "Failure to save character.";
                failurePopup.IsOpen = true;
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            LoadCharacter();
        }

        private async void LoadCharacter()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".char");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                Stream stream = await file.OpenStreamForReadAsync();
                (App.Current as App).Character = (serializer.Deserialize(stream) as Character);
                displayCharacter();
            }
            else
            {
                saveloadText.Text = "Failure to load character.";
                failurePopup.IsOpen = true;
            }
        }

        private void displayCharacter()
        {
            charIcon.UriSource = (((App.Current as App).Character.CharactersInfo.PlayerImageURI.Equals("")) ? (new Uri("ms-appx:///Assets/Square44x44Logo.targetsize-24_altform-unplated.png")) : (new Uri((App.Current as App).Character.CharactersInfo.PlayerImageURI)));
            charName.Text = (App.Current as App).Character.CharactersInfo.CharacterName;
            charTitle.Text = (App.Current as App).Character.CharactersInfo.Title;
            charClass.Text = (App.Current as App).Character.CharactersInfo.CharacterClass;
            charLevel.Text = (App.Current as App).Character.CharactersInfo.Level.ToString();
            charBG.Text = (App.Current as App).Character.CharactersInfo.Background[0];
            charPN.Text = (App.Current as App).Character.CharactersInfo.PlayerName;
            charRace.Text = (App.Current as App).Character.CharactersInfo.Race;
            charAlign.Text = (App.Current as App).Character.CharactersInfo.Allignment;
            charCurrent.Text = (App.Current as App).Character.CharactersInfo.CurrentEXP.ToString();
            charGoal.Text = (App.Current as App).Character.CharactersInfo.GoalEXP.ToString();

            int i = 0;
            foreach(SkillsDisplay skill in skillMods.Children)
            {
                skill.Text = (App.Current as App).Character.SnPData.SkillModifiers[i++].ToString();
                //skill.CheckBox = (App.Current as App).Character.SnPData.
            }
            i = 0;
            foreach(SkillsDisplay savingThrow in savingThrowMods.Children)
            {
                savingThrow.Text = (App.Current as App).Character.SnPData.SavingThrows[i++].ToString();
            }

            foreach (string proficiency in (App.Current as App).Character.SnPData.Proficiencies)
            {
                TextBlock item = new TextBlock();
                SolidColorBrush color = new SolidColorBrush();

                //Set color
                color.Color = Colors.Black;
                item.Foreground = color;
                item.FontSize = 44;
                Grid grid = new Grid();
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);
                item.Text = proficiency;
                grid.Children.Add(item);
                proficiencies.Children.Add(grid);
            }

            charStr.Text = (App.Current as App).Character.CharactersInfo.Stats[0].ToString();
            charDex.Text = (App.Current as App).Character.CharactersInfo.Stats[1].ToString();
            charCon.Text = (App.Current as App).Character.CharactersInfo.Stats[2].ToString();
            charInt.Text = (App.Current as App).Character.CharactersInfo.Stats[3].ToString();
            charWis.Text = (App.Current as App).Character.CharactersInfo.Stats[4].ToString();
            charChar.Text = (App.Current as App).Character.CharactersInfo.Stats[5].ToString();

            charStrMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[0].ToString();
            charDexMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[1].ToString();
            charConMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[2].ToString();
            charIntMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[3].ToString();
            charWisMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[4].ToString();
            charCharMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[5].ToString();

            foreach (Spell spell in (App.Current as App).Character.Spellbook)
            {
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                SolidColorBrush color = new SolidColorBrush();
                color.Color = Colors.Black;

                TextBlock spellName = new TextBlock();
                spellName.Foreground = color;
                spellName.FontSize = 32;
                spellName.Text = spell.SpellName;
                Grid.SetRow(spellName, 0);
                grid.Children.Add(spellName);

                TextBlock spellDescription = new TextBlock();
                spellDescription.Foreground = color;
                spellDescription.FontSize = 32;
                spellDescription.Text = spell.SpellDescription;
                Grid.SetRow(spellDescription, 1);
                grid.Children.Add(spellDescription);

                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);

                Spells.Children.Add(grid);
            }

            foreach (Feature feature in (App.Current as App).Character.FeatureList)
            {
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                SolidColorBrush color = new SolidColorBrush();
                color.Color = Colors.Black;

                TextBlock featureName = new TextBlock();
                featureName.Foreground = color;
                featureName.FontSize = 32;
                featureName.Text = feature.FeatureName;
                Grid.SetRow(featureName, 0);
                grid.Children.Add(featureName);

                TextBlock featureDescription = new TextBlock();
                featureDescription.Foreground = color;
                featureDescription.FontSize = 32;
                featureDescription.Text = feature.FeatureDescription;
                Grid.SetRow(featureDescription, 1);
                grid.Children.Add(featureDescription);

                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);

                Features.Children.Add(grid);
            }

            moneyVal.Text = (App.Current as App).Character.Inventory.Money.Sum().ToString();

            foreach (Item itemObject in (App.Current as App).Character.Inventory.Items)
            {
                //Create new shape and brush
                TextBlock item = new TextBlock();
                SolidColorBrush color = new SolidColorBrush();

                //Set color
                color.Color = Colors.Black;
                item.Foreground = color;
                item.FontSize = 55;
                Grid grid = new Grid();
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);
                item.Text = itemObject.Name;
                grid.Children.Add(item);
                inventory.Children.Add(grid);
            }
        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            failurePopup.IsOpen = false;
        }

        private void Clear_Clicked(object sender, RoutedEventArgs e)
        {
            confirmationPopup.IsOpen = true;
        }

        private void YesClicked(object sender, RoutedEventArgs e)
        {
            confirmationPopup.IsOpen = false;

            charIcon.UriSource = new Uri("ms-appx:///Assets/Square44x44Logo.targetsize-24_altform-unplated.png");
            charName.Text = "";
            charTitle.Text = "";
            charClass.Text = "";
            charLevel.Text = (1).ToString();
            charBG.Text = "";
            charPN.Text = "";
            charRace.Text = "";
            charAlign.Text = "";
            charCurrent.Text = (0).ToString();
            charGoal.Text = (350).ToString();

            acrobatics.Text = (0).ToString();
            animalHandling.Text = (0).ToString();
            arcana.Text = (0).ToString();
            athletics.Text = (0).ToString();
            deception.Text = (0).ToString();
            history.Text = (0).ToString();
            insight.Text = (0).ToString();
            intimidation.Text = (0).ToString();
            investigation.Text = (0).ToString();
            medicine.Text = (0).ToString();
            nature.Text = (0).ToString();
            perception.Text = (0).ToString();
            performance.Text = (0).ToString();
            persuassion.Text = (0).ToString();
            religion.Text = (0).ToString();
            sleightOfHand.Text = (0).ToString();
            stealth.Text = (0).ToString();
            proficiencies.Children.Clear();
            charStr.Text = "0";
            charDex.Text = "0";
            charCon.Text = "0";
            charInt.Text = "0";
            charWis.Text = "0";
            charChar.Text = "0";
            charStrMod.Text = "+0";
            charDexMod.Text = "+0";
            charConMod.Text = "+0";
            charIntMod.Text = "+0";
            charWisMod.Text = "+0";
            charCharMod.Text = "+0";
            Spells.Children.Clear();
            Features.Children.Clear();
            moneyVal.Text = (0).ToString();
            inventory.Children.Clear();
        }

        private void NoClicked(object sender, RoutedEventArgs e)
        {
            confirmationPopup.IsOpen = false;
        }
    }
}

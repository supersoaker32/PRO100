using System;
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
            #region DisplaySkillAndSavingThrowNames
            acrobatics.DataContext = "Acrobatics";
            animalHandling.DataContext = "AnimalHandling";
            arcana.DataContext = "Arcana";
            athletics.DataContext = "Athletics";
            deception.DataContext = "Deception";
            history.DataContext = "History";
            insight.DataContext = "Insight";
            intimidation.DataContext = "Intimidation";
            investigation.DataContext = "Investigation";
            medicine.DataContext = "Medicine";
            nature.DataContext = "Nature";
            perception.DataContext = "Perception";
            performance.DataContext = "Performance";
            persuassion.DataContext = "Persuassion";
            religion.DataContext = "Religion";
            sleightOfHand.DataContext = "Sleight Of Hand";
            stealth.DataContext = "Stealth";

            strengthSaveMod.DataContext = "Strength";
            dexteritySaveMod.DataContext = "Dexterity";
            constitutionSaveMod.DataContext = "Constitution";
            intelligenceSaveMod.DataContext = "Intelligence";
            wisdomSaveMod.DataContext = "Wisdom";
            charismaSaveMod.DataContext = "Charisma";
            #endregion
        }

        private void CharInfo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CharacterInfo));
        }

        private void SkillsNProficiencies_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int[] modData = (App.Current as App).Character.SnPData.SkillModifiers;
            int i = 0;
            foreach (var mod in skillMods.Children)
            {
                int.TryParse((mod as MainPageSkillsDisplay).Text, out modData[i++]);
            }
            modData = (App.Current as App).Character.SnPData.SavingThrows;
            i = 0;
            foreach (var mod in savingThrowMods.Children)
            {
                int.TryParse((mod as MainPageSkillsDisplay).Text, out modData[i++]);
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
            displayCharacter();
            //#region DisplaySpells
            //Spells.Children.Clear();
            //foreach (Spell spell in (App.Current as App).Character.Spellbook)
            //{
            //    Grid grid = new Grid();
            //    grid.RowDefinitions.Add(new RowDefinition());
            //    grid.RowDefinitions.Add(new RowDefinition());

            //    SolidColorBrush color = new SolidColorBrush();
            //    color.Color = Colors.Black;

            //    TextBlock spellName = new TextBlock();
            //    spellName.Foreground = color;
            //    spellName.FontSize = 32;
            //    spellName.Text = spell.SpellName;
            //    Grid.SetRow(spellName, 0);
            //    grid.Children.Add(spellName);

            //    TextBlock spellDescription = new TextBlock();
            //    spellDescription.Foreground = color;
            //    spellDescription.FontSize = 32;
            //    spellDescription.Text = spell.SpellDescription;
            //    Grid.SetRow(spellDescription, 1);
            //    grid.Children.Add(spellDescription);

            //    SolidColorBrush brush = new SolidColorBrush();
            //    brush.Color = Colors.DarkGray;
            //    grid.BorderBrush = brush;
            //    grid.BorderThickness = new Thickness(3);
            //    grid.CornerRadius = new CornerRadius(8);

            //    Spells.Children.Add(grid);
            //}
            //#endregion

            //#region DisplayFeatures
            //Features.Children.Clear();
            //foreach (Feature feature in (App.Current as App).Character.FeatureList)
            //{
            //    Grid grid = new Grid();
            //    grid.RowDefinitions.Add(new RowDefinition());
            //    grid.RowDefinitions.Add(new RowDefinition());

            //    SolidColorBrush color = new SolidColorBrush();
            //    color.Color = Colors.Black;

            //    TextBlock featureName = new TextBlock();
            //    featureName.Foreground = color;
            //    featureName.FontSize = 32;
            //    featureName.Text = feature.FeatureName;
            //    Grid.SetRow(featureName, 0);
            //    grid.Children.Add(featureName);

            //    TextBlock featureDescription = new TextBlock();
            //    featureDescription.Foreground = color;
            //    featureDescription.FontSize = 32;
            //    featureDescription.Text = feature.FeatureDescription;
            //    Grid.SetRow(featureDescription, 1);
            //    grid.Children.Add(featureDescription);

            //    SolidColorBrush brush = new SolidColorBrush();
            //    brush.Color = Colors.DarkGray;
            //    grid.BorderBrush = brush;
            //    grid.BorderThickness = new Thickness(3);
            //    grid.CornerRadius = new CornerRadius(8);

            //    Features.Children.Add(grid);
            //}
            //#endregion

            //#region DisplayInventory
            //inventory.Children.Clear();
            //if ((App.Current as App).Character.Inventory.Items != null)
            //{
            //    foreach (Item itemObject in (App.Current as App).Character.Inventory.Items)
            //    {

            //        //Create new shape and brush
            //        TextBlock item = new TextBlock();
            //        SolidColorBrush color = new SolidColorBrush();

            //        //Set color
            //        color.Color = Colors.Black;
            //        item.Foreground = color;
            //        item.FontSize = 55;
            //        Grid grid = new Grid();
            //        SolidColorBrush brush = new SolidColorBrush();
            //        brush.Color = Colors.DarkGray;
            //        grid.BorderBrush = brush;
            //        grid.BorderThickness = new Thickness(3);
            //        grid.CornerRadius = new CornerRadius(8);
            //        item.Text = itemObject.Name;
            //        grid.Children.Add(item);
            //        inventory.Children.Add(grid);
            //    }
            //}
            //if ((App.Current as App).Character.Inventory.Money != null)
            //{
            //    int sum = 0;
            //    foreach (int money in (App.Current as App).Character.Inventory.Money)
            //    {
            //        sum += money;
            //    }
            //    moneyVal.Text = sum.ToString();
            //}
            //#endregion

            //#region DisplayProficienciesAndSkills
            //if ((App.Current as App).Character.SnPData.Proficiencies != null)
            //{
            //    foreach (string proficiency in (App.Current as App).Character.SnPData.Proficiencies)
            //    {
            //        TextBlock item = new TextBlock();
            //        SolidColorBrush color = new SolidColorBrush();

            //        //Set color
            //        color.Color = Colors.Black;
            //        item.Foreground = color;
            //        item.FontSize = 44;
            //        Grid grid = new Grid();
            //        SolidColorBrush brush = new SolidColorBrush();
            //        brush.Color = Colors.DarkGray;
            //        grid.BorderBrush = brush;
            //        grid.BorderThickness = new Thickness(3);
            //        grid.CornerRadius = new CornerRadius(8);
            //        item.Text = proficiency;
            //        grid.Children.Add(item);
            //        proficiencies.Children.Add(grid);
            //    }
            //}
            //if ((App.Current as App).Character.SnPData.SkillModifiers != null)
            //{
            //    int[] modData = (App.Current as App).Character.SnPData.SkillModifiers;
            //    int i = 0;
            //    foreach (var mod in skillMods.Children)
            //    {
            //        (mod as SkillsDisplay).Text = modData[i++].ToString();
            //    }
            //}
            //if ((App.Current as App).Character.SnPData.SavingThrows != null)
            //{
            //    int[] modData = (App.Current as App).Character.SnPData.SavingThrows;
            //    int i = 0;
            //    foreach (var mod in savingThrowMods.Children)
            //    {
            //        (mod as SkillsDisplay).Text = modData[i++].ToString();
            //    }
            //}
            //#endregion

            //#region DisplayCharacterInfo
            //charName.Text = (App.Current as App).Character.CharactersInfo.CharacterName;
            //charTitle.Text = (App.Current as App).Character.CharactersInfo.Title;

            //charClass.Text = (App.Current as App).Character.CharactersInfo.CharacterClass;
            //charLevel.Text = (App.Current as App).Character.CharactersInfo.Level.ToString();
            //charBG.Text = (App.Current as App).Character.CharactersInfo.Background[0];
            //charPN.Text = (App.Current as App).Character.CharactersInfo.PlayerName;
            //charRace.Text = (App.Current as App).Character.CharactersInfo.Race;
            //charAlign.Text = (App.Current as App).Character.CharactersInfo.Allignment;
            //charCurrent.Text = (App.Current as App).Character.CharactersInfo.CurrentEXP.ToString();
            //charGoal.Text = (App.Current as App).Character.CharactersInfo.GoalEXP.ToString();

            //charStr.Text = (App.Current as App).Character.CharactersInfo.Stats[0].ToString();
            //if ((App.Current as App).Character.CharactersInfo.StatMods[0] >= 0)
            //{
            //    charStrMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[0].ToString();
            //}
            //else
            //{
            //    charStrMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[0].ToString();
            //}

            //charDex.Text = (App.Current as App).Character.CharactersInfo.Stats[1].ToString();
            //if ((App.Current as App).Character.CharactersInfo.StatMods[1] >= 0)
            //{
            //    charDexMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[1].ToString();
            //}
            //else
            //{
            //    charDexMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[1].ToString();
            //}

            //charCon.Text = (App.Current as App).Character.CharactersInfo.Stats[2].ToString();
            //if ((App.Current as App).Character.CharactersInfo.StatMods[2] >= 0)
            //{
            //    charConMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[2].ToString();
            //}
            //else
            //{
            //    charConMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[2].ToString();
            //}

            //charInt.Text = (App.Current as App).Character.CharactersInfo.Stats[3].ToString();
            //if ((App.Current as App).Character.CharactersInfo.StatMods[3] >= 0)
            //{
            //    charIntMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[3].ToString();
            //}
            //else
            //{
            //    charIntMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[3].ToString();
            //}

            //charWis.Text = (App.Current as App).Character.CharactersInfo.Stats[4].ToString();
            //if ((App.Current as App).Character.CharactersInfo.StatMods[4] >= 0)
            //{
            //    charWisMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[4].ToString();
            //}
            //else
            //{
            //    charWisMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[4].ToString();
            //}

            //charChar.Text = (App.Current as App).Character.CharactersInfo.Stats[5].ToString();
            //if ((App.Current as App).Character.CharactersInfo.StatMods[5] >= 0)
            //{
            //    charCharMod.Text = "+" + (App.Current as App).Character.CharactersInfo.StatMods[5].ToString();
            //}
            //else
            //{
            //    charCharMod.Text = (App.Current as App).Character.CharactersInfo.StatMods[5].ToString();
            //}
            //#endregion

            //#region ActiveStats
            //miniACBlock.Text = (App.Current as App).Character.ActiveStats.ArmorClass.ToString();
            //miniSpeedBlock.Text = (App.Current as App).Character.ActiveStats.Speed.ToString();
            //miniInitBlock.Text = (App.Current as App).Character.ActiveStats.Initiative.ToString();

            //miniMaxHPBlock.Text = (App.Current as App).Character.ActiveStats.MaxHP.ToString();
            //miniCurrentHPBlock.Text = (App.Current as App).Character.ActiveStats.CurrentHP.ToString();
            //miniTempHPBlock.Text = (App.Current as App).Character.ActiveStats.TempHP.ToString();

            //if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 3)
            //{
            //    success1.IsChecked = true;
            //    success2.IsChecked = true;
            //    success3.IsChecked = true;
            //}
            //else if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 2)
            //{
            //    success1.IsChecked = true;
            //    success2.IsChecked = true;
            //}
            //else if ((App.Current as App).Character.ActiveStats.Success_SavingThrows == 1)
            //{
            //    success1.IsChecked = true;
            //}


            //if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 3)
            //{
            //    fail1.IsChecked = true;
            //    fail2.IsChecked = true;
            //    fail3.IsChecked = true;
            //}
            //else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 2)
            //{
            //    fail1.IsChecked = true;
            //    fail2.IsChecked = true;
            //}
            //else if ((App.Current as App).Character.ActiveStats.Failure_SavingThrows == 1)
            //{
            //    fail1.IsChecked = true;
            //}
            //#endregion
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveCharacter(false);
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveCharacter(true);
        }

        private async void SaveCharacter(bool saveAs)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            if ((App.Current as App).File == null || saveAs)
            {
                Windows.Storage.Pickers.FileSavePicker picker = new Windows.Storage.Pickers.FileSavePicker();
                picker.FileTypeChoices.Add("Character File", new List<string> { ".char" });
                (App.Current as App).File = await picker.PickSaveFileAsync();
            }

            if ((App.Current as App).File != null)
            {
                Stream stream = await (App.Current as App).File.OpenStreamForWriteAsync();
                serializer.Serialize(stream, (App.Current as App).Character);
                stream.Close();
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
            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                Stream stream = await file.OpenStreamForReadAsync();
                (App.Current as App).Character = (serializer.Deserialize(stream) as Character);
                stream.Close();
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

            acrobatics.Text = (App.Current as App).Character.SnPData.SkillModifiers[0].ToString();
            animalHandling.Text = (App.Current as App).Character.SnPData.SkillModifiers[1].ToString();
            arcana.Text = (App.Current as App).Character.SnPData.SkillModifiers[2].ToString();
            athletics.Text = (App.Current as App).Character.SnPData.SkillModifiers[3].ToString();
            deception.Text = (App.Current as App).Character.SnPData.SkillModifiers[4].ToString();
            history.Text = (App.Current as App).Character.SnPData.SkillModifiers[5].ToString();
            insight.Text = (App.Current as App).Character.SnPData.SkillModifiers[6].ToString();
            intimidation.Text = (App.Current as App).Character.SnPData.SkillModifiers[7].ToString();
            investigation.Text = (App.Current as App).Character.SnPData.SkillModifiers[8].ToString();
            medicine.Text = (App.Current as App).Character.SnPData.SkillModifiers[9].ToString();
            nature.Text = (App.Current as App).Character.SnPData.SkillModifiers[10].ToString();
            perception.Text = (App.Current as App).Character.SnPData.SkillModifiers[11].ToString();
            performance.Text = (App.Current as App).Character.SnPData.SkillModifiers[12].ToString();
            persuassion.Text = (App.Current as App).Character.SnPData.SkillModifiers[13].ToString();
            religion.Text = (App.Current as App).Character.SnPData.SkillModifiers[14].ToString();
            sleightOfHand.Text = (App.Current as App).Character.SnPData.SkillModifiers[15].ToString();
            stealth.Text = (App.Current as App).Character.SnPData.SkillModifiers[16].ToString();

            proficiencies.Children.Clear();
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

            moneyVal.Text = (App.Current as App).Character.Inventory.Money.Sum().ToString();

            inventory.Children.Clear();
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

            miniACBlock.Text = (App.Current as App).Character.ActiveStats.ArmorClass.ToString();
            miniInitBlock.Text = (App.Current as App).Character.ActiveStats.Initiative.ToString();
            miniSpeedBlock.Text = (App.Current as App).Character.ActiveStats.Speed.ToString();
            miniMaxHPBlock.Text = (App.Current as App).Character.ActiveStats.MaxHP.ToString();
            miniCurrentHPBlock.Text = (App.Current as App).Character.ActiveStats.CurrentHP.ToString();
            miniTempHPBlock.Text = (App.Current as App).Character.ActiveStats.TempHP.ToString();
            switch((App.Current as App).Character.ActiveStats.Success_SavingThrows)
            {
                case 0:
                    success1.IsChecked = false;
                    success2.IsChecked = false;
                    success3.IsChecked = false;
                    break;
                case 1:
                    success1.IsChecked = true;
                    break;
                case 2:
                    success1.IsChecked = true;
                    success2.IsChecked = true;
                    break;
                case 3:
                    success1.IsChecked = true;
                    success2.IsChecked = true;
                    success3.IsChecked = true;
                    break;
            }
            switch ((App.Current as App).Character.ActiveStats.Failure_SavingThrows)
            {
                case 0:
                    fail1.IsChecked = false;
                    fail2.IsChecked = false;
                    fail3.IsChecked = false;
                    break;
                case 1:
                    fail1.IsChecked = true;
                    break;
                case 2:
                    fail1.IsChecked = true;
                    fail2.IsChecked = true;
                    break;
                case 3:
                    fail1.IsChecked = true;
                    fail2.IsChecked = true;
                    fail3.IsChecked = true;
                    break;
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

            (App.Current as App).File = null;
            (App.Current as App).Character = new Character();
            displayCharacter();
        }

        private void NoClicked(object sender, RoutedEventArgs e)
        {
            confirmationPopup.IsOpen = false;
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).Character = new Character();

            bool statModUsed = false;
            Random rng = new Random();
            List<string> races = new List<string>() { "Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" };
            List<string> classes = new List<string>() { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
            RaceMods rm = new RaceMods();


            string race = races.ElementAt(rng.Next(0, races.Count));

            switch (race)
            {

                case "Dwarf":
                    rm.ConMod = 2;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Lawful Neutral";
                    (App.Current as App).Character.ActiveStats.Speed = 25;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Dwarven Resilience", "Advantage on saving throws against poision and have resistance to poising damage."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Stonecunning", "Gain double proficiency on 'History Checks' relating to stonework."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Dwarvish");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Battleaxe");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Handaxe");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Throwing Hammer");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Warhammer");

                    string[] toolProfs = { "Smith's Tools", "Brewer's Supplies", "Mason's Tools" };
                    (App.Current as App).Character.SnPData.Proficiencies.Add(toolProfs[rng.Next(0,3)]);

                    break;
                case "Elf":
                    rm.DexMod = 2;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Chaotic Good";
                    (App.Current as App).Character.ActiveStats.Speed = 30;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Fey Ancestry", "Advantage on saving throws against being charmed. Cannot be put to sleep by magical means."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Trance", "You do not need sleep, but instead must meditate in a semiconscious state for 4 hours to feel rested."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Elvish");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Proficient in the skill: Perception");

                    break;
                case "Halfling":
                    rm.DexMod = 2;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Lawful Good";
                    (App.Current as App).Character.ActiveStats.Speed = 25;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Lucky", "When you roll a 1, you can reroll the die, but you must take the new number."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Brave", "Advantage on saving throws against being frightened."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Halfling Numbleness", "You may move through the space of a creature that is of a size larger than yours."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Halfling");

                    break;
                case "Human":
                    rm.StrMod = 1;
                    rm.DexMod = 1;
                    rm.ConMod = 1;
                    rm.IntMod = 1;
                    rm.WisMod = 1;
                    rm.ChaMod = 1;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Neutral";
                    (App.Current as App).Character.ActiveStats.Speed = 30;
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak {Language of Choice}");

                    break;
                case "Dragonborn":
                    rm.StrMod = 2;
                    rm.ChaMod = 1;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Neutral";
                    (App.Current as App).Character.ActiveStats.Speed = 30;

                    List<string> dragonTypes = new List<string>() { "Black ", "Blue ", "Brass ", "Bronze ", "Copper ", "Gold ", "Green ", "Red ", "Silver ", "White "};
                    string type = dragonTypes.ElementAt(rng.Next(0, dragonTypes.Count));
                    (App.Current as App).Character.CharactersInfo.Race = type + race;

                    switch (type.Trim())
                    {
                        case "Black":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Acid Breath", "5x30ft line of acid damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Acid Damage"));
                            break;
                        case "Blue":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Lightning Breath", "5x30ft line of lightning damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Lightning Damage"));
                            break;
                        case "Brass":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Fire Breath", "5x30ft line of fire damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Fire Damage"));
                            break;
                        case "Bronze":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Lightning Breath", "5x30ft line of lightning damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Lightning Damage"));
                            break;
                        case "Copper":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Acid Breath", "5x30ft line of acid damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Acid Damage"));
                            break;
                        case "Gold":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Fire Breath", "15ft cone of fire damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Fire Damage"));
                            break;
                        case "Green":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Poison Breath", "15ft cone of poison damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Poison Damage"));
                            break;
                        case "Red":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Fire Breath", "15ft cone of fire damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Fire Damage"));
                            break;
                        case "Silver":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Cold Breath", "15ft cone of cold damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Cold Damage"));
                            break;
                        case "White":
                            (App.Current as App).Character.Spellbook.Add(new Spell("Cold Breath", "15ft cone of cold damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16."));
                            (App.Current as App).Character.FeatureList.Add(new Feature("Draconic Resistance", "Resistant to: Cold Damage"));
                            break;
                    }
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Draconic");

                    break;
                case "Gnome":
                    rm.IntMod = 2;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Neutral Good";
                    (App.Current as App).Character.ActiveStats.Speed = 25;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Gnome Cunning", "Advantage on all: Intelligence, Wisdom, and Charisma checks against magic."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Gnomish");

                    break;
                case "Half-Elf":
                    rm.ChaMod = 2;
                    int rand1 = rng.Next(0, 5);
                    switch (rand1)
                    {
                        case 0:
                            rm.StrMod = 1;

                            do
                            {
                                int rand2 = rng.Next(0, 5);
                                if (rand2 == rand1)
                                {
                                    statModUsed = true;
                                }
                                else
                                {
                                    switch (rand2)
                                    {
                                        case 0:
                                            rm.StrMod = 1;
                                            break;
                                        case 1:
                                            rm.DexMod = 1;
                                            break;
                                        case 2:
                                            rm.ConMod = 1;
                                            break;
                                        case 3:
                                            rm.IntMod = 1;
                                            break;
                                        case 4:
                                            rm.WisMod = 1;
                                            break;
                                    }
                                    statModUsed = false;
                                }

                            } while (statModUsed);
                            break;
                        case 1:
                            rm.DexMod = 1;

                            do
                            {
                                int rand2 = rng.Next(0, 5);
                                if (rand2 == rand1)
                                {
                                    statModUsed = true;
                                }
                                else
                                {
                                    switch (rand2)
                                    {
                                        case 0:
                                            rm.StrMod = 1;
                                            break;
                                        case 1:
                                            rm.DexMod = 1;
                                            break;
                                        case 2:
                                            rm.ConMod = 1;
                                            break;
                                        case 3:
                                            rm.IntMod = 1;
                                            break;
                                        case 4:
                                            rm.WisMod = 1;
                                            break;
                                    }
                                    statModUsed = false;
                                }

                            } while (statModUsed);
                            break;
                        case 2:
                            rm.ConMod = 1;

                            do
                            {
                                int rand2 = rng.Next(0, 5);
                                if (rand2 == rand1)
                                {
                                    statModUsed = true;
                                }
                                else
                                {
                                    switch (rand2)
                                    {
                                        case 0:
                                            rm.StrMod = 1;
                                            break;
                                        case 1:
                                            rm.DexMod = 1;
                                            break;
                                        case 2:
                                            rm.ConMod = 1;
                                            break;
                                        case 3:
                                            rm.IntMod = 1;
                                            break;
                                        case 4:
                                            rm.WisMod = 1;
                                            break;
                                    }
                                    statModUsed = false;
                                }

                            } while (statModUsed);
                            break;
                        case 3:
                            rm.IntMod = 1;

                            do
                            {
                                int rand2 = rng.Next(0, 5);
                                if (rand2 == rand1)
                                {
                                    statModUsed = true;
                                }
                                else
                                {
                                    switch (rand2)
                                    {
                                        case 0:
                                            rm.StrMod = 1;
                                            break;
                                        case 1:
                                            rm.DexMod = 1;
                                            break;
                                        case 2:
                                            rm.ConMod = 1;
                                            break;
                                        case 3:
                                            rm.IntMod = 1;
                                            break;
                                        case 4:
                                            rm.WisMod = 1;
                                            break;
                                    }
                                    statModUsed = false;
                                }

                            } while (statModUsed);
                            break;
                        case 4:
                            rm.WisMod = 1;

                            do
                            {
                                int rand2 = rng.Next(0, 5);
                                if (rand2 == rand1)
                                {
                                    statModUsed = true;
                                }
                                else
                                {
                                    switch (rand2)
                                    {
                                        case 0:
                                            rm.StrMod = 1;
                                            break;
                                        case 1:
                                            rm.DexMod = 1;
                                            break;
                                        case 2:
                                            rm.ConMod = 1;
                                            break;
                                        case 3:
                                            rm.IntMod = 1;
                                            break;
                                        case 4:
                                            rm.WisMod = 1;
                                            break;
                                    }
                                    statModUsed = false;
                                }

                            } while (statModUsed);
                            break;
                    }
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Chaotic Neutral";
                    (App.Current as App).Character.ActiveStats.Speed = 30;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Fey Ancestry", "Advantage on saving throws against being charmed. Cannot be put to sleep by magical means."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Elvish");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak {Language of Choice}");

                    List<string> skills = new List<string>() { "Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Performance", "Persuasion", "Religion", "Sleight of Hand", "Stealh", "Survival" };
                    bool alreadyChosen = false;
                    string skill1 = skills.ElementAt(rng.Next(0, skills.Count));
                    string skill2 = "";
                    do
                    {
                        skill2 = skills.ElementAt(rng.Next(0, skills.Count));
                        if (skill1 == skill2)
                        {
                            alreadyChosen = true;
                        }
                        else
                        {
                            alreadyChosen = false;
                        }
                    } while (alreadyChosen);

                    (App.Current as App).Character.SnPData.Proficiencies.Add("Proficient in the skill: " + skill1);
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Proficient in the skill: " + skill2);

                    break;
                case "Half-Orc":
                    rm.StrMod = 2;
                    rm.ConMod = 1;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Chaotic Evil";
                    (App.Current as App).Character.ActiveStats.Speed = 30;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Relentless Endurance", "When you are reduced to 0 health, it is instead reduced to 1 health. Can only use this feature 1/Long Rest."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Savage Attacks", "When you score a critical hit you can add 1 of the weapons damage dice one time to the critical damage."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Orc");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Proficient in the skill: Intimidation");

                    break;
                case "Tiefling":
                    rm.IntMod = 1;
                    rm.ChaMod = 2;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Chaotic Neutral";
                    (App.Current as App).Character.ActiveStats.Speed = 30;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Hellish Resistance", "Resistance to: Fire Damage"));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Infernal Legacy", "You know the cantrip: Thaumaturgy. At level 3 you learn: Hellish Rebuke; and can use it 1/Long Rest as a 2nd level spell. At level 5 you learn: Darkness; and can use it 1/Long Rest. Charisma is the spellcasting ability for these."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Infernal");
                    (App.Current as App).Character.Spellbook.Add(new Spell("Thaumaturgy", "Range: 30ft. Duration: Up to 1 minute. Casting Time: 1 Action. You can: Create harmless sensory effects."));

                    break;
            }

            for(int i = 0; i < (App.Current as App).Character.CharactersInfo.Stats.Length; i++)
            {
                int rand1 = rng.Next(1, 7);
                int rand2 = rng.Next(1, 7);
                int rand3 = rng.Next(1, 7);

                int statSum = rand1 + rand2 + rand3;
                switch (i)
                {
                    case 0:
                        statSum += rm.StrMod;
                        break;
                    case 1:
                        statSum += rm.DexMod;
                        break;
                    case 2:
                        statSum += rm.ConMod;
                        break;
                    case 3:
                        statSum += rm.IntMod;
                        break;
                    case 4:
                        statSum += rm.WisMod;
                        break;
                    case 5:
                        statSum += rm.ChaMod;
                        break;
                }

                (App.Current as App).Character.CharactersInfo.Stats[i] = statSum;
                int statMod = ((statSum - 10) / 2);
                (App.Current as App).Character.CharactersInfo.StatMods[i] = statMod;

            }

            string charClass = classes.ElementAt(rng.Next(0, classes.Count));
            switch (charClass)
            {
                case "Barbarian":
                    (App.Current as App).Character.CharactersInfo.CharacterClass = charClass;
                    (App.Current as App).Character.ActiveStats.MaxHP = 12 + (App.Current as App).Character.CharactersInfo.StatMods[2];
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Light Armor");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Medium Armor");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Shields");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Simple Weapons");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Martial Weapons");
                    //PROFICIENT IN STRENGTH AND CONST
                    //SKILLS CHOOSE 2 FROM (ANIMAL HANDLING | ATHLETICS | INTIMIDATION | NATURE | PERCEPTION | SURVIVAL)

                    (App.Current as App).Character.Inventory.Items.Add(new Item("Choose between: A Greataxe OR Any Martial Melee Weapon"));
                    (App.Current as App).Character.Inventory.Items.Add(new Item("Choose between: 2 Handaxes OR Any Simple Weapon"));
                    (App.Current as App).Character.Inventory.Items.Add(new Item("Explorers Pack"));
                    (App.Current as App).Character.Inventory.Items.Add(new Item("4 Javelins"));

                    (App.Current as App).Character.FeatureList.Add(new Feature("Rage", "In battle you can rage as a bonus action. During rage if you " +
                        "are not wearing heavy armor you gain the following benefits: You have advantage on Strength Checks and Strength Saving throws. " +
                        "When you hit an enemy you gain 2 bonus rage damage (Increases by 1 at level 9 and 16). You gain resistance to bludgeoning, piercing, and slashing damage. " +
                        "You cannot cast spells while in rage. It lasts for 1 minute. You can rage 2 times per long rest (Increases at level 3, 6, 12 and 17; then unlimited at level 20)"));

                    break;
                case "Bard":

                    break;
                case "Cleric":

                    break;
                case "Druid":

                    break;
                case "Fighter":

                    break;
                case "Monk":

                    break;
                case "Paladin":

                    break;
                case "Ranger":

                    break;
                case "Rogue":

                    break;
                case "Sorcerer":

                    break;
                case "Warlock":

                    break;
                case "Wizard":

                    break;
            }

            displayCharacter();
        }
    }
}

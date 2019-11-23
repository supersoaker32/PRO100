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
                int.TryParse((mod as MainPageSkillsDisplay).Text, out tmpVal);
                modData[i++].Modifier = tmpVal;
            }
            modData = (App.Current as App).Character.SnPData.SavingThrows;
            i = 0;
            foreach (var mod in savingThrowMods.Children)
            {
                int tmpVal;
                int.TryParse((mod as MainPageSkillsDisplay).Text, out tmpVal);
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
            displayCharacter();
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

            int i = 0;
            foreach(MainPageSkillsDisplay skill in skillMods.Children)
            {
                skill.DataContext = (App.Current as App).Character.SnPData.SkillModifiers[i];
                skill.Text = (App.Current as App).Character.SnPData.SkillModifiers[i].Modifier.ToString();
                skill.CheckBox = (App.Current as App).Character.SnPData.SkillModifiers[i].Proficient;
                i++;
                //skill.CheckBox = (App.Current as App).Character.SnPData.
            }
            i = 0;
            foreach(MainPageSkillsDisplay savingThrow in savingThrowMods.Children)
            {
                savingThrow.DataContext = (App.Current as App).Character.SnPData.SavingThrows[i];
                savingThrow.Text = (App.Current as App).Character.SnPData.SavingThrows[i].Modifier.ToString();
                savingThrow.CheckBox = (App.Current as App).Character.SnPData.SavingThrows[i].Proficient;
                i++;
            }

            proficiencies.Children.Clear();
            foreach (string proficiency in (App.Current as App).Character.SnPData.Proficiencies)
            {
                TextBlock item = new TextBlock();
                SolidColorBrush color = new SolidColorBrush();

                //Set color
                color.Color = Colors.Black;
                item.Foreground = color;
                item.FontSize = 25;
                Grid grid = new Grid();
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);
                item.Text = proficiency;
                grid.Children.Add(item);
                proficiencies.Children.Add(grid);
                item.TextWrapping = TextWrapping.Wrap;
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
                spellName.FontSize = 25;
                spellName.Text = spell.SpellName;
                spellName.TextWrapping = TextWrapping.Wrap;
                Grid.SetRow(spellName, 0);
                grid.Children.Add(spellName);

                TextBlock spellDescription = new TextBlock();
                spellDescription.Foreground = color;
                spellDescription.FontSize = 25;
                spellDescription.Text = spell.SpellDescription;
                spellDescription.TextWrapping = TextWrapping.Wrap;
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
                featureName.FontSize = 25;
                featureName.Text = feature.FeatureName;
                featureName.TextWrapping = TextWrapping.Wrap;
                Grid.SetRow(featureName, 0);
                grid.Children.Add(featureName);

                TextBlock featureDescription = new TextBlock();
                featureDescription.Foreground = color;
                featureDescription.FontSize = 25;
                featureDescription.Text = feature.FeatureDescription;
                featureDescription.TextWrapping = TextWrapping.Wrap;
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
                item.FontSize = 25;
                Grid grid = new Grid();
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.DarkGray;
                grid.BorderBrush = brush;
                grid.BorderThickness = new Thickness(3);
                grid.CornerRadius = new CornerRadius(8);
                item.Text = itemObject.Name;
                item.TextWrapping = TextWrapping.Wrap;
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
                    {
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
                    }

                    break;
                case "Elf":
                    {
                    rm.DexMod = 2;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Chaotic Good";
                    (App.Current as App).Character.ActiveStats.Speed = 30;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Fey Ancestry", "Advantage on saving throws against being charmed. Cannot be put to sleep by magical means."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Trance", "You do not need sleep, but instead must meditate in a semiconscious state for 4 hours to feel rested."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Elvish");
                    (App.Current as App).Character.SnPData.SkillModifiers[11].Proficient = true;
                    }

                    break;
                case "Halfling":
                    {

                    rm.DexMod = 2;
                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Lawful Good";
                    (App.Current as App).Character.ActiveStats.Speed = 25;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Lucky", "When you roll a 1, you can reroll the die, but you must take the new number."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Brave", "Advantage on saving throws against being frightened."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Halfling Numbleness", "You may move through the space of a creature that is of a size larger than yours."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Halfling");
                    }

                    break;
                case "Human":
                    {

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
                    }

                    break;
                case "Dragonborn":
                    {

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
                    }

                    break;
                case "Gnome":
                    rm.IntMod = 2;
                    {

                    (App.Current as App).Character.CharactersInfo.Race = race;
                    (App.Current as App).Character.CharactersInfo.Allignment = "Neutral Good";
                    (App.Current as App).Character.ActiveStats.Speed = 25;
                    (App.Current as App).Character.FeatureList.Add(new Feature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey."));
                    (App.Current as App).Character.FeatureList.Add(new Feature("Gnome Cunning", "Advantage on all: Intelligence, Wisdom, and Charisma checks against magic."));
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Common");
                    (App.Current as App).Character.SnPData.Proficiencies.Add("Read/Write and Speak Gnomish");
                    }

                    break;
                case "Half-Elf":
                    {

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
                    (App.Current as App).Character.SnPData.SkillModifiers[rng.Next(0, skills.Count)].Proficient = true;
                    do
                    {
                        int i = rng.Next(0, skills.Count);
                        if ((App.Current as App).Character.SnPData.SkillModifiers[i].Proficient == true)
                        {
                            alreadyChosen = true;
                        }
                        else
                        {
                            (App.Current as App).Character.SnPData.SkillModifiers[i].Proficient = true;
                            alreadyChosen = false;
                        }
                    } while (alreadyChosen);

                    }

                    break;
                case "Half-Orc":
                    {

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
                    (App.Current as App).Character.SnPData.SkillModifiers[7].Proficient = true;
                    }

                    break;
                case "Tiefling":
                    {

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
                    }

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
                    {
                        addClassData(charClass, 12, new List<string> { "Light Armor", "Medium Armor", "Shields" }, new List<string> { "Simple Weapons", "Martial Weapons"}, null, new int[] { 0, 2 }, new int[] { 1, 3, 7, 10, 11, 17 }, 2, 
                                     new List<string> { "Choose between: A Greataxe OR Any Martial Melee Weapon" , "Choose between: 2 Handaxes OR Any Simple Weapon", "Explorers Pack" , "4 Javelins" }, 10 + (App.Current as App).Character.CharactersInfo.StatMods[1] 
                                    + (App.Current as App).Character.CharactersInfo.StatMods[2], 0, 0, new List<string> { "Rage", "Unarmored Defense"}, new List<string> { "In battle you can rage as a bonus action. During rage if you are not wearing heavy armor you gain the following benefits: You have advantage on Strength Checks and Strength Saving throws. " +
                                    "When you hit an enemy you gain 2 bonus rage damage (Increases by 1 at level 9 and 16). You gain resistance to bludgeoning, piercing, and slashing damage. You cannot cast spells while in rage." +
                                    " It lasts for 1 minute. You can rage 2 times per long rest (Increases at level 3, 6, 12 and 17; then unlimited at level 20)", "Your armor class is: 10 + Dexterity Modifier + Constitution Modifier. " +
                                    "You may use a shield and still gain this benefit."});
                    }

                    break;
                case "Bard":
                    {
                    addClassData(charClass, 8, new List<string> { "Light Armor" }, new List<string> { "Simple Weapons", "Hand Crossbows", "LongSwords", "Rapiers", "Shortswords" }, new List<string> { "Three Musical Instruments of Your Choice" },
                                 new int[] { 1,5 }, new int[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17 }, 3, new List<string> { "Choose between: A Rapier, A Longsword, OR Any Simple Weapon", "Choose between: A Diplomat's Pack OR An Entertainer's Pack",
                                 "Choose between: A Lute OR Any Other Musical Instrument", "Leather Armor", "Dagger" }, 11 + (App.Current as App).Character.CharactersInfo.StatMods[1], 2, 4, new List<string> { "Bardic Inspiration" },
                                 new List<string> { "You can inspire others through stirring words or with music. You can use a bonus action to inspire one creature within 60 feet that can hear you. It gains 1D6 inspiration. " +
                                 "(Increases to 1D8 at Level 5, 1D10 at Level 10, and 1D12 at Level 15.)" });

                        (App.Current as App).Character.SpellMod = 10 + (App.Current as App).Character.CharactersInfo.StatMods[5];
                        (App.Current as App).Character.SpellSave = 2 + (App.Current as App).Character.CharactersInfo.StatMods[5];
                        (App.Current as App).Character.SpellSlots = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Cleric":
                    {
                        addClassData(charClass, 8, new List<string> { "Light Armor", "Medium Armor", "Shields" }, new List<string> { "Simple Weapons"}, null, new int[] { 4,5 }, new int[] { 5,6,9,13,14 }, 5, new List<string> { "Choose between: A Mace OR A Warhammer (if proficient)",
                                     "Choose between: A Light Crossbow (with 20 bolts) OR Any Simple Weapon", "Choose between: A Priest's Pack OR An Explorer's Pack", "Choose between: Scale Mail, Leather Armor, OR Chain Mail (if proficient) -- SET OWN AC",
                                     "Shield", "Holy Symbole of Your Choice"}, 0, (App.Current as App).Character.CharactersInfo.StatMods[4] + (App.Current as App).Character.CharactersInfo.Level, 3, new List<string> { "Divine Domain" }, 
                                     new List<string> { "Choose a Domain that is related to your Diety: Knowledge, Life, Light, Nature, Tempest, Trickery, or War. You gain spells according. READ PERSONALLY!" });

                        (App.Current as App).Character.SpellMod = 10 + (App.Current as App).Character.CharactersInfo.StatMods[5];
                        (App.Current as App).Character.SpellSave = 2 + (App.Current as App).Character.CharactersInfo.StatMods[5];
                        (App.Current as App).Character.SpellSlots = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }
                    
                    break;
                case "Druid":
                    {
                        addClassData(charClass, 8, new List<string> { "NONMETAL Light Armor", "NONMETAL Medium Armor", "NONMETAL Shields"}, new List<string> { "Clubs","Daggers","Darts","Javelins","Maces","Quarterstaffs","Scimitars","Sickles","Slings","Spears" }, 
                                     new List<string> { "Herbalism Kit" }, new int[] { 3,4 }, new int[] { 1,2,6,9,10,11,14,17 }, 2, new List<string> { "Choose between: A Wooden Shield OR Any Simple Weapon", "Choose between: A Scimitar OR Any Simple Melee Weapon", 
                                     "Leather Armor","Explorers Pack","Druidic Focus"}, 11 + (App.Current as App).Character.CharactersInfo.StatMods[1], (App.Current as App).Character.CharactersInfo.StatMods[4] + (App.Current as App).Character.CharactersInfo.Level,
                                     2, new List<string> { "Druidic" }, new List<string> { "You know Druidic, the secret language of the druids. You can speak the language and use it to leave behind hidden messages. Anyone who knows the language can see it. " +
                                     "If someone doesnt know the language they must make a DC15 Perception check to see it. It cannot be deciphered without the use of magic." });
                        
                        (App.Current as App).Character.SpellMod = 10 + (App.Current as App).Character.CharactersInfo.StatMods[4];
                        (App.Current as App).Character.SpellSave = 2 + (App.Current as App).Character.CharactersInfo.StatMods[4];
                        (App.Current as App).Character.SpellSlots = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Fighter":
                    {
                        addClassData(charClass, 10, new List<string> { "All Armor","Shields"}, new List<string> { "Simple Weapons","Martial Weapons" }, null, new int[] { 0,2 }, new int[] { 0,1,3,5,6,7,11,17 }, 2, 
                            new List<string> { "Choose between: Chain Mail OR Leather Armor With a Longbow and 20 Arrows -- SET OWN AC", "Choose between: A Martial Weapon With a Shield OR 2 Martial Weapons", "Choose between: A Light Crossbow With 20 Bolts OR 2 Handaxes",
                            "Choose between: A Dungeoneer's Pack OR An Explorer's Pack"}, 0, 0, 0, new List<string> { "Fighting Style", "Second Wind" }, new List<string> { "Choose one Fighting Style between the following Fighting Styles: Archery - Gain +2 to Attack Rolls Made With " +
                            "Ranged Weapons, Defense - While You Are Wearing Armor You Gain +1 Bonus to AC, Dueling - While Wielding a Melee Weapon In One Hand and No Other Weapons You Gain +2 Bonus Damage With That Weapon, Great Weapon Fighting - When You Roll a 1 or 2 " +
                            "on a Damage Die For an Attack You Make With a Two Handed Weapon You May Reroll the Damage Die, But Must Take the New Roll, Protection - While Wielding a Shield; if a Creature Attacks Another Creature Within 5FT of You as a Reaction " +
                            "You Can Impose Disadvantage on The Attack Roll, Two-Weapon Fighting - When You Engage in Two Weapon Fighting You May Add Your Ability Modifier To The Second Attack.", "1/Rest You May Use a Bonus Action To Heal 1D10 + Fighter Level." });

                    }

                    break;
                case "Monk":
                    {
                        addClassData(charClass, 8, null, new List<string> {"Simple Weapons","Shortswords"  }, new List<string> {"Choose between: A Type of Artisans Tools OR A Musical Instrument"}, new int[] { 0,1}, new int[] { 0,3,5,6,14,16 }, 2,
                                     new List<string> { "Choose between: A Shortsword OR Any Simple Weapon","Choose between: A Dungeoneer's Pack OR An Explorer's Pack","10 Darts"}, 10 + (App.Current as App).Character.CharactersInfo.StatMods[1] + (App.Current as App).Character.CharactersInfo.StatMods[4],
                                     0, 0, new List<string> { "Unarmored Defense","Martial Arts"}, new List<string> { "While Not Wearing Armor Your AC Is: 10 + Dexterity Mod + Wisdom Mod","While Unarmed or Weidling Monk Weapons And Not Wearing Armor Or Wielding a Shield You Gain The Following Benefits: " +
                                     "You Can Use Dexterity Instead of Strength For Attack and Damage Rolls, You Can Roll 1D4 In Place of The Weapons Base Damage Die (Increases to 1D6 at Level 5, 1D8 at Level 11, and 1D10 at Level 17), You Can Make on Unarmed Strike for your Bonus Action After Attacking."});

                    }

                    break;
                case "Paladin":
                    {
                        addClassData(charClass, 10, new List<string> { "All Armors", "Shields" }, new List<string> {"Simple Weapons","Martial Weapons" }, null, new int[] { 4,5 }, new int[] { 3,6,7,9,13,14 }, 2, new List<string> { "Choose between: A Martial Weapon With a Shield OR 2 Martial Weapons",
                                     "Choose between: 5 Javelins OR Any Simple Melee Weapon", "Choose between: A Priest's Pack OR An Explorer's Pack", "Chain Mail", "Holy Symbol of Your Choice"}, 16, 0, 0, new List<string> { "Divine Sense", "Lay on Hands"}, 
                                     new List<string> { "The Presence of Strong Evil Registers on Your Senses Like a Noxious Odor and Powerful Good Rings Like Heavenly Music in Your Ears. As an Action You Can Detect Any Celestials Fiends or Undead Within 60FT, You Can Do This 1 + Charisma Modifier Times / Long Rest",
                                     "You Have a Pool of Health Equal To The Paladins Level x 5 That Restores With Each Long Rest, You can Give Health to any creature (aside from undead and constructs). Alternatively you can use 5 Health from the Pool to Cure a Target of a Disease or Poison."});
                    }

                    break;
                case "Ranger":
                    {
                        addClassData(charClass, 10, new List<string> { "Light Armor","Medium Armor","Shields"}, new List<string> { "Simple Weapons", "Martial Weapons" }, null, new int[] { 0,1 }, new int[] { 1,3,6,8,10,11,16,17 }, 3, 
                                     new List<string> { "Choose between: Scale Mail OR Leather Armor -- SET OWN AC", "Choose between: 2 Shortswords OR 2 Simple Melee Weapons", "Choose between: A Dungeoneer's Pack OR An Explorer's Pack", "Longbow With 20 Arrows"},
                                     0, 0, 0, new List<string> { "Favored Enemy", "Natural Explorer"}, new List<string> { "Choose a type of favored enemy from: Abberations, Beasts, Celestials, Constructs, Dragons, Elementals, Fey, Fiends, Giants, Monstrosities, Oozes, Plants, or Undead." +
                                     " OR choose 2 Humanoid Races. You learn the languages, how to track, and hunt these Enemies. You have advantage on Survival Checks to track the enemy and Intelligence checks to recall information about them. (Gain another favored enemy (Or 2 humanoid races) at Level 6 and Level 14.) ",
                                     "Choose a favored Terrain from: Arctic, Coast, Desert, Forest, Grassland, Mountain, Swamp, or the Underdark. In this terrain you gain the following benefits: Your party is not slowed by difficult terrain, Your party cannot become lost unless by use of magic," +
                                     " You remain alert even while performing other actions, While traveling alone you move at normal speed while stealthing, You find twice as much food while foraging, and, while tracking creatures you learn their numbers, sizes, and how long ago it has been since they passed through the area. (Gain another Favored Terrain at Level 6 and Level 10.)" });
                    }

                    break;
                case "Rogue":
                    {
                        addClassData(charClass, 8, new List<string> { "Light Armor" }, new List<string> {"Simple Weapons","Hand Crossbows","Longswords","Rapiers","Shortswords" }, new List<string> {"Thieves' Tools" }, new int[] { 1,3 },
                                     new int[] { 0,3,4,6,7,8,11,12,13,15,16 }, 4, new List<string> { "Choose between: A Rapier OR A Shortsword", "Choose between: A Shortbow with 20 Arrows OR A Shortsword", "Choose between: A Burglar's Pack, An Explorer's Pack, OR A Dungeoneer's Pack", 
                                     "Leather Armor", "2 Daggers", "Thieves' Tools"}, 11 + (App.Current as App).Character.CharactersInfo.StatMods[1], 0, 0, new List<string> { "Expertise", "Sneak Attack", "Thieves' Cant"}, new List<string> { "Choose 2 of " +
                                     "your skill proficiencies (or 1 skill proficiency and proficiency with thieves' tools). Your proficiency is doubled with those proficiencies. You can choose 2 more at level 6.","Once per turn you can deal an extra 1D6 damage with an attack if you have advantage " +
                                     "on the attack, you do not need advantage if another enemy of the target is within 5 feet of it, that enemy isnt incapacitated, and you don't have disadvantage on the attack roll. (Increases to 2D6 at level 3, 3D6 " +
                                     "at level 5, 4D6 at level 7, 5D6 at level 9, 6D6 at level 11, 7D6 at level 13, 8D6 at level 15, 9D6 at level 17, 10D6 at level 19.)","A secret language known by rogues, used to hide messages in normal conversation, " +
                                     "however it takes 4 times longer to do this than it does to say it plainly. You can also understand secret signs and symbols used to convey short simple messages such as whether an area is dangerous or part of a thieves guild etc..."});
                    }

                    break;
                case "Sorcerer":
                    {
                        addClassData(charClass, 6, null, new List<string> { "Daggers","Darts","Slings","Quarterstaffs","Light Crossbows"}, null, new int[] { 2,5 }, new int[] { 2,4,6,7,13,14 }, 2, new List<string> { "Choose between: A Light Crossbow " +
                            "With 20 Bolts OR Any Simple Weapon", "Choose between: A Component Pouch OR An Arcane Focus", "Choose between: A Dungeoneer's Pack OR An Explorer's Pack", "2 Daggers" }, 10 + (App.Current as App).Character.CharactersInfo.StatMods[1], 2, 4, new List<string> { "Sorcerous Origin" }, new List<string> { "Choose a sorcerous origin from the book (SUBCLASS) -- DO YOURSELF" });

                        (App.Current as App).Character.SpellMod = 10 + (App.Current as App).Character.CharactersInfo.StatMods[5];
                        (App.Current as App).Character.SpellSave = 2 + (App.Current as App).Character.CharactersInfo.StatMods[5];
                        (App.Current as App).Character.SpellSlots = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Warlock":
                    {
                        addClassData(charClass, 8, new List<string> { "Light Armor" }, new List<string> { "Simple Weapons" }, null, new int[] { 4,5 }, new int[] { 2,4,5,7,8,10,14 }, 2, new List<string> { "Choose between: A Light Crossbow With 20 Bolts OR " +
                            "Any Simple Weapon", "Choose between: A Component Pouch OR An Arcane Focus", "Choose between: A Scholar's Pack OR A Dungeoneer's Pack", "Leather Armor", "Any Simple Weapon", "2 Daggers" }, 11 + (App.Current as App).Character.CharactersInfo.StatMods[1],
                            2, 2, new List<string> { "Otherworldly Patron" }, new List<string> { "Choose an otherworldly patron from the book (SUBCLASS)-- DO YOURSELF" });

                        (App.Current as App).Character.SpellMod = 10 + (App.Current as App).Character.CharactersInfo.StatMods[5];
                        (App.Current as App).Character.SpellSave = 2 + (App.Current as App).Character.CharactersInfo.StatMods[5];
                        (App.Current as App).Character.SpellSlots = new int[9] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Wizard"://FEATUREDESCS   -- CHOICE EQUIPMENT -- Choose between: A {Name} OR {A Name}
                    {
                        addClassData(charClass, 6, null, new List<string> { "Daggers","Darts","Slings","Quarterstaffs","Light Crossbows"}, null, new int[] { 3,4 }, new int[] { 2,5,6,8,9,14 }, 2, new List<string> { "Choose between: A Quarterstaff OR A Dagger",
                                     "Choose between: A Component Pouch OR An Arcane Focus", "Choose between: A Scholar's Pack or An Explorer's Pack", "Spellbook"}, 10 + (App.Current as App).Character.CharactersInfo.StatMods[1], 0, 3, new List<string> { "Arcane Recovery" },
                                     new List<string> { "Once/Day you can choose expended spell slots to recover. The spell slots can have a combined level <= half your wizard level rounded up." });

                        (App.Current as App).Character.SpellMod = 10 + (App.Current as App).Character.CharactersInfo.StatMods[3];
                        (App.Current as App).Character.SpellSave = 2 + (App.Current as App).Character.CharactersInfo.StatMods[3];
                        (App.Current as App).Character.SpellSlots = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
            }

            displayCharacter();
        }
        
        private void addClassData(string className, int hitDie, List<string> armorProfs, List<string> weaponProfs, List<string> toolProfs, int[] savingProfs, int[] skillProfs, int skillCount, 
                                  List<string> equipment, int AC, int spellsKnown, int cantripsKnown, List<string> featureNames, List<string> featureDescs )
        {
            Random rng = new Random();

            (App.Current as App).Character.SnPData.SavingThrows[0].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[0];
            (App.Current as App).Character.SnPData.SavingThrows[1].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[1];
            (App.Current as App).Character.SnPData.SavingThrows[2].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[2];
            (App.Current as App).Character.SnPData.SavingThrows[3].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[3];
            (App.Current as App).Character.SnPData.SavingThrows[4].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[4];
            (App.Current as App).Character.SnPData.SavingThrows[5].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[5];

            (App.Current as App).Character.SnPData.SkillModifiers[0].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[1];
            (App.Current as App).Character.SnPData.SkillModifiers[1].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[4];
            (App.Current as App).Character.SnPData.SkillModifiers[2].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[3];
            (App.Current as App).Character.SnPData.SkillModifiers[3].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[0];
            (App.Current as App).Character.SnPData.SkillModifiers[4].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[5];
            (App.Current as App).Character.SnPData.SkillModifiers[5].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[3];
            (App.Current as App).Character.SnPData.SkillModifiers[6].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[4];
            (App.Current as App).Character.SnPData.SkillModifiers[7].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[5];
            (App.Current as App).Character.SnPData.SkillModifiers[8].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[3];
            (App.Current as App).Character.SnPData.SkillModifiers[9].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[4];
            (App.Current as App).Character.SnPData.SkillModifiers[10].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[3];
            (App.Current as App).Character.SnPData.SkillModifiers[11].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[4];
            (App.Current as App).Character.SnPData.SkillModifiers[12].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[5];
            (App.Current as App).Character.SnPData.SkillModifiers[13].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[5];
            (App.Current as App).Character.SnPData.SkillModifiers[14].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[3];
            (App.Current as App).Character.SnPData.SkillModifiers[15].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[1];
            (App.Current as App).Character.SnPData.SkillModifiers[16].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[1];
            (App.Current as App).Character.SnPData.SkillModifiers[17].Modifier = (App.Current as App).Character.CharactersInfo.StatMods[4];

            (App.Current as App).Character.CharactersInfo.CharacterClass = className;
            (App.Current as App).Character.ActiveStats.MaxHP = hitDie + (App.Current as App).Character.CharactersInfo.StatMods[2];
            if (armorProfs != null) foreach(string s in armorProfs)
            {
                (App.Current as App).Character.SnPData.Proficiencies.Add(s);
            }
            if (weaponProfs != null) foreach (string s in weaponProfs)
            {
                (App.Current as App).Character.SnPData.Proficiencies.Add(s);
            }
            if (toolProfs != null) foreach (string s in toolProfs)
            {
                (App.Current as App).Character.SnPData.Proficiencies.Add(s);
            }
            if (savingProfs != null) foreach (int i in savingProfs)
            {
                (App.Current as App).Character.SnPData.SavingThrows[i].Proficient = true;
            }
           
            bool exists = false;
            int rand = 0;
            for (int i = 0; i < skillCount; i++)
            {
                do
                {
                    rand = skillProfs[rng.Next(0, skillProfs.Length)];
                    if((App.Current as App).Character.SnPData.SkillModifiers[rand].Proficient == true)
                    {
                        exists = true;
                    }
                    else
                    {
                        (App.Current as App).Character.SnPData.SkillModifiers[rand].Proficient = true;
                        exists = false;
                    }
                }
                while (exists);
            }
            if (equipment != null) foreach (string s in equipment)
            {
                (App.Current as App).Character.Inventory.Items.Add(new Item(s));
            }
            (App.Current as App).Character.ActiveStats.ArmorClass = AC;
            
            if(spellsKnown > 0) (App.Current as App).Character.Spellbook.Add(new Spell("Spells Known", "You know: " + spellsKnown + " spells."));
            if(cantripsKnown > 0) (App.Current as App).Character.Spellbook.Add(new Spell("Catrips Known", "You know: " + cantripsKnown + " cantrips."));

            if (featureNames != null && featureDescs != null) for (int i = 0; i < featureNames.Count; i++)
            {
                (App.Current as App).Character.FeatureList.Add(new Feature(featureNames.ElementAt(i), featureDescs.ElementAt(i)));
            }
        }
    }
}

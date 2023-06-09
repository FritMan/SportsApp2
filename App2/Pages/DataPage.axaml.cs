using App2.Classes;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MessageBox.Avalonia;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App2.Pages
{
    public partial class DataPage : UserControl
    {
        public DataPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void searchTbKeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(SearchTb.Text))
            {
                SportsmanDG.Items = DataStorage.Sportsmen;
            }
            else 
            {
                var filteredSportsmen = new List<Sportsman>();
                foreach (var el in DataStorage.Sportsmen)
                {
                    if(el.Name.Contains(SearchTb.Text)) 
                    {
                        filteredSportsmen.Add(el);  
                    }
                }
                SportsmanDG.Items = filteredSportsmen;
            }
            CoachesDG.Items = DataStorage.Coaches;
        }

        private void backBtnClick(object? sender, RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new MainMenu();
        }

        private void addSportsmanBtnClick(object? sender, RoutedEventArgs args)
        {
            NavigationSystem.MainFrame.Content = new SportsmanEdit(null);
        }

        private void addCoachesBtnClick(object? sender, RoutedEventArgs args)
        {
            NavigationSystem.MainFrame.Content = new CoachesEdit(null);
        }

        private void editSportsmanBtnClcik(object? sender, RoutedEventArgs args)
        {
            var selectedSportsman = (Sportsman)SportsmanDG.SelectedItem;
            if (selectedSportsman == null)
            {
                Helper.ShowInfo("Выберите спорстмена");
                return;
            }

            NavigationSystem.MainFrame.Content = new SportsmanEdit(selectedSportsman);

        }

        private void editCoachesBtnClcik(object? sender, RoutedEventArgs args)
        {
            var selectedCoaches = (Coaches)CoachesDG.SelectedItem;
            if (selectedCoaches == null)
            {
                Helper.ShowInfo("Выберите тренера");
                return;
            }

            NavigationSystem.MainFrame.Content = new CoachesEdit(selectedCoaches);

        }

        private async void deleteCoachesBtnClick(object? sender, RoutedEventArgs args)
        {
            var selectedCoaches = (Coaches)CoachesDG.SelectedItem;
            if (selectedCoaches == null)
            {
                Helper.ShowInfo("Выберите тренера");
                return;
            }
            var answer = await MessageBoxManager.GetMessageBoxStandardWindow("Вопрос", "Вы уверены?",
                MessageBox.Avalonia.Enums.ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Question).Show();
            if (answer == MessageBox.Avalonia.Enums.ButtonResult.Yes)
            {
                DataStorage.Coaches.Remove(selectedCoaches);
            }

        }

        private async void deleteSportsmanBtnClick(object? sender, RoutedEventArgs args)
        {
            var selectedSportsman = (Sportsman)SportsmanDG.SelectedItem;
            if (selectedSportsman == null)
            {
                Helper.ShowInfo("Выберите спортсмена");
                return;
            }
            var answer = await MessageBoxManager.GetMessageBoxStandardWindow("Вопрос", "Вы уверены?",
                MessageBox.Avalonia.Enums.ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Question).Show();
            if (answer == MessageBox.Avalonia.Enums.ButtonResult.Yes)
            {
                DataStorage.Sportsmen.Remove(selectedSportsman);
            }
        }
    }
}


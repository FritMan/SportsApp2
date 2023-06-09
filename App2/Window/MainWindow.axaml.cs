using App2.Classes;
using App2.Pages;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace App2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainMenu();
            NavigationSystem.MainFrame = MainFrame;
            initializeDataStorage();
        }

        private void initializeDataStorage()
        {
            DataStorage.Sportsmen.Add(new Sportsman()
            {
                BirthDate = DateTime.Parse("13.04.1992"),
                Gender = DataStorage.Gender[1],
                Name = "Иванова"
            });
            DataStorage.Sportsmen.Add(new Sportsman()
            {
                BirthDate = DateTime.Parse("24.12.2003"),
                Gender = DataStorage.Gender[0],
                Name = "Иванов"
            });

            DataStorage.Coaches.Add(new Coaches()
            {
                BirthDate = DateTime.Parse("13.04.1992"),
                Gender = DataStorage.Gender[1],
                Name = "Марьянова"
            });
            DataStorage.Coaches.Add(new Coaches()
            {
                BirthDate = DateTime.Parse("24.12.2003"),
                Gender = DataStorage.Gender[0],
                Name = "Земской"
            });
        }

        private void exitBtnClick(object? sender, RoutedEventArgs args)
        {
            Close();
        }
    }
}
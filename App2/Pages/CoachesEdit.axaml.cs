using App2.Classes;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace App2.Pages
{
    public partial class CoachesEdit : UserControl
    {
        private bool isAdd = true;
        public CoachesEdit(Coaches coaches)
        {
            InitializeComponent();
            GenderCb.Items = DataStorage.Gender;
            if (coaches == null)
            {
                DataContext = new Coaches();
                GenderCb.SelectedIndex = 0;
            }
            else
            {
                isAdd = false;
                DataContext = coaches;
            }
        }
        public CoachesEdit()
        { 
            InitializeComponent(); 
        }


        private void okBtnClick(object? sender, RoutedEventArgs args)
        {
            if (String.IsNullOrEmpty(NameTb.Text))
            {
                App2.Classes.Helper.ShowInfo("Не заполнено имя.");
                return;
            }
            try
            {
                var coaches = (Coaches)DataContext;
                if (isAdd)
                {
                    DataStorage.Coaches.Add(coaches);
                }
                NavigationSystem.MainFrame.Content = new DataPage();
            }
            catch (Exception ex)
            {
                {
                    App2.Classes.Helper.ShowError("Вы не заполнили необходимые поля");
                }
            }
        }

        private void backBtnClick(object? sender, RoutedEventArgs args)
        {
            NavigationSystem.MainFrame.Content = new DataPage();
        }
    }
}

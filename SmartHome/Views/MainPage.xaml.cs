using SmartHome.ViewModels;
using SmartHome.Models;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace SmartHome.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new RoomViewModel();

            var moreButton = new ToolbarItem
            {
                Text = "More"
            };

            moreButton.Clicked += OnMoreButtonClicked;

            ToolbarItems.Add(moreButton);
        }

        private async void OnMoreButtonClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Choose Action", "Cancel", null, "New File", "Open File", "Save File");

            switch (action)
            {
                case "New File":
                    OnNewFile();
                    break;
                case "Open File":
                    OnOpenFile();
                    break;
                case "Save File":
                    OnSaveFile();
                    break;
            }
        }

        private void OnNewFile()
        {
            // Implementacija funkcionalnosti za "New File"
            DisplayAlert("Action", "New File selected", "OK");
        }

        private void OnOpenFile()
        {
            // Implementacija funkcionalnosti za "Open File"
            DisplayAlert("Action", "Open File selected", "OK");
        }

        private void OnSaveFile()
        {
            // Implementacija funkcionalnosti za "Save File"
            DisplayAlert("Action", "Save File selected", "OK");
        }

        private async void OnFrameTapped(object sender, EventArgs e)
        {
            var layout = sender as VisualElement;
            var room = layout?.BindingContext as Room;

            if (room != null)
            {
                room.IsLightOn = !room.IsLightOn;
                (BindingContext as RoomViewModel)?.OnPropertyChanged(nameof(RoomViewModel.Rooms));
            }
        }
    }
}

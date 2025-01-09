using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using SmartHome.Models;

namespace SmartHome.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<Room> rooms;
        public ObservableCollection<Room> Rooms
        {
            get => rooms;
            set
            {
                rooms = value;
                OnPropertyChanged();
                IsWelcomeVisible = rooms.Count == 0;
            }
        }

        public ICommand AddRoomCommand { get; }

        public MainViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            AddRoomCommand = new Command(AddRoom);
        }

        private bool isWelcomeVisible = true;
        public bool IsWelcomeVisible
        {
            get => isWelcomeVisible;
            set
            {
                isWelcomeVisible = value;
                OnPropertyChanged();
            }
        }

        private void AddRoom()
        {
            Rooms.Add(new Room(""));
        }
    }
}

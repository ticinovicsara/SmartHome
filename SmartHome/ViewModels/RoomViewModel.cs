using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SmartHome.Models;

namespace SmartHome.ViewModels
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Room> rooms;
        public ObservableCollection<Room> Rooms
        {
            get => rooms;
            set
            {
                rooms = value;
                OnPropertyChanged();
                CheckWelcomeVisibility();
            }
        }
        private void CheckWelcomeVisibility()
        {
            IsWelcomeVisible = Rooms.Count == 0;
        }

        private bool isWelcomeVisible = true;
        public bool IsWelcomeVisible
        {
            get => isWelcomeVisible;
            set
            {
                if (isWelcomeVisible != value)
                {
                    isWelcomeVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddRoomCommand { get; }
        public ICommand ToggleLightCommand { get; }
        public ICommand TurnOnAllRoomsCommand { get; }
        public ICommand TurnOffAllRoomsCommand { get; }

        public RoomViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            AddRoomCommand = new Command(AddRoom);
            ToggleLightCommand = new Command<Room>(ToggleLight);
            TurnOnAllRoomsCommand = new Command(TurnOnAllRooms);
            TurnOffAllRoomsCommand = new Command(TurnOffAllRooms);
        }

        private async void AddRoom()
        {
            string roomName = await Application.Current.MainPage.DisplayPromptAsync("Add Room", "Enter room name:");

            if (!string.IsNullOrWhiteSpace(roomName))
            {
                Rooms.Add(new Room(roomName));
                CheckWelcomeVisibility();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Room name cannot be empty.", "OK");
            }
        }

        public void ToggleLight(Room room)
        {
            if (room != null)
            {
                room.IsLightOn = !room.IsLightOn;
            }
        }
        private void TurnOnAllRooms()
        {
            foreach (var room in Rooms)
            {
                room.IsLightOn = true;
            }
            OnPropertyChanged(nameof(Rooms));
        }

        private void TurnOffAllRooms()
        {
            foreach (var room in Rooms)
            {
                room.IsLightOn = false;
            }
            OnPropertyChanged(nameof(Rooms));
        }


        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

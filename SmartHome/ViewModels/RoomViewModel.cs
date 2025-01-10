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
            }
        }

        private bool isWelcomeVisible;
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

        public RoomViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            AddRoomCommand = new Command(AddRoom);
            ToggleLightCommand = new Command<Room>(ToggleLight);
        }

        private async void AddRoom()
        {
            string roomName = await Application.Current.MainPage.DisplayPromptAsync("Add Room", "Enter room name:");

            if (!string.IsNullOrWhiteSpace(roomName))
            {
                Rooms.Add(new Room(roomName));
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

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

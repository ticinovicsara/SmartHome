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

        public RoomViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            AddRoomCommand = new Command(AddRoom);
            IToggleLightCommand = new Command<Room>(ToggleLight);
        }


        public ICommand IToggleLightCommand { get; }
        public ICommand AddRoomCommand { get; }

        private void ToggleLight(Room room)
        {
            if (room != null)
            {
                room.IsLightOn = !room.IsLightOn;  // Toggle the light state
                OnPropertyChanged(nameof(Rooms));   // Notify the UI for the update
            }
        }

        private void AddRoom()
        {
            Rooms.Add(new Room("New Room"));
        }

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

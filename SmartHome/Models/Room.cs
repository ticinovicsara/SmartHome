using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartHome.Models
{
    public class Room : INotifyPropertyChanged
    {
        public bool isLightOn;
        public string Name { get; set; }

        public Room(string name)
        {
            Name = name ?? "Unnamed Room";
            IsLightOn = false;
        }

        public bool IsLightOn
        {
            get => isLightOn;
            set
            {
                if (isLightOn != value)
                {
                    isLightOn = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartHome.Models
{
    public class Room
    {
        public bool IsLightOn;
        public string Name { get; set; }

        public Room(string name)
        {
            Name = name;
            IsLightOn = false;
        }

    }

}
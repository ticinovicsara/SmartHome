using Newtonsoft.Json;
using SmartHome.ViewModels;
using SmartHome.Models;

namespace SmartHome.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new RoomViewModel();
        }
        private async void OnRoomTapped(object sender, TappedEventArgs e)
        {
            if (e.Parameter is Room tappedRoom && BindingContext is RoomViewModel viewModel)
            {
                viewModel.ToggleLight(tappedRoom);
            }
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
            var roomViewModel = BindingContext as RoomViewModel;
            roomViewModel?.Rooms.Clear();

            DisplayAlert("Action", "New File selected", "OK");
        }

        private async void OnSaveFile()
        {
            try
            {
                string filePath;
#if WINDOWS
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        filePath = Path.Combine(documentsPath, "rooms.json");
#else
                filePath = Path.Combine(FileSystem.AppDataDirectory, "rooms.json");
#endif

                var roomViewModel = BindingContext as RoomViewModel;
                var roomsJson = JsonConvert.SerializeObject(roomViewModel?.Rooms);

                await File.WriteAllTextAsync(filePath, roomsJson);

                DisplayAlert("Action", "File saved successfully!", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Failed to save file: " + ex.Message, "OK");
            }
        }


        private async void OnOpenFile()
        {
            try
            {
                string filePath;

#if WINDOWS
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        filePath = Path.Combine(documentsPath, "rooms.json");
#else
                filePath = Path.Combine(FileSystem.AppDataDirectory, "rooms.json");
#endif

                if (File.Exists(filePath))
                {
                    var fileContent = await File.ReadAllTextAsync(filePath);

                    var roomsFromFile = JsonConvert.DeserializeObject<List<Room>>(fileContent);

                    var roomViewModel = BindingContext as RoomViewModel;
                    roomViewModel?.Rooms.Clear();

                    foreach (var room in roomsFromFile)
                    {
                        roomViewModel?.Rooms.Add(room);
                    }

                    DisplayAlert("Action", "File opened successfully!", "OK");
                }
                else
                {
                    DisplayAlert("Error", "File does not exist.", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Failed to open file: " + ex.Message, "OK");
            }
        }
    }
}


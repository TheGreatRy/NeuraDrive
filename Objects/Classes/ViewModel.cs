using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NeuraDrive.Objects.Classes
{
    public partial class ViewModel : ObservableObject
    {
        public ViewModel() 
        {
            GetRacecarCommand = new AsyncRelayCommand(GetRacecar);
        }
        public IAsyncRelayCommand GetRacecarCommand { get; }
        /// <summary>
        /// Racecar Object
        /// </summary>
        [ObservableProperty]
        Racecar racecar;
        /// <summary>
        /// Message property to show API call result
        /// </summary>
        [ObservableProperty]
        string message;
        /// <summary>
        /// Is busy property to show loader on screen
        /// </summary>
        [ObservableProperty]
        bool isBusy;

        /// <summary>
        /// Gets the Racecar data from API
        /// </summary>
        private async Task GetRacecar()
        {
            Random random = new Random();
            IsBusy = true;
            await RestServiceCall<Racecar>.Get($"car_data?driver_number={random.NextInt64(1, 10000)}", RacecarDataLoaded, RacecarDataLoadFailed);
            IsBusy = false;
        }

        /// <summary>
        /// Racecar details loaded successfully
        /// </summary>
        /// <param name="racecarObj">Racecar</param>
        private void RacecarDataLoaded(Racecar racecarObj)
        {
            if (racecarObj != null)
            {
                Racecar = racecarObj;
            }
            Message = "Racecar data loaded";
        }
        /// <summary>
        /// Failed to load Racecar data
        /// </summary>
        /// <param name="exception">Exception</param>
        private void RacecarDataLoadFailed(Exception exception)
        {
            Message = exception?.Message;
        }
    }
}

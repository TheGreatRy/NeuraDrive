using NeuraDrive.Objects.Classes;
using GenerativeAI;
using GenerativeAI.Core;
using GenerativeAI.Types;

namespace NeuraDrive
{
    public partial class MainPage : ContentPage
    {
        private GeminiModel _client;

        public MainPage()
        {
            InitializeComponent();

            _client = new GeminiModel("AIzaSyCawLaBhtGbvH3Wq_wyIxmdsI0AuvxzXOk", new ModelParams
            {
                Model = "gemini-2.5-flash"
            });
        }

        /// <summary>
        /// Generates and displays race results and summary and updates user funds/winnings if applicable.
        /// </summary>
        /// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
        /// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
        private async void OnStartRaceClicked(object sender, EventArgs e)
        {
            RaceSummaryLabel.Text = string.Empty;
            //Validate that a race has been created. If not, alert user to create one first
            if (RaceManager.CurrentCarsRacing.Count <= 0)
            {
                await DisplayAlert("Error", "No cars are generated to race! Please generate cars first.", "OK");
                return;
            }

            //There are valid cars to race
            await DisplayAlert("Success!", "Race Has Started!", "OK");

            RaceSummaryLabel.Text = "Loading...";

            //Generate winning car
            RaceManager.WinningCar = RaceManager.DetermineRaceWinner(RaceManager.CurrentCarsRacing);

            //Generate race with Gemini, passing in the amount of cars racing and the winning car
            var _response = await _client.GenerateContentAsync($"Provide commentary on a race as if you were a F1 commentator. " +
                $"The race consists of {RaceManager.CurrentCarsRacing.Count} cars, and by the end, car number {RaceManager.WinningCar.ID} should win.");

            //Display the generated summary
            RaceSummaryLabel.Text = _response.Text;

            var totalBettings = 0;

            foreach (var car in RaceManager.CurrentCarsRacing)
            {
                totalBettings += car.CurrentBet;
            }

            await DisplayAlert("Results!", $"You bet ${totalBettings} total and won {RaceManager.WinningCar.CurrentBet * 2}. " +
                $"The race has been cleared and your standings has been updated!", "OK");

            RaceManager.ValidateUserBet();
        }

        /// <summary>
        /// Transitions to the Racers Page
        /// </summary>
        /// <param name="sender">">I'm not sure, but it's required (not handled by us anyways)</param>
        /// <param name="e">">I'm not sure, but it's required (not handled by us anyways)</param>
        private async void RacersPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RacingPage());
        }

    }

}

using NeuraDrive.Objects.Classes;
using GenerativeAI.Core;
using GenerativeAI;
using GenerativeAI.Types;

namespace NeuraDrive
{
    public partial class MainPage : ContentPage
    {
        static RaceManager raceManager = new RaceManager();

        private string _response;

        public MainPage()
        {
            InitializeComponent();

            this.Loaded += MainPage_Loaded;
        }



        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            
        }

        private async Task GetAIRacingResponse(string recommendationType)
        {
            //OpenAIResponse response = _client.CreateResponse( "Write a one-sentence bedtime story about a unicorn." );
        }
        ///// <summary>
        ///// Uses number(#) input by user to generate a race with # random cars.
        ///// </summary>
        ///// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
        ///// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
        //private void OnGenerateRaceClicked(object sender, EventArgs e)
        //{
        //    //Validate that numCarsEntry is not null
        //    if (numCarsEntry.Text == null)
        //    {
        //        DisplayAlert("Error", "Number of cars entry is not initialized.", "OK");
        //        return;
        //    }
        //    
        //    //Validate number of cars input
        //    //Read text from numCarsEntry
        //    string? input = numCarsEntry.Text.Trim();
        //
        //    //Try to parse to int
        //    if (int.TryParse(input, out int numCars))
        //    {
        //        //validate number is within acceptible range
        //        if (numCars < 2 || numCars > 10) //Please feel free to change these values as you see fit
        //        {
        //            DisplayAlert("Invalid Input", "Please enter a number between 2 and 10.", "OK");
        //            return;
        //        }
        //
        //        //Run race Generation logic using numCars as number of cars to generate here:
        //        //Or call a method that does it
        //        DisplayAlert("Success!", "Race Has Been Generated!", "OK");
        //
        //    }
        //    else
        //    {
        //        DisplayAlert("Error", "Please enter a valid number.", "OK");
        //    }
        //}

        /// <summary>
        /// Generates and displays race results and summary and updates user funds/winnings if applicable.
        /// </summary>
        /// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
        /// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
        private async void OnStartRaceClicked(object sender, EventArgs e)
        {
            //Validate that a race has been created. If not, alert user to create one first

            await DisplayAlert("Success!", "Race Has Started!", "OK");

            await GetAIRacingResponse("resturants");

            //Generates and displays race results
            //Uses an algorythm with a slight dergree of randomization to determine the winner
            //Potentially uses an AI API to generate a text summary of the race
            //Displays results on the main page
            RaceSummaryLabel.Text = _response;
            //If user bet on the winning car, update their funds/winnings to reflect that

            //Some or all of the functionality of this method may be established in other methods
            //Whatever works best
            //But somehow or another, this method needs to cause those things to happen

            //Also, if the AI API doesn't end up working, there will need to be another means of generating a summary that would be executed instead
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

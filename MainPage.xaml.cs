namespace NeuraDrive
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        //To Be Removed (part of default MAUI project)
    private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        /// <summary>
        /// Uses number(#) input by user to generate a race with # random cars.
        /// </summary>
        /// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
        /// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
        private void OnGenerateRaceClicked(object sender, EventArgs e)
        {
            //Validate number of cars input
            //Read text from numCarsEntry
            string input = numCarsEntry.Text;

            //Try to parse to int
            if (int.TryParse(input, out int numCars))
            {
                //validate number is within acceptible range
                if (numCars < 2 || numCars > 10) //Please feel free to change these values as you see fit
                {
                    DisplayAlert("Invalid Input", "Please enter a number between 2 and 10.", "OK");
                    return;
                }

                //Run race Generation logic using numCars as number of cars to generate here:
                //Or call a method that does it
                DisplayAlert("Success!", "Race Has Been Generated!", "OK");

            }
            else
            {
                DisplayAlert("Error", "Please enter a valid number.", "OK");
            }
        }

        /// <summary>
        /// Generates and displays race results and summary and updates user funds/winnings if applicable.
        /// </summary>
        /// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
        /// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
        private void OnStartRaceClicked(object sender, EventArgs e)
        {
            //Validate that a race has been created. If not, alert user to create one first

            DisplayAlert("Success!", "Race Has Started!", "OK");

            //Generates and displays race results
            //Uses an algorythm with a slight dergree of randomization to determine the winner
            //Potentially uses an AI API to generate a text summary of the race
            //Displays results on the main page
            //If user bet on the winning car, update their funds/winnings to reflect that

            //Some or all of the functionality of this method may be established in other methods
            //Whatever works best
            //But somehow or another, this method needs to cause those things to happen

            //Also, if the AI API doesn't end up working, there will need to be another means of generating a summary that would be executed instead
        }


        //The following is here until the second page is created
        private void OnBetClicked(object sender, EventArgs e)
        {
            //Places a bet on a racer
            //Has to validate that the user has enough funds to place their bet
            //Updates their funds/winnings to reflect the bet (takes out whatever they bet)
            //Updates the car object with the bet

            //Some (or probably all) of the functionality of this method may be established in other methods
        }
    }

}

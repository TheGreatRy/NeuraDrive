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


        
    }

}

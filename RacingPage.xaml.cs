namespace NeuraDrive;
using NeuraDrive.Objects.Partials;

public partial class RacingPage : ContentPage
{
	public RacingPage()
	{
		InitializeComponent();
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
            //Display Race Car partials in the view (or call a method that does it)
            DisplayAlert("Success!", "Race Has Been Generated!", "OK");

        }
        else
        {
            DisplayAlert("Error", "Please enter a valid number.", "OK");
        }
    }

    private void DisplayRacers()
    {
        //Ideally for each loop through each car in the race
        //Create a RacingPartial object for each car
       BettingPartial bettingPartial = new BettingPartial();
        //Display each RacingPartial object in the view

    }


}
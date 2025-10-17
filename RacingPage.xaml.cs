namespace NeuraDrive;

using NeuraDrive.Objects.Classes;
using NeuraDrive.Objects.Partials;

public partial class RacingPage : ContentPage
{
    static RaceManager raceManager;
    static User user = new User();
    public RacingPage()
	{
		InitializeComponent();

        user.CurrentAmount = 12;
        moneyText.Text = "Current Funds: " + user.CurrentAmount.ToString();
        //raceManager = rm;
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


            //Display cars in betting partials
            DisplayRacers();

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
       BettingPartial bettingPartial = new BettingPartial(2, 0, 12, 11, 6, 3);
       BettingPartial bettingPartial2 = new BettingPartial(1, 10000, 1000, 100000, 10, 7);
       BettingPartial bettingPartial3 = new BettingPartial(17493276, 5, 33, 77, 17, 8);
       BettingPartial bettingPartial4 = new BettingPartial(0, 1, 2, 3, 4, 5);
        //Display each RacingPartial object in the view


        bettingPartial.Parent = PartialsFrame;
        bettingPartial2.Parent = PartialsFrame;
        bettingPartial3.Parent = PartialsFrame;
        bettingPartial4.Parent = PartialsFrame;
    }


}
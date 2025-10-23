namespace NeuraDrive;

using NeuraDrive.Objects.Classes;
using NeuraDrive.Objects.Partials;
using System.Net.Http;
using System.Text.Json;

public partial class RacingPage : ContentPage
{
    static RaceManager raceManager;
    static User User = new User();

    HttpClient _client;
    JsonSerializerOptions _serializerOptions;

    public RacingPage()
	{
		InitializeComponent();

        User.CurrentAmount = 12;
        moneyText.Text = "Current Funds: " + User.CurrentAmount.ToString();
        //raceManager = rm;
	}

    /// <summary>
    /// Uses number(#) input by User to generate a race with # random cars.
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

    /// <summary>
    /// Generates Displays RaceCars in betting partials
    /// </summary>
    private void DisplayRacers()
    {
        if(RaceManager.CurrentCarsRacing.Count > 0)
        {
            for(int i = 0; i <= RaceManager.CurrentCarsRacing.Count; i++)
            {
                BettingPartial partial = new BettingPartial(); //create new instance of the BettingPartial

                //configure betting partial here please
                partial.SetPartialInfo(
                    RaceManager.CurrentCarsRacing[i].ID,
                    RaceManager.CurrentCarsRacing[i].CurrentBet,
                    RaceManager.CurrentCarsRacing[i].RPM,
                    RaceManager.CurrentCarsRacing[i].Speed,
                    RaceManager.CurrentCarsRacing[i].Throttle,
                    RaceManager.CurrentCarsRacing[i].Brake
                    );
            
                RacersStack.Children.Add(partial); //add new and configured partial instance to the RacingPage
            }

        }


        //THE CODE BELOW IS ALL TEST DATA!!!

        //Ideally for each loop through each car in the race
        //Create a RacingPartial object for each car
       BettingPartial bettingPartial = new BettingPartial();
       BettingPartial bettingPartial2 = new BettingPartial();
       BettingPartial bettingPartial3 = new BettingPartial();
       BettingPartial bettingPartial4 = new BettingPartial();
        //Display each RacingPartial object in the view
        bettingPartial.SetPartialInfo(2, 0, 12, 11, 6, 3);
        bettingPartial2.SetPartialInfo(1, 10000, 1000, 100000, 10, 7);
        bettingPartial3.SetPartialInfo(17493276, 5, 33, 77, 17, 8);
        bettingPartial4.SetPartialInfo(0, 1, 2, 3, 4, 5);

        RacersStack.Children.Add(bettingPartial);
        RacersStack.Children.Add(bettingPartial2);
        RacersStack.Children.Add(bettingPartial3);
        RacersStack.Children.Add(bettingPartial4);

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {

    }
}
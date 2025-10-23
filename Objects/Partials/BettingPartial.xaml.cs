using NeuraDrive.Objects.Classes;

namespace NeuraDrive.Objects.Partials;

public partial class BettingPartial : ContentView
{
    static RaceManager raceManager; //once we have testible data in the RaceManager itself, redo SetPartialInfo to only take in an index, and use both that and the static class to fill out all necessary info
    static User user;
    
    public BettingPartial()
	{
		InitializeComponent();
        User.CurrentAmount = 14;
    }

    /// <summary>
    /// Fills out the important info for the parial
    /// </summary>
    /// <param name="id">For testing only</param>
    /// <param name="currentBet">For testing only</param>
    /// <param name="rpm">For testing only</param>
    /// <param name="speed">For testing only</param>
    /// <param name="throttle">For testing only</param>
    /// <param name="m_break">For testing only</param>
    public void SetPartialInfo(int id, int currentBet, int rpm, int speed, int throttle, int m_break)
    {
        idText.Text = "Car ID: " + id;
        currentBetText.Text = "Current Bet: " + currentBet;
        rpmText.Text = "RPM: " + rpm;
        speedText.Text = "Speed: " + speed;
        throttleText.Text = "Throttle: " + throttle;
        breakText.Text = "Break: " + m_break;
    }


    /// <summary>
    /// Places a bet on a car after checking that the betting amount is valid.
    /// </summary>
    /// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
    /// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
    //The following is here until the second page is created
    private void OnBetClicked(object sender, EventArgs e)
    {
        //Validate number of cars input
        //Read text from numCarsEntry
        //string input = numCarsEntry.Text;
        string betInput = betAmountEntry.Text;

        //Try to parse to int
        if (int.TryParse(betInput, out int placedBet))
        {
            //validate number is within acceptible range
            if (placedBet < 1 ) //Please feel free to change these values as you see fit
            {
                App.Current.MainPage.DisplayAlert("Invalid Input", "Cannot bet less than $1.", "OK");
                return;
            }
            
            //validate number is within acceptible range
            if (placedBet > User.CurrentAmount) //Please feel free to change these values as you see fit
            {
                App.Current.MainPage.DisplayAlert("Invalid Input", "Please enter a number between 2 and 10.", "OK");
                return;
            }

            //Run race Generation logic using numCars as number of cars to generate here:
            //Or call a method that does it
            //Display Race Car partials in the view (or call a method that does it)
            App.Current.MainPage.DisplayAlert("Success!", "Your bet has been placed!", "OK");


            //update text to show new amount of currency for the user

        }
        else
        {
            App.Current.MainPage.DisplayAlert("Error", "Please enter a valid number.", "OK");
        }




        //Places a bet on a racer
        //Has to validate that the user has enough funds to place their bet
        //Updates their funds/winnings to reflect the bet (takes out whatever they bet)
        //Updates the car object with the bet

        //Some (or probably all) of the functionality of this method may be established in other methods
    }
}
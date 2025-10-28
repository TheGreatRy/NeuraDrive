using NeuraDrive.Objects.Classes;
using System;
using System.Runtime.Intrinsics.Arm;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace NeuraDrive.Objects.Partials;

public partial class BettingPartial : ContentView
{
    static RaceManager raceManager; //once we have testible data in the RaceManager itself, redo SetPartialInfo to only take in an index, and use both that and the static class to fill out all necessary info
    static User user;

    private int m_index = -1;
    private RacingPage m_page;
    
    public BettingPartial()
	{
		InitializeComponent();
    }

    /// <summary>
    /// Fills out the important info for the parial
    /// </summary>
    /// <param name="index">Index of the car being displayed (in the context of the "current racers" list in the RaceManager</param>
    /// <param name="page">Reference to the RacingPage this partial is being displayed on (THIS IS NOT OPTIONAL)</param>
    public void SetPartialInfo(int index, RacingPage page)
    {
        //Set the two critical variables
        m_index = index;
        m_page = page;

        //Set the text in the partial based on the car
        idText.Text = "Car ID: " + RaceManager.CurrentCarsRacing[index].ID;
        currentBetText.Text = "Current Bet: " + RaceManager.CurrentCarsRacing[index].CurrentBet;
        rpmText.Text = "RPM: " + RaceManager.CurrentCarsRacing[index].RPM;
        speedText.Text = "Speed: " + RaceManager.CurrentCarsRacing[index].Speed;
        throttleText.Text = "Throttle: " + RaceManager.CurrentCarsRacing[index].Throttle;
    }


    /// <summary>
    /// Places a bet on a car after checking that the betting amount is valid.
    /// </summary>
    /// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
    /// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
    //The following is here until the second page is created
    private void OnBetClicked(object sender, EventArgs e)
    {
        //Validate input bet
        //Read text from betAmountEntry
        string betInput = betAmountEntry.Text;

        //Try to parse to int
        if (int.TryParse(betInput, out int placedBet))
        {
            //validate number is within acceptible range
            if (placedBet < 1 )
            {
                App.Current.MainPage.DisplayAlert("Invalid Input", "Cannot bet less than $1.", "OK");
                return;
            }
            
            //validate that the user has enough funds to place this bet
            if (placedBet > User.CurrentAmount)
            {
                App.Current.MainPage.DisplayAlert("Invalid Input", "You do not have enough funds!", "OK");
                return;
            }

            //Tell user that the bet has been placed
            App.Current.MainPage.DisplayAlert("Success!", "Your bet has been placed!", "OK");

            //Update user currency amount
            User.CurrentAmount -= placedBet;

            //Register the bet in the car and on the page
            RaceManager.CurrentCarsRacing[m_index].CurrentBet += placedBet;
            currentBetText.Text = "Current Bet: " + RaceManager.CurrentCarsRacing[m_index].CurrentBet;


            //update text to show new amount of currency for the user
            m_page.UpdateUserFunds();

        }
        else
        {
            //Tell user to input an actual integer number
            App.Current.MainPage.DisplayAlert("Error", "Please enter a valid number.", "OK");
        }
    }
}
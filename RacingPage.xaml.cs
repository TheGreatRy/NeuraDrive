namespace NeuraDrive;

public partial class RacingPage : ContentPage
{
	public RacingPage()
	{
		InitializeComponent();
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
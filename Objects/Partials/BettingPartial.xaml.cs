namespace NeuraDrive.Objects.Partials;

public partial class BettingPartial : ContentView
{
	public BettingPartial()
	{
		InitializeComponent();
        

    }


    /// <summary>
    /// Places a bet on a car after checking that the betting amount is valid.
    /// </summary>
    /// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
    /// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
    //The following is here until the second page is created
    private void OnBetClicked(object sender, EventArgs e)
    {
        string betString = betAmountEntry.Text;

        //Places a bet on a racer
        //Has to validate that the user has enough funds to place their bet
        //Updates their funds/winnings to reflect the bet (takes out whatever they bet)
        //Updates the car object with the bet

        //Some (or probably all) of the functionality of this method may be established in other methods
    }
}
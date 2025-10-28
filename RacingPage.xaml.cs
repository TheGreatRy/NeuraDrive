namespace NeuraDrive;

using Microsoft.Maui.Graphics.Text;
using NeuraDrive.Objects.Classes;
using NeuraDrive.Objects.Partials;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

public partial class RacingPage : ContentPage
{
    static RaceManager raceManager;
    static User User = new User();

    HttpClient client = new HttpClient { BaseAddress = new Uri("https://api.openf1.org/v1") };
    private int numCars = 0;

    public RacingPage()
    {
        InitializeComponent();

        moneyText.Text = "Current Funds: " + User.CurrentAmount.ToString();
        //raceManager = rm;
        loadingCars.Text = "No Cars to Load!";

    }

    /// <summary>
    /// Uses number(#) input by User to generate a race with # random cars.
    /// </summary>
    /// <param name="sender">I'm not sure, but it's required (not handled by us anyways)</param>
    /// <param name="e">I'm not sure, but it's required (not handled by us anyways)</param>
    private async void OnGenerateRaceClicked(object sender, EventArgs e)
    {
        //Ask user if they want to override their current race
        if (RaceManager.CurrentCarsRacing.Count > 0)
        {
            var overrideRace = await DisplayAlert("Override Current Race", "You already have a race generated! Would you like to override it?", "Yes", "No");

            if (!overrideRace)
            {
                return;
            }

            RaceManager.CurrentCarsRacing[0].ResetID();
            RaceManager.CurrentCarsRacing.Clear();
            RacersStack.Children.Clear();
        }
        //Validate number of cars input
        //Read text from numCarsEntry
        string input = numCarsEntry.Text;

        //Try to parse to int
        if (int.TryParse(input, out numCars))
        {
            //validate number is within acceptible range
            if (numCars < 2 || numCars > 10) //Please feel free to change these values as you see fit
            {
                DisplayAlert("Invalid Input", "Please enter a number between 2 and 10.", "OK");
                return;
            }

            //Run race Generation logic using numCars as number of cars to generate here:
            //Or call a method that does it


            for (int i = 0; i < numCars; i++)
            {
                await GetNewRacecar();
            }

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
        loadingCars.Text = "Loaded " + RaceManager.CurrentCarsRacing.Count + " Cars!";

        if (RaceManager.CurrentCarsRacing.Count > 0)
        {
            for (int i = 0; i < RaceManager.CurrentCarsRacing.Count; i++)
            {
                BettingPartial partial = new BettingPartial(); //create new instance of the BettingPartial

                //configure betting partial here please
                partial.SetPartialInfo(i, this);


                RacersStack.Children.Add(partial); //add new and configured partial instance to the RacingPage
            }

        }
    }

    /// <summary>
    /// Generates a new Racecar with data from OpenF1 API and adds it to the CurrentCarsRacing list
    /// </summary>
    /// <returns></returns>
    private async Task GetNewRacecar()
    {
        loadingCars.Text = "Loading Car " + (RaceManager.CurrentCarsRacing.Count) + "/" + numCars;
        Random random = new Random();

        //make HTTP Request to OpenF1 with a random car (using driver number)
        int randomNum = random.Next(0, RaceManager.ValidRacecarNumbers.Length);
        int randomRacer = RaceManager.ValidRacecarNumbers[randomNum];

        var response = await client.GetAsync($"{client.BaseAddress}/car_data?driver_number={randomRacer}&session_key=latest&throttle>=80");

        //If response is successful
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            //read the data as a string
            var jsonData = await response.Content.ReadAsStringAsync();

            //If the string is valid
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                // THANK YOU COPIOLOT ILY <3
                // Parse the JSON array
                var arr = JsonConvert.DeserializeObject<List<JObject>>(jsonData);
                if (arr != null && arr.Count > 0)
                {
                    var obj = arr[0];

                    //Ok back to my code
                    //Create new Racecar from JSON data
                    Racecar newRacecar = new Racecar()
                    {
                        RPM = int.Parse(obj["rpm"].ToString()),
                        Speed = int.Parse(obj["speed"].ToString()),
                        Throttle = int.Parse(obj["throttle"].ToString())
                    };

                    //Add new Racecar to the CurrentCarsRacing list
                    RaceManager.CurrentCarsRacing.Add(newRacecar);
                }
                else
                {
                    await DisplayAlert("Error with JSON Object", "Creating a Random Racecar", "OK");
                    Racecar newRacecar = new Racecar()
                    {
                        RPM = random.Next(10500, 15000),
                        Speed = random.Next(250, 350),
                        Throttle = random.Next(70, 100)
                    };

                    //Add new Racecar to the CurrentCarsRacing list
                    RaceManager.CurrentCarsRacing.Add(newRacecar);
                    return;
                }
            }
            //The string was empty
            else
            {
                await DisplayAlert("Error with JSON Object", "Empty JSON Object String", "OK");

                return;
            }
        }
        //Response was not successful
        else
        {
            await DisplayAlert("Failed Request", "Request failed with status code " + response.StatusCode, "OK");

            return;
        }
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (RaceManager.CurrentCarsRacing.Count > 0)
        {
            DisplayRacers();
        }
    }



    /// <summary>
    /// Updates user currency amount
    /// </summary>
    public void UpdateUserFunds()
    {
        moneyText.Text = "Current Funds: " + User.CurrentAmount.ToString();
    }
}
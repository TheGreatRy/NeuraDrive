using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuraDrive.Objects.Classes
{
    /// <summary>
    /// The Race Manager Object of the application. Only one is needed and it will be updated as the application is running
    /// </summary>
    static class RaceManager
    {
        /// <summary>
        /// The current List of cars that are racing
        /// </summary>
        public static List<Racecar> CurrentCarsRacing { get; set; } = new List<Racecar>();

        /// <summary>
        /// The winning Racecar of the generated race. It will be valid if the CurrentRaceCar List is populated
        /// </summary>
        public static Racecar? WinningCar {
            get { return WinningCar;  }

            private set
            {
                if (CurrentCarsRacing.Count > 0)
                { 
                    WinningCar = DetermineRaceWinner(CurrentCarsRacing); 
                }
            }
        }

        /// <summary>
        /// This may not be needed, i need to see where it's being used in the application
        /// </summary>
        /// <param name="APIInput"></param>
        /// <returns></returns>
        public static string RaceOutput (string APIInput)
        {
            return "this should be the AI commentary :3";
        }

        /// <summary>
        /// A predefined winner of the race based on the current list of Racecars
        /// </summary>
        /// <param name="carsRacing">The list of Racecars to determine the winner from</param>
        /// <returns></returns>
        private static Racecar DetermineRaceWinner(List<Racecar> carsRacing)
        {
            Random random = new Random();
            foreach(Racecar racecar in carsRacing)
            {
                float generateStanding = (racecar.Brake / 100.0f) * ((float)random.Next((racecar.Throttle * racecar.Speed) + racecar.RPM));
                racecar.WinStanding = generateStanding;
            }

            float currentCompare = carsRacing[0].WinStanding;
            int winningCarIndex = 0;

            for (int i = 1; i < carsRacing.Count; i++)
            {
                winningCarIndex = (carsRacing[i].WinStanding > currentCompare) ? i : i - 1;
                currentCompare = (carsRacing[i].WinStanding > currentCompare) ? carsRacing[i].WinStanding : currentCompare;
            }

            return carsRacing[winningCarIndex];
        }

        /// <summary>
        /// Doubles the bet of the user put on the winning car, if any, then clears the list of current Racecars and the winner
        /// </summary>
        /// <param name="user">The user to add the winnings to</param>
        public static void ValidateUserBet(User user)
        {
            foreach(Racecar racecar in CurrentCarsRacing)
            {
                if (WinningCar.ID == racecar.ID && WinningCar.CurrentBet > 0)
                {
                    user.CurrentAmount += WinningCar.CurrentBet * 2;
                }
            }
            CurrentCarsRacing.Clear();
            WinningCar = null;
        }
    }
}

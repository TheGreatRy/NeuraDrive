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
    public class RaceManager
    {
        public static int[] ValidRacecarNumbers { get; } = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 30, 31, 35, 43, 44, 55, 63, 77, 81, 87, 89, 98};
        /// <summary>
        /// The current List of cars that are racing
        /// </summary>
        public static List<Racecar> CurrentCarsRacing { get; set; } = new List<Racecar>();

        /// <summary>
        /// The winning Racecar of the generated race. It will be valid if the CurrentRaceCar List is populated
        /// </summary>
        public static Racecar? WinningCar { get; set; }

        /// <summary>
        /// A predefined winner of the race based on the current list of Racecars
        /// </summary>
        /// <param name="carsRacing">The list of Racecars to determine the winner from</param>
        /// <returns></returns>
        public static Racecar DetermineRaceWinner(List<Racecar> carsRacing)
        {
            Random random = new Random();
            foreach (Racecar racecar in carsRacing)
            {
                float generateStanding = (float)random.Next((racecar.Throttle * racecar.Speed) + racecar.RPM);
                racecar.WinStanding = generateStanding;
            }

            Racecar currentCompare = carsRacing[0];
            int winningCarIndex = 0;

            for (int i = 1; i < carsRacing.Count; i++)
            {
                winningCarIndex = (carsRacing[i].WinStanding > currentCompare.WinStanding) ? i : currentCompare.ID - 1;
                currentCompare = carsRacing[winningCarIndex];
            }

            return carsRacing[winningCarIndex];
        }

        /// <summary>
        /// Doubles the bet of the user put on the winning car, if any, then clears the list of current Racecars and the winner
        /// </summary>
        /// <param name="user">The user to add the winnings to</param>
        public static void ValidateUserBet()
        {
            foreach (Racecar racecar in CurrentCarsRacing)
            {
                if (WinningCar.ID == racecar.ID && WinningCar.CurrentBet > 0)
                {
                    User.CurrentAmount += WinningCar.CurrentBet * 2;
                }
            }

            CurrentCarsRacing[0].ResetID();
            CurrentCarsRacing.Clear();
            WinningCar = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuraDrive.Objects.Classes
{
    class RaceManager
    {
        //Race Object(info the race needs)
        //List of cars racing
        //Wining car
        //generate race result(text output)
        //winning car math(assign winning car)
        //validate win lose(betting will take out amount, do not retake if lost, only check for winnings)
        public List<Racecar> CurrentCarsRacing { get; set; }
        public Racecar WinningCar { 
            get; 
            private set; 
        }
        public string RaceOutput (string APIInput)
        {
            return "";
        }
        private Racecar DeterminRaceWinner(List<Racecar> carsRacing)
        {
            Random random = new Random();
            foreach(Racecar racecar in carsRacing)
            {
                float generateStanding = (racecar.Brake / 100.0f) * ((float)random.Next((racecar.Throttle * racecar.Speed) + racecar.RPM));
            }

            return null;
        }
    }
}

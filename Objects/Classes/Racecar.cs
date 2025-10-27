using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuraDrive.Objects.Classes
{
    public class Racecar
    {
        private static int _nextID = 1;
        public int ID { get; set; } = _nextID++;
        public int CurrentBet { get; set; } = 0;
        public int RPM { get; set; }
        public int Speed { get; set; }
        public int Throttle { get; set; }
        public float WinStanding { get; set; } = 0;
        public string? Name { get; set; }

        public void ResetID()
        {
             _nextID = 1;
        }
    }
}

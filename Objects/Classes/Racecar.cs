using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuraDrive.Objects.Classes
{
    class Racecar
    {
        public int ID { get; set; }
        public int CurrentBet { get; set; }
        public int RPM { get; set; }
        public int Speed { get; set; }
        public int Throttle { get; set; }
        public int Brake { get; set; }
        public float WinStanding { get; set; }
        public string? Name { get; set; }
    }
}

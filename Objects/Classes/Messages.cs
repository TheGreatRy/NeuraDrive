using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuraDrive.Objects.Classes
{
    internal class MessageBuilder
    {

        //public List<String> raceResultsList { get; private set; }
        public StringBuilder raceResultsBuilder = new StringBuilder();


        private List<Message> winMessages = new List<Message>()
        {
            new Message { textOne = "", textTwo = " won, but it was a very close call!"}, 
            new Message { textOne = "", textTwo = " won by a landslide!"}, 
            new Message { textOne = "Through the final corner — and ", textTwo = " wins the United States Grand Prix! What a phenomenal drive under pressure!"}
        };

        private List<Message> openingMessages = new List<Message>()
        {
            new Message { textOne = "And we are GO GO GO in Austin! "},
            new Message { textOne = "A blistering start from ", textTwo = " off the line! "}

        };


        private List<Message> otherMessages = new List<Message>()
        { 
            new Message { textOne = "Whoah! ", textTwo = " just spun out and crashed into one of the other racers! "},
            new Message { textOne = "", textTwo = " looking racy around the outside, trying to hang it there, but there’s just no grip on that higher line. "}, 
            new Message { textOne = "Oh! Contact further back — looks like a bit of carbon fiber flying from ", textTwo = " " },
            new Message { textOne = "As they come through Sector 1, those cars are dancing through the esses — just look at the precision, every apex nailed at nearly 280 kilometers an hour. ", textTwo = " is staying within DRS range; he’ll be eyeing that activation zone on the back straight. This is shaping up to be a fantastic battle up front! "},
            new Message { textOne = "Lap 15 now, pit stops are beginning — the strategists are earning their money today. Ferrari are pulling the trigger early — ", textTwo = " in for a fresh set of hards! "},
            new Message { textOne = "That’s a bold undercut attempt; they’re clearly banking on track position here. The pressure is on for ", textTwo = " to respond!"},
            new Message { textOne = "Fastest lap goes to ", textTwo = "! He’s flying out there, really extracting everything from those medium tyres. You can see he’s pushing — sparks flying from the floor as he attacks every curb. "}, 
            new Message { textOne = "", textTwo = " is right there in the DRS zone, he’s gaining, gaining — but it might just be too little too late! "}
        };



        public string GenerateMessages()
        {
            //generate random race opening line
            int randomStartCarIndex = Random.Shared.Next(RaceManager.CurrentCarsRacing.Count - 1);
            int randomStartMessageIndex = Random.Shared.Next(openingMessages.Count - 1);

            String openingMessage = openingMessages[randomStartMessageIndex].textOne + RaceManager.CurrentCarsRacing[randomStartCarIndex].Name + openingMessages[randomStartMessageIndex].textTwo;
            raceResultsBuilder.AppendLine(openingMessage);

            //generate random race messages
            for (int i = 0; i < 3; i++)
            {
                int randomCarIndex = Random.Shared.Next(RaceManager.CurrentCarsRacing.Count - 1);
                int randomMessageIndex = Random.Shared.Next(otherMessages.Count - 1);
                String message = otherMessages[randomMessageIndex].textOne + RaceManager.CurrentCarsRacing[randomCarIndex].Name + otherMessages[randomMessageIndex].textTwo;
                raceResultsBuilder.AppendLine(message);
            }

            //generate random message about the winning car
            int randomWinMessageIndex = Random.Shared.Next(winMessages.Count - 1);
            String winMessage = winMessages[randomWinMessageIndex].textOne + RaceManager.WinningCar.Name + winMessages[randomWinMessageIndex].textTwo;
            raceResultsBuilder.AppendLine(winMessage);

            //return message
            String raceResults = raceResultsBuilder.ToString();
            return raceResults;
        }


    }




    internal class Message
    {
        internal string textOne { get; set;}
        internal string textTwo { get; set;}
    }
}

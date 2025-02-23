using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soup.Manga.Logic
{
    
    public class MastermindService
    {
        Random Random = new Random();
        public int TargetNumber { get; set; }
        private bool _IsNumberGenerated = true;

        
        public string GuessNumber(int aNumber)
        {
            string result;
            //Put this in a bool so it only does it once per guess
            if (_IsNumberGenerated)
            {
                TargetNumber = Random.Next(10);
                _IsNumberGenerated=false;
            }

            if (aNumber > TargetNumber)
            {
                result = "Hmmm, No. Try picking something a little smaller";
            }
            else if (aNumber < TargetNumber)
            {
                result = "Hmmm, No. Try picking something a little bigger";
            }
            else
            {
                result = "Wow, I can't believed you actually guessed it";
            }
           return result;
            
        }
    }
}

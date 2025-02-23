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
        private bool _IsNumberGenerated = false;

        public string GuessNumber(int aNumber)
        {
            if (_IsNumberGenerated)
            {
                TargetNumber = Random.Next(10);
                _IsNumberGenerated=true;
            }
            
            string result;
            if (aNumber == TargetNumber)
            {
                result = "Wow, I can't believed you actually guessed it";
            }
            if (aNumber > TargetNumber)
            {
                result = "Hmmm, No. Try picking something a little smaller";
            }
            else
            {
                result = "Hmmm, No. Try picking something a little bigger";
            }
            return result;
            
        }
    }
}

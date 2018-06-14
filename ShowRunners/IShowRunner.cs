using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxcomTest.ShowRunners
{
    public interface IShowRunner
    {
        void InitialAnalysis(IEnumerable<Door> doors);
        int FirstGuess(int guessNum);
        bool FinalDecision(bool isAnotherDoorOpened);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxcomTest.GameStrats
{
    class RandomStrat : IStrategy
    {
        public bool YesOrNo()
        {
            int value = DataGenerator.random.Next(0, 2);
            switch (value)
            {
                case 0:
                    return true;
                case 1:
                    return false;
            }
            return false;
        }
    }
}

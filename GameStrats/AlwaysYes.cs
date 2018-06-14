using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxcomTest.GameStrats
{
    public class AlwaysYes : IStrategy
    {
        public bool YesOrNo()
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxcomTest.Prizes;

namespace TaxcomTest
{
    public class Door
    {
        public IPrize Prize { get; set; }

        public Door()
        {
            
        }
        public Door(IPrize prize)
        {
            Prize = prize;
        }
    }
}

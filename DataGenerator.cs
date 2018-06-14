using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxcomTest.Prizes;
using System.Threading;

namespace TaxcomTest
{
    class DataGenerator
    {
        public static Random random = new Random();
        public static IEnumerable<Door> CreateRandomDoorList()
        {
            int winningPosition = random.Next(1, 4);
            List<Door> doors = new List<Door>();
            for (int i = 0; i < 3; i++)
                doors.Add(new Door(new Goat()));
            doors[winningPosition - 1] = new Door(new Car());
            return doors;
            
        }
    }
}

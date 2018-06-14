using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxcomTest.ShowRunners;
using TaxcomTest.GameStrats;

namespace TaxcomTest
{
    public class GameInitializer
    {
        private IShowRunner Runner { get; set; }

        public GameInitializer()
        {
            Runner = new ShowRunner();
        }

        public bool StartGame(IStrategy strategy)
        {
            //Создание списка дверей со случайным расположением выигрышной
            IEnumerable<Door> initialDoors = DataGenerator.CreateRandomDoorList();

            //Запуск первоначальной обработки
            Runner.InitialAnalysis(initialDoors);
            
            //Запуск первой попытки
            int initialGuess = DataGenerator.random.Next(1, 4);
            int revealedDoor = Runner.FirstGuess(initialGuess);

            //Вычисление результата в зависимости от выбранной стратегии
            bool isItWon = Runner.FinalDecision(strategy.YesOrNo());

            return isItWon;
        }
    }
}

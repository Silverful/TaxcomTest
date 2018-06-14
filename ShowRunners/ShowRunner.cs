using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxcomTest.Prizes;
using System.Threading;

namespace TaxcomTest.ShowRunners
{
    /// <summary>
    /// Класс, реализующий интерфейс Ведущего
    /// </summary>
    public class ShowRunner: IShowRunner
    {
        //Победная дверь
        private int WinDoorNumber { get; set; }
        //Значение, которое выбрал клиент
        private int ClientGuess { get; set; }
        //Раскрываемое значение
        private int ReturnGuess { get; set; }

        //Список дверей
        private List<Door> Doors { get; set; }

        //Первоначальный анализ
        public void InitialAnalysis(IEnumerable<Door> doors)
        {
            if (doors != null)
            {
                List<Door> doorsList = doors as List<Door>;
                Doors = doorsList;
                //Выясняем какая дверь выигрышная
                for (int i = 0; i <= doorsList.Count - 1; i++)
                    if (doorsList[i].Prize is IWinPrize)
                        WinDoorNumber = i + 1;
            }
        }

        //Обработка выбранного значения
        public int FirstGuess(int guessNum)
        {
            ClientGuess = guessNum;
            //На выход выдается случайное значение, которое не является клиенским вводом и выигрышным значением
            int returningValue = DataGenerator.random.Next(0, 3);
            while ((Doors[returningValue].Prize is IWinPrize) || (returningValue == ClientGuess - 1))
            {
                returningValue = DataGenerator.random.Next(0, 3);
            }
            ReturnGuess = returningValue + 1;
            return ReturnGuess;
        }

        //Обработка финального значения
        public bool FinalDecision(bool isAnotherDoorOpened)
        {
            //Если нет, то возвращаем клиентский ввод
            if (!isAnotherDoorOpened)
                if (Doors[ClientGuess - 1].Prize is IWinPrize) return true;
            //Если да, то возвращаем не клиентский ввод и не раскрытое значение
            if (isAnotherDoorOpened)
            {
                int finalDoorNum = -1;
                for (int i = 0; i <= Doors.Count; i++)
                {
                    if (i + 1 != ClientGuess && i + 1 != ReturnGuess)
                    {
                        finalDoorNum = i;
                        break;
                    }
                }
                if (Doors[finalDoorNum].Prize is IWinPrize) return true;
            }
            return false;
        }
    }
}

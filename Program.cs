using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxcomTest.Prizes;
using TaxcomTest.GameStrats;

//Задание:
//Представьте, что вы стали участником игры, в которой вам нужно выбрать одну из трёх дверей.
//За одной из дверей находится автомобиль, за двумя другими дверями — козы.
//Вы выбираете одну из дверей, например, номер 1, после этого ведущий, который знает, где находится автомобиль, 
//а где — козы, открывает одну из оставшихся дверей, например, номер 3, за которой находится коза.
//После этого он спрашивает вас — не желаете ли вы изменить свой выбор и выбрать дверь номер 2? 
//Увеличатся ли ваши шансы выиграть автомобиль, если вы примете предложение ведущего и измените свой выбор?

//Проверьте этот парадокс на С# через многократное повторение возможных стратегий действий участника.

namespace TaxcomTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GameInitializer game = new GameInitializer();

            int gamesWonAlwaysYes = 0;
            int gamesWonAlwaysNo = 0;
            int gamesWonRandomStrat = 0;
            Console.WriteLine("How many turns would you like to take? ");
            int turns = Int32.Parse(Console.ReadLine());
            for (int i = 0; i <= turns; i++)
            {
                if (game.StartGame(new AlwaysYes())) gamesWonAlwaysYes++;
                if (game.StartGame(new AlwaysNo())) gamesWonAlwaysNo++;
                if (game.StartGame(new RandomStrat())) gamesWonRandomStrat++;
            }
            Console.WriteLine("With \"Always Yes\" Strategy you'd win {0} out of {1} games!", gamesWonAlwaysYes, turns);
            Console.WriteLine("With \"Always No\" Strategy you'd win {0} out of {1} games!", gamesWonAlwaysNo, turns);
            Console.WriteLine("With \"Random\" Strategy you'd win {0} out of {1} games!", gamesWonRandomStrat, turns);
            Console.ReadLine();
        }
    }
}

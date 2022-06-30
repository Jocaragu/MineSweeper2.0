using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Game
    {
        internal Integrator integrator = new();
        public static Gamestate currentstate { get; set; }

        public Game()
        {
            while (currentstate == Gamestate.Launching)
            {
                Start();
                if (currentstate != Gamestate.Launching)
                {
                    break;
                }
            }
            while (currentstate == Gamestate.Playing)
            {
                Play();
                if (currentstate != Gamestate.Playing)
                {
                    break;
                }
            }
            while (currentstate == Gamestate.Over)
            {
                Over();
                if (currentstate != Gamestate.Over)
                {
                    break;
                }
            }
        }

        public void Start()
        {
            integrator.MakeTheBoard();
            integrator.BoardTheCoordinates();
            integrator.BoardTheCells();
            integrator.PrintGrid();
            Coordinates seed = integrator.SelectCoordinates();
            integrator.BoardTheMines(seed);
            integrator.HintTheCells();
            integrator.Stepping(seed);
            currentstate = Gamestate.Playing;
        }
        public void Play()
        {
            integrator.PrintGrid();
            integrator.Stepping(integrator.SelectCoordinates());
        }
        public void Over()
        {
            Console.WriteLine("\nGame over!!!");
            Console.Write("\nTry again y/n?: ");
            char next = Console.ReadKey().KeyChar;
            if (next == 'Y'||next == 'y')
            {
                Console.WriteLine("\n\nHere we go again!");
                Console.ReadLine();
                currentstate = Gamestate.Launching;
                Game newGame = new();
            }
            else if (next == 'N'||next=='n')
            {
                Console.WriteLine("\n\nBye bye!");
                currentstate = Gamestate.Exiting;
            }
            else
            {
                Over();
            }
        }
    }
    public enum Gamestate
    {
        Launching,
        Playing,
        Over,
        Exiting,
    }
}

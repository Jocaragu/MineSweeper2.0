using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Game
    {
        Integrator integrator = new();
        public Gamestate currentstate { get; set; }
        public void Start()
        {
            integrator.MakeTheBoard();
            integrator.BoardTheCoordinates();
            integrator.BoardTheCells();
            Console.Clear();
            integrator.PrintGrid();
            integrator.SelectCell();
            integrator.BoardTheMines();
            currentstate = Gamestate.Playing;
        }
        public void Play()
        {
            do
            {
                Console.Clear();
                integrator.PrintGrid();
                integrator.SelectCell();
            }
            while (currentstate == Gamestate.Playing);
        }
        public void Over()
        {
            integrator.RevealMines();
        }
    }
    public enum Gamestate
    {
        Launching,
        Playing,
        Over,
    }
}

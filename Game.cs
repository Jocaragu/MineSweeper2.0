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
        public Game()
        {
            currentstate = Gamestate.Launching;
            if (currentstate == Gamestate.Launching)
            {
                Start();
                currentstate = Gamestate.Playing;
            }
            while (currentstate == Gamestate.Playing)
            {
                Play();
            }
            if (currentstate == Gamestate.Over)
            {
                Over();
            }
        }
        public void Start()
        {
            integrator.MakeTheBoard();
            integrator.BoardTheCoordinates();
            integrator.BoardTheCells();
            //integrator.BoardTheMines();
        }
        public void Play()
        {
            integrator.PrintGrid();
            integrator.SelectCell();
        }
        public void Over()
        {
            integrator.RevealMines();
            Console.WriteLine("game over!");
        }
    }
    public enum Gamestate
    {
        Launching,
        Playing,
        Over,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Cell
    {
        public bool Revealed { get; set; }
        public string Label = "▐█▌ ";
        public Coordinates Coordinates { get; set; }
        public int AdjacentMines { get; set; }
        public Cell(Coordinates coordinates)
        {
            Revealed = false;
            Coordinates = coordinates;
        }
        
        public int DetectedAdjacentMines(int detectedMines)
        {
            AdjacentMines = detectedMines;
            return AdjacentMines;
        }
        public void SteppingOn(bool stepped)
        {
            Revealed |= stepped;

            if (Revealed)
            {
                if (AdjacentMines > 0)
                {
                    Label = ("[" + AdjacentMines.ToString() + "] ");
                }
                else
                {
                    Label = " ·  ";
                }
            }
        }
    }
}

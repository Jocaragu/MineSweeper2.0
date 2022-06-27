using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Cell
    {
        public string Label = "[ ]";
        public Coordinates Coordinates { get; set; }
        public Cell(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
        public void SteppingOn(bool stepped)
        {
            if (stepped)
            {
                Label = "   ";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Mine
    {
        public bool Detonate { get; set; } = false;
        public string Status { get; set; } = "latent";
        public Coordinates Coordinates { get; set; }
        public void SteppingOn(bool stepped)
        {
            if (stepped)
            {
                Detonate = true;
                Status = "kaBOOM!!!";
            }
        }
        public Mine(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
    }
}

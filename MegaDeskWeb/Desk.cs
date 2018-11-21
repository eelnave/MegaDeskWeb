using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MegaDeskWeb
{
    public class Desk
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawers { get; set; }
        public string Material { get; set; }

        public Desk(int width, int depth, int drawers, string material)
        {
            Width = width;
            Depth = depth;
            Drawers = drawers;
            Material = material;
        }

        public string CsvString()
        {
            return $"{Width},{Depth},{Drawers},{Material},";
        }
    }
}


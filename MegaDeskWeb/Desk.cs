using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MegaDeskWeb
{
    public enum SurfaceMaterial
    {
        Oak,
        Rosewood,
        Veneer,
        Pine,
        Laminate
    }

    public struct Desk
    {
        public Guid DeskId { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawers { get; set; }
        public SurfaceMaterial Material { get; set; }

        public Desk(int width, int depth, int drawers, SurfaceMaterial material)
        {
            Guid id = Guid.NewGuid();

            DeskId = id;
            Width = width;
            Depth = depth;
            Drawers = drawers;
            Material = material;
        }

        public string CsvString()
        {
            return $"{DeskId},{Width},{Depth},{Drawers},{Material},";
        }
    }
}


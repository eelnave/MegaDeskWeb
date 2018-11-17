using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MegaDeskWeb
{
    public class DeskQuote
    {
        private Desk Desk { get; set; }
        private static int RushDays { get; set; }
        private string Name { get; set; }
        private DateTime QuoteDate { get; set; }
        public decimal QuoteCost { get; }

        public DeskQuote(Desk desk, int rushDays, string name, DateTime quoteDate)
        {
            Desk = desk;
            RushDays = rushDays;
            Name = name;
            QuoteDate = quoteDate;
            QuoteCost = CalculateQuote(Desk);
        }

        public static decimal CalculateQuote(Desk desk)
        {
            var quote = 200M;

            quote += AreaCost(desk.Width, desk.Depth);
            quote += DrawerCost(desk.Drawers);
            quote += SurfaceMaterialCost(desk.Material);
            if (RushDays <= 0)
            {
                int area = GetArea(desk.Width, desk.Depth);
                quote += RushCost(RushDays, area);
            }
            return quote;

            decimal AreaCost(int width, int depth)
            {
                int area = GetArea(width, depth);
                if (area > 1000)
                {
                    return area - 1000;
                }
                else
                {
                    return 0;
                }
            }

            decimal DrawerCost(int drawers)
            {
                return drawers * 50;
            }

            decimal SurfaceMaterialCost(SurfaceMaterial material)
            {
                switch (material)
                {
                    case SurfaceMaterial.Laminate:
                        return 100M;
                    case SurfaceMaterial.Oak:
                        return 200M;
                    case SurfaceMaterial.Pine:
                        return 50M;
                    case SurfaceMaterial.Rosewood:
                        return 300M;
                    case SurfaceMaterial.Veneer:
                        return 125M;
                    default:
                        return 0M;
                }
            }

            decimal RushCost(int RushDays, int Area)
            {
                decimal[,] CostArray = new decimal[3, 3];
                using (StreamReader reader = new StreamReader("rushOrderPrices.txt"))
                {
                    int i, j;
                    i = 0;
                    j = 0;
                    while (reader.EndOfStream == false)
                    {
                        CostArray[i, j] = decimal.Parse(reader.ReadLine());
                        j++;
                        if (j == 3)
                        {
                            i++;
                            j = 0;
                        }
                    }
                }

                int x;
                int y;

                if (Area < 1000)
                {
                    x = 0;
                }
                else if (Area > 1000 && Area < 2000)
                {
                    x = 1;
                }
                else
                {
                    x = 2;
                }

                if (RushDays == 3)
                {
                    y = 0;
                }
                else if (RushDays == 5)
                {
                    y = 1;
                }
                else
                {
                    y = 2;
                }

                return CostArray[x , y];
            }

            int GetArea(int width, int depth)
            {
                int area = width * depth;
                return area;
            }
        }

        public string CsvString()
        {
            return $"{RushDays},{Name},{QuoteDate},{QuoteCost}";
        }
    }
}


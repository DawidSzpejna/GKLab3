using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;
using Model;

namespace GKLab3.Modifiers
{
    internal class OrderedDitheringPosition : OrderedDithering
    {
        public OrderedDitheringPosition(Krgb krgb) : base(krgb) {}

        protected override (int iD, int jD) CountIJD(int x, int y, int n) => (x % n, y % n);
    }
}

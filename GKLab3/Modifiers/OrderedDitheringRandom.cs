using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;
using Model;

namespace GKLab3.Modifiers
{
    internal class OrderedDitheringRandom : OrderedDithering
    {
        private Random Rnd;

        public OrderedDitheringRandom(Krgb krgb) : base(krgb) 
        {
            Rnd = new Random();
        }

        protected override (int iD, int jD) CountIJD(int x, int y, int n) => (Rnd.Next(n), Rnd.Next(n));
    }
}

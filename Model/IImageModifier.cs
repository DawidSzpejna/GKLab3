using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;


namespace Model
{
    public interface IImageModifier
    {
        public void PleaseModifyImage(FastBitmap map);
    }
}

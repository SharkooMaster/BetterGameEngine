using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace BetterGameEngine.Utils
{
    public static class uColor
    {
        public static Color fromHex(string _hex)
        {
            var _converter = new ColorConverter();
            Color ret = (Color) _converter.ConvertFromString(_hex);
            return ret;
        }
    }
}

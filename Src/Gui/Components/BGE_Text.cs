using BetterGameEngine.Gui;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Src.Gui.Components
{
    public class BGE_Text : GuiComponent
    {
        public BGE_Text(string inner, Brush color)
        {
            width = 240;
            height = 55;
            backgroundColor = Color.Transparent;

            customDraw = () =>
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                Canvas.GRAPHICS.DrawString(
                    inner,
                    new Font(FontFamily.GenericSansSerif, 20.0f, FontStyle.Bold),
                    color, rect, stringFormat
                );
            };
        }
    }
}

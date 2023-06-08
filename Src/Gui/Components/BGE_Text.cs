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
        private string INNER = "";
        public string _inner
        {
            get { return INNER; }
            set
            {
                INNER = value;
                Canvas.GRAPHICS.FillRectangle(new SolidBrush(Canvas.backgroundColor), Rectangle.Round(rect));
                customDraw();
            }
        }

        public int _width = 240;
        public int _height = 55;
        public Color _bg = Color.Transparent;

        public BGE_Text(string inner, Brush color)
        {
            _inner = inner;
            width = _width;
            height = _height;
            _bg = ((SolidBrush)color).Color;

            customDraw = () =>
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                Canvas.GRAPHICS.DrawString(
                    INNER,
                    new Font(FontFamily.GenericSansSerif, 20.0f, FontStyle.Bold),
                    new SolidBrush(_bg), rect, stringFormat
                );
            };
        }
    }
}

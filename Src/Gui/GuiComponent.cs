using BetterGameEngine.MathB;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Gui
{
    public class GuiComponent
    {
        public int id;

        public Vector2 position;
        public int width;
        public int height;
        public int zIndex;
        public GuiLayer.dock dock;

        public delegate void Trigger();
        public Trigger trigger;

        // Design variables
        public Color backgroundColor;

        public int roundedRadius_TL;
        public int roundedRadius_TR;
        public int roundedRadius_BL;
        public int roundedRadius_BR;
        public int roundedRadius
        {
            set
            {
                this.roundedRadius_TL = value;
                this.roundedRadius_TR = value;
                this.roundedRadius_BL = value;
                this.roundedRadius_BR = value;
            }
        }

        private void calculatePosition()
        {
        }

        public void draw()
        {
            Canvas.GRAPHICS.FillRectangle(new SolidBrush(backgroundColor), new Rectangle(0, 0, width, height));
        }

    }
}

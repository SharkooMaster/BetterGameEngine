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

        public void calculatePosition()
        {
            switch(dock)
            {
                case GuiLayer.dock.TL:
                    position = new Vector2(0, 0);
                    break;
                case GuiLayer.dock.TC:
                    position = new Vector2(Convert.ToInt32(Canvas.WIDTH / 2), 0);
                    break;
                case GuiLayer.dock.TR:
                    position = new Vector2(Canvas.WIDTH, 0);
                    break;
                case GuiLayer.dock.CL:
                    position = new Vector2(0, Convert.ToInt32(Canvas.HEIGHT/2) - (height/2));
                    break;
                case GuiLayer.dock.C:
                    position = new Vector2(Convert.ToInt32(Canvas.WIDTH/2) - (width/2), Convert.ToInt32(Canvas.HEIGHT/2) - (height/2));
                    break;
                case GuiLayer.dock.CR:
                    position = new Vector2(Canvas.WIDTH, Convert.ToInt32(Canvas.HEIGHT/2) - (height/2));
                    break;
                case GuiLayer.dock.BL:
                    position = new Vector2(0, Canvas.HEIGHT - (height));
                    break;
                case GuiLayer.dock.BC:
                    position = new Vector2(Convert.ToInt32(Canvas.WIDTH/2) - (width/2), Canvas.HEIGHT - (height));
                    break;
                case GuiLayer.dock.BR:
                    position = new Vector2(Canvas.WIDTH - width, Canvas.HEIGHT - (height));
                    break;
                default:
                    position = new Vector2(0, 0);
                    break;
            }
        }

        public void draw()
        {
            Rectangle rect = Rectangle.Round(new Rectangle((int)position.x, (int)position.y, width, height));
            Canvas.GRAPHICS.FillRectangle(new SolidBrush(backgroundColor), rect);
        }

    }
}

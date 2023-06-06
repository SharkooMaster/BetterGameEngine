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
        public List<GuiComponent> children = new List<GuiComponent>();

        public Vector2 position;
        public GuiComponent parent;
        public Vector2 parentPosition = new Vector2(0,0);
        public Vector2 parentScale = new Vector2(Canvas.WIDTH,Canvas.HEIGHT);
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

        public int margin_T { get; set; } = 0;
        public int margin_B { get; set; } = 0;
        public int margin_L { get; set; } = 0;
        public int margin_R { get; set; } = 0;
        public int margin
        {
            set
            {
                this.margin_T = value;
                this.margin_B = value;
                this.margin_L = value;
                this.margin_R = value;
            }
        }
        
        public int padding_T { get; set; } = 0;
        public int padding_B { get; set; } = 0;
        public int padding_L { get; set; } = 0;
        public int padding_R { get; set; } = 0;
        public int padding
        {
            set
            {
                this.padding_T = value;
                this.padding_B = value;
                this.padding_L = value;
                this.padding_R = value;
            }
        }


        public GuiComponent()
        {
            trigger = () => { };
        }

        public void calculatePosition()
        {
            if(parent == null) { parent = new GuiComponent(); }
            switch(dock)
            {
                case GuiLayer.dock.TL:
                    position = new Vector2(0, 0);
                    position.x += margin_L + parent.padding_L;
                    position.x += margin_L + parent.padding_L;
                    position.y += margin_T + parent.padding_T;
                    break;
                case GuiLayer.dock.TC:
                    position = new Vector2(Convert.ToInt32(parentScale.x / 2) - (width/2), 0);
                    position.y += margin_T + parent.padding_T;
                    break;
                case GuiLayer.dock.TR:
                    position = new Vector2(parentScale.x - width, 0);
                    position.x -= margin_R + parent.padding_R;
                    position.y += margin_T + parent.padding_T;
                    break;
                case GuiLayer.dock.CL:
                    position = new Vector2(0, Convert.ToInt32(parentScale.y/2) - (height/2));
                    position.x += margin_L + parent.padding_L;
                    break;
                case GuiLayer.dock.C:
                    position = new Vector2(Convert.ToInt32(parentScale.x /2) - (width/2), Convert.ToInt32(parentScale.y/2) - (height/2));
                    break;
                case GuiLayer.dock.CR:
                    position = new Vector2(parentScale.x - width, Convert.ToInt32(parentScale.y/2) - (height/2));
                    position.x -= margin_R + parent.padding_R;
                    break;
                case GuiLayer.dock.BL:
                    position = new Vector2(0, parentScale.y - (height));
                    position.x += margin_L + parent.padding_L;
                    position.y -= margin_B + parent.padding_B;
                    break;
                case GuiLayer.dock.BC:
                    position = new Vector2(Convert.ToInt32(parentScale.x /2) - (width/2), parentScale.y - (height));
                    position.y -= margin_B + padding_B;
                    break;
                case GuiLayer.dock.BR:
                    position = new Vector2(parentScale.x - width, parentScale.y - (height));
                    position.x -= margin_R + parent.padding_R;
                    position.y -= margin_B + parent.padding_B;
                    break;
                default:
                    position = new Vector2(0, 0);
                    break;
            }
            position.x += parentPosition.x;
            position.y += parentPosition.y;
        }

        public void draw()
        {
            Rectangle rect = Rectangle.Round(new Rectangle((int)position.x, (int)position.y, width, height));
            Canvas.GRAPHICS.FillRectangle(new SolidBrush(backgroundColor), rect);
            trigger();

            foreach(var _child in children)
            {
                _child.parent = this;
                _child.parentPosition = position;
                _child.parentScale = new Vector2(width, height);
                _child.calculatePosition();
                _child.draw();
            }
        }

    }
}

using BetterGameEngine.MathB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Gui
{
    public static class Canvas
    {
        public static Graphics GRAPHICS;
        public static int WIDTH;
        public static int HEIGHT;
        public static List<GuiLayer> Layers = new List<GuiLayer>();

        public static int ActiveLayer = -1;
        public static int activeLayer
        {
            get { return ActiveLayer; }
            set
            {
                Layers[value].sortComponents();
                ActiveLayer = value;
            }
        }

        public static void drawGUI()
        {
            GRAPHICS.Clear(Color.White);
            // Render game here;
            if(activeLayer != -1)
            {
                Layers[ActiveLayer].render();
            }
        }
    }
}

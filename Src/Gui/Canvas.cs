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
        public static List<GuiLayer> Layers = new List<GuiLayer>();

        public static int ActiveLayer = -1;
        public static int activeLayer
        {
            get { return ActiveLayer; }
            set
            {
                ActiveLayer = value;
            }
        }

        public static void drawGUI()
        {
            GRAPHICS.Clear(Color.White);
            // Render game here;
            Layers[ActiveLayer].render();
        }
    }
}

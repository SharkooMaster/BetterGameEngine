using BetterGameEngine.MathB;
using BetterGameEngine.Utils;
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
                drawGUI();
            }
        }

        public static Color backgroundColor = uColor.fromHex("#2C3241");
        public static void drawGUI()
        {
            GRAPHICS.Clear(backgroundColor);
            // Render game here;
            if(activeLayer != -1 && Layers.Count != 0)
            {
                Layers[ActiveLayer].render();
            }
        }

        public static Color BGE_RED     = uColor.fromHex("#FF4D35");
        public static Color BGE_ORANGE  = uColor.fromHex("#FF7E35");
        public static Color BGE_YELLOW  = uColor.fromHex("#FFC635");
        public static Color BGE_GREEN   = uColor.fromHex("#4AB541");
        public static Color BGE_BLUE    = uColor.fromHex("#41A0B5");
        public static Color BGE_PINK    = uColor.fromHex("#E934CC");
        public static Color BGE_PURPLE  = uColor.fromHex("#B84BFB");
        public static Color BGE_WHITE   = uColor.fromHex("#FFFFFF");

        public static Color BGE_RED_HOVER       = uColor.fromHex("#E54631");
        public static Color BGE_ORANGE_HOVER    = uColor.fromHex("#EA7330");
        public static Color BGE_YELLOW_HOVER    = uColor.fromHex("#E3B12E");
        public static Color BGE_GREEN_HOVER     = uColor.fromHex("#3E9C35");
        public static Color BGE_BLUE_HOVER      = uColor.fromHex("#388A9C");
        public static Color BGE_PINK_HOVER      = uColor.fromHex("#C32DAB");
        public static Color BGE_PURPLE_HOVER    = uColor.fromHex("#9940CF");
        public static Color BGE_WHITE_HOVER     = uColor.fromHex("#D4D4D4");
    }
}

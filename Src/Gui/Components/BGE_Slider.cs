using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Gui.Components
{
    public class BGE_Slider : GuiComponent
    {
        Color sliderColor;
        Color holdColor;

        GuiComponent sliderTrace = new GuiComponent();
        GuiComponent sliderBtn = new GuiComponent();

        public BGE_Slider(Color _sliderColor, Color _holdColor)
        {
            sliderColor = _sliderColor;
            holdColor = _holdColor;

            width = 300;
            height = 16;
            backgroundColor = Color.Gray;
            roundedRadius = 8;

            sliderTrace.width = width - 10;
            sliderTrace.height = height - 6;
            sliderTrace.roundedRadius = 5;
            sliderTrace.backgroundColor = sliderColor;
            sliderTrace.dock = GuiLayer.dock.C;
            children.Add(sliderTrace);

            sliderBtn.width = 18;
            sliderBtn.height = 18;
            sliderBtn.roundedRadius = 9;
            sliderBtn.backgroundColor = holdColor;
            sliderBtn.dock = GuiLayer.dock.CL;
            sliderTrace.children.Add(sliderBtn);
        }
    }
}

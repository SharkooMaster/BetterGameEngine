using BetterGameEngine.Gui;
using BetterGameEngine.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Gui.Components
{
    public class BGE_ButtonFilled : GuiComponent
    {
        Color std;
        Color hover;
        public BGE_ButtonFilled(Color _std, Color _hover, string inner = "Button")
        {
            std = _std;
            hover = _hover;

            width = 250;
            height = 65;
            backgroundColor = std;

            onHover = () => { backgroundColor = hover; };
            onHoverEnd = () => { backgroundColor = std; };

            BGE_Text _txt = new BGE_Text(inner, (std != Canvas.BGE_WHITE) ? Brushes.White : Brushes.Black);
            _txt.parent = this;
            _txt.dock = GuiLayer.dock.C;
            children.Add(_txt);
        }
    }
}

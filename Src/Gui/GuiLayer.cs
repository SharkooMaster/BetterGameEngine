using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Gui
{
    public class GuiLayer
    {
        int id { get; set; }

        public enum dock
        {
            TL, TC, TR,
            CL, C, CR,
            BL, BC, BR
        };
        public List<GuiComponent> components = new List<GuiComponent>();

        public void render()
        {
            foreach (var component in components)
            {
                component.draw();
            }
        }

        public void clear()
        {
            foreach(var component in components)
            {
            }
        }
    }
}

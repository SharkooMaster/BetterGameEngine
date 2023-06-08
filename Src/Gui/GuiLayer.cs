using BetterGameEngine.Input;
using BetterGameEngine.MathB;
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
        public Dictionary<Vector2, Vector2> componentRange = new Dictionary<Vector2, Vector2>();

        public GuiComponent componentInRange = null;

        public void sortComponents()
        {
            if(components.Count > 0)
            {
                components.Sort((x, y) => x.zIndex.CompareTo(y.zIndex) );
                components.Reverse();
                componentRange.Clear();

                for (int i = 0; i < components.Count; i++)
                {
                    if (components[i].position == null)
                        break;
                    componentRange.Add(components[i].position, 
                        new Vector2(components[i].position.x + components[i].width,
                        components[i].position.y + components[i].height));
                }
            }
        }

        public void mouseInRange()
        {
            for(int i = 0; i < components.Count; i++)
            {
                if(componentRange.Count <= 0) { Console.WriteLine("nope"); break; }
                if(InputManager.mousePosition.x > componentRange.ElementAt(i).Key.x &&
                   InputManager.mousePosition.x < componentRange.ElementAt(i).Value.x &&
                   InputManager.mousePosition.y > componentRange.ElementAt(i).Key.y &&
                   InputManager.mousePosition.y < componentRange.ElementAt(i).Value.y)
                {
                    Console.WriteLine($"in range {i}");
                    components[i].onHover();
                    if(componentInRange == null)
                    {
                        components[i].draw();
                    }
                    componentInRange = components[i];
                }
                else
                {
                    Console.WriteLine($"out of range {i}");
                    if(componentInRange != null && componentInRange.id == components[i].id)
                    {
                        componentInRange.onHoverEnd();
                        componentInRange.draw();
                        componentInRange = null;
                    }
                }
            }
        }

        public bool isLoaded = false;
        public void load()
        {
            sortComponents();
            isLoaded = true;
        }

        public void render()
        {
            int i = 0;
            foreach (var component in components)
            {
                component.id = i;
                component.calculatePosition();
                component.draw();
                i++;
            }
            if(!isLoaded)
            {
                load();
            }
        }
    }
}

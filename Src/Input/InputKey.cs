using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterGameEngine.Input
{
    public class InputKey
    {
        public bool isActive = true;
        public enum type
        {
            Action,
            State,
            Range
        };
        public type assignedContext { get; set; }
        public Keys key { get; set; }
        public List<string> context { get; set; }

        public InputKey(Keys _key, type _type)
        {
            this.key = _key;
            this.assignedContext = _type;
            this.context = new List<string>();
        }

        public delegate void Trigger(float range = 1);
        public Trigger trigger;
        public void InternAction(float _range = 1)
        {
            trigger(_range);
        }
    }
}

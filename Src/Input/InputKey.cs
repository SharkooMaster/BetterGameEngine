using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterGameEngine.Input
{
    public class InputKey
    {
        public bool isActive = true;
        public bool isHeld = false;
        public enum type
        {
            Action,
            State,
            Range
        };
        public type assignedType { get; set; }
        public Keys key { get; set; }
        public List<string> context { get; set; }

        public InputKey(type _type, Keys _key = Keys.None)
        {
            this.key = _key;
            this.assignedType = _type;
            this.context = new List<string>();
        }

        public delegate void Trigger(float range = 1);
        public Trigger trigger;
        public void InternAction(float _range = 1)
        {
            if(assignedType == type.Action)
            {
                trigger(_range);
            }
            else
            {
                isHeld = true;
                Task.Run(()=> triggerHold(_range));
            }
        }

        private void triggerHold(float _range = 1)
        {
            while(isHeld)
            {
                trigger(_range);
            }
        }
    }
}

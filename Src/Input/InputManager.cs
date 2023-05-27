using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterGameEngine.Input
{
    public static class InputManager
    {
        public static List<InputKey> inputKeys = new List<InputKey>();
        public static List<InputKey> activeKeys = new List<InputKey>();

        public static List<string> contexts = new List<string>();
        public static bool activeContextUpdated = false;
        private static string ActiveContext;
        public static string activeContext
        {
            get{ return ActiveContext; }
            set
            {
                activeContextUpdated = false;
                ActiveContext = value;
            }
        }

        public static void getKeysWithContext(string _context)
        {
            activeKeys.Clear();
            foreach (InputKey key in inputKeys)
            {
                key.isActive = (key.context.Contains(_context)) ? true : false;
                if (key.context.Contains(_context))
                    activeKeys.Add(key);
            }
            activeContextUpdated = true;
        }

        public static void syncInputs(KeyEventArgs e)
        {
            if(!activeContextUpdated)
                getKeysWithContext(ActiveContext);

            foreach (InputKey key in activeKeys)
            {
                if (key.isActive && e.KeyCode == key.key)
                {
                    key.InternAction();
                    if(key.assignedType == InputKey.type.Action)
                    {
                        key.isActive = false;
                    }
                }
            }
        }

        public static void syncKeyUp(KeyEventArgs e)
        {
            if(!activeContextUpdated)
                getKeysWithContext(ActiveContext);

            foreach(InputKey key in activeKeys)
            {
                if(key.isActive && e.KeyCode == key.key)
                {
                    key.isHeld = false;
                }
                if(key.assignedType == InputKey.type.Action)
                {
                    key.isActive = true;
                }
            }
        }

        public static void syncMouseInputs(MouseEventArgs e, int _type)
        {
            if(!activeContextUpdated)
                getKeysWithContext(ActiveContext);

            foreach(InputMouse m in activeKeys.OfType<InputMouse>())
            {
                if(m.isActive)
                {
                    if(m.mouseButtonType == (InputMouse.mouseType)_type)
                    {
                        if(_type != 2)
                            m.InternAction();
                        else
                            m.InternAction(e.Delta/120);

                        if(m.assignedType == InputKey.type.Action && _type != 2)
                        {
                            m.isActive = false;
                        }
                    }
                }
            }
        }

        public static void syncMouseUp(MouseEventArgs e, int _type)
        {
            if(!activeContextUpdated)
                getKeysWithContext(ActiveContext);

            foreach(InputMouse m in activeKeys.OfType<InputMouse>())
            {
                if(m.isActive && m.mouseButtonType == (InputMouse.mouseType)_type)
                {
                    m.isHeld = false;
                }
                if(m.assignedType == InputKey.type.Action)
                {
                    m.isActive = true;
                }
            }
        }

    }
}

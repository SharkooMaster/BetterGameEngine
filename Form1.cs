using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BetterGameEngine.Assets.Scripts;
using BetterGameEngine.Input;

namespace BetterGameEngine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Game.init();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine($"Form1::KeyDown({e.KeyValue.ToString()})");
            InputManager.syncInputs(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            InputManager.syncKeyUp(e);
        }
    }
}

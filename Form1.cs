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
using BetterGameEngine.Gui;
using BetterGameEngine.Input;
using BetterGameEngine.Utils;

namespace BetterGameEngine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            Canvas.GRAPHICS = CreateGraphics();
            Canvas.GRAPHICS.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Canvas.WIDTH = (int)Canvas.GRAPHICS.VisibleClipBounds.Width;
            Canvas.HEIGHT = (int)Canvas.GRAPHICS.VisibleClipBounds.Height;

            Canvas.drawGUI();
            base.OnResizeEnd(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            Canvas.GRAPHICS = CreateGraphics();
            Canvas.GRAPHICS.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Canvas.WIDTH = (int)Canvas.GRAPHICS.VisibleClipBounds.Width;
            Canvas.HEIGHT = (int)Canvas.GRAPHICS.VisibleClipBounds.Height;

            Canvas.drawGUI();
            Game.rockPaperScissors();
            //Game.init();
            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Canvas.GRAPHICS = CreateGraphics();
            Canvas.GRAPHICS.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Canvas.WIDTH = (int)Canvas.GRAPHICS.VisibleClipBounds.Width;
            Canvas.HEIGHT = (int)Canvas.GRAPHICS.VisibleClipBounds.Height;

            Canvas.drawGUI();
            base.OnPaint(e);
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

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            InputManager.syncMouseInputs(e, 2);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                InputManager.syncMouseInputs(e, 0);
                GuiComponent comp = Canvas.Layers[Canvas.activeLayer].componentInRange;
                if(comp != null)
                {
                    comp.eventOnTrigger();
                    //Canvas.drawGUI();
                    if (Canvas.Layers[Canvas.activeLayer].isLoaded)
                    {
                        //Canvas.Layers[Canvas.activeLayer].componentInRange.draw();
                    }
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                InputManager.syncMouseInputs(e, 1);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                InputManager.syncMouseUp(e, 0);
            }
            if(e.Button == MouseButtons.Right)
            {
                InputManager.syncMouseUp(e, 1);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            InputManager.mousePosition.x = e.X;
            InputManager.mousePosition.y = e.Y;

            Canvas.Layers[Canvas.activeLayer].mouseInRange();

            //Console.WriteLine($"mx: {InputManager.mousePosition.x}, my: {InputManager.mousePosition.y}");
        }
    }
}

using BetterGameEngine.Gui;
using BetterGameEngine.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.Assets.Scripts
{
    public static class Game
    {
        public static void init()
        {
            InputManager.contexts.Add("Player");
            InputManager.contexts.Add("Vehicle");
            InputManager.activeContext = InputManager.contexts[0];

            InputKey player_moveForward = new InputKey(InputKey.type.Action, System.Windows.Forms.Keys.W);
            player_moveForward.trigger = new InputKey.Trigger((range) =>
            {
                Console.WriteLine($"Player::Forward::{range}");
                Canvas.activeLayer = (Canvas.activeLayer == 0) ? 1 : 0;
                Canvas.drawGUI();
                //InputManager.activeContext = InputManager.contexts[1];
            });
            player_moveForward.context.Add("Player");

            InputKey player_moveRight = new InputKey(InputKey.type.State, System.Windows.Forms.Keys.D);
            player_moveRight.trigger = new InputKey.Trigger((range) =>
            {
                Console.WriteLine($"Player::Right::{range}");
            });
            player_moveRight.context.Add("Player");
            player_moveRight.context.Add("Vehicle");

            InputMouse player_zoom = new InputMouse(InputKey.type.Action, InputMouse.mouseType.scr);
            player_zoom.trigger = new InputKey.Trigger((range) =>
            {
                Console.WriteLine($"Player::Zoom::{range}");
            });
            player_zoom.context.Add("Player");

            InputMouse player_shoot = new InputMouse(InputKey.type.State, InputMouse.mouseType.lmb);
            player_shoot.trigger = new InputKey.Trigger((range) =>
            {
                Console.WriteLine($"Player::Shoot::{range}");
            });
            player_shoot.context.Add("Player");

            InputManager.inputKeys.Add(player_moveForward);
            InputManager.inputKeys.Add(player_moveRight);
            InputManager.inputKeys.Add(player_zoom);
            InputManager.inputKeys.Add(player_shoot);

            // Draw GUI
            GuiLayer menue = new GuiLayer();

            GuiComponent btn = new GuiComponent();
            btn.width = 150;
            btn.height = 50;
            btn.backgroundColor = Color.Black;

            menue.components.Add(btn);
            Canvas.Layers.Add(menue);

            GuiLayer settings = new GuiLayer();
            GuiComponent header = new GuiComponent();
            header.width = 300;
            header.height = 100;
            header.backgroundColor = Color.Blue;

            settings.components.Add(header);

            Canvas.Layers.Add(settings);
            Canvas.activeLayer = 0;
        }
    }
}

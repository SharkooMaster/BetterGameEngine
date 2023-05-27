using BetterGameEngine.Input;
using System;
using System.Collections.Generic;
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
                //InputManager.activeContext = InputManager.contexts[1];
            });
            player_moveForward.context.Add("Player");

            InputKey player_moveRight = new InputKey(InputKey.type.State, System.Windows.Forms.Keys.D);
            player_moveRight.trigger = new InputKey.Trigger((range) =>
            {
                Console.WriteLine($"Player::Right::{range}");
            });
            player_moveRight.context.Add("Player");

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
        }
    }
}

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

            InputKey player_moveForward = new InputKey(System.Windows.Forms.Keys.W, InputKey.type.Action);
            player_moveForward.trigger = new InputKey.Trigger((range) =>
            {
                Console.WriteLine($"Player::Forward::{range}");
                //InputManager.activeContext = InputManager.contexts[1];
            });
            player_moveForward.context.Add("Player");

            InputKey player_moveRight = new InputKey(System.Windows.Forms.Keys.D, InputKey.type.State);
            player_moveRight.trigger = new InputKey.Trigger((range) =>
            {
                Console.WriteLine($"Player::Right::{range}");
            });
            player_moveRight.context.Add("Player");

            InputManager.inputKeys.Add(player_moveForward);
            InputManager.inputKeys.Add(player_moveRight);
        }
    }
}

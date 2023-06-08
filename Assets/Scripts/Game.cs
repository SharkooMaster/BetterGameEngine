using BetterGameEngine.Gui;
using BetterGameEngine.Input;
using BetterGameEngine.Src.Gui.Components;
using BetterGameEngine.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

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

            BGE_ButtonFilled bGE_ButtonFilled = new BGE_ButtonFilled(Canvas.BGE_WHITE, Canvas.BGE_WHITE_HOVER, "Layer 1");
            bGE_ButtonFilled.dock = GuiLayer.dock.C;
            bGE_ButtonFilled.roundedRadius = 10;
            bGE_ButtonFilled.trigger = () => { Canvas.activeLayer = 1; };

            menue.components.Add(bGE_ButtonFilled);
            Canvas.Layers.Add(menue);

            GuiLayer settings = new GuiLayer();

            BGE_Text titleSettings = new BGE_Text("Settings", new SolidBrush(Canvas.BGE_WHITE));
            titleSettings.dock = GuiLayer.dock.TC;

            BGE_ButtonFilled btnLayer1 = new BGE_ButtonFilled(Canvas.BGE_RED, Canvas.BGE_RED_HOVER);
            btnLayer1.dock = GuiLayer.dock.C;
            btnLayer1.trigger = () => { Canvas.activeLayer = 0; };

            settings.components.Add(titleSettings);
            settings.components.Add(btnLayer1);

            Canvas.Layers.Add(settings);
            Canvas.activeLayer = 0;
        }

        public static int rps_random;
        public static BGE_Text rps_status;
        public static BGE_Text rps_text;
        public static void setRpsRandom()
        {
            rps_random = new Random().Next(0, 3);

            switch (rps_random)
            {
                case 0:
                    rps_text._inner = "ROCK";
                    break;
                case 1:
                    rps_text._inner = "PAPER";
                    break;
                case 2:
                    rps_text._inner = "SCISSORS";
                    break;
            }
            Canvas.drawGUI();
        }

        public static void RpsValidateWin(int x)
        {
            switch (rps_random)
            {
                case 0:
                    if(x == 0)
                    {
                        rps_status._inner = "TIE";
                        rps_status._bg = Canvas.BGE_BLUE;
                    }else if(x == 1)
                    {
                        rps_status._inner = "YOU WON";
                        rps_status._bg = Canvas.BGE_GREEN;
                    }
                    else
                    {
                        rps_status._inner = "YOU LOST";
                        rps_status._bg = Canvas.BGE_RED;
                    }
                    break;
                case 1:
                    if(x == 0)
                    {
                        rps_status._inner = "YOU LOST";
                        rps_status._bg = Canvas.BGE_RED;
                    }else if(x == 1)
                    {
                        rps_status._inner = "TIE";
                        rps_status._bg = Canvas.BGE_BLUE;
                    }
                    else
                    {
                        rps_status._inner = "YOU WON";
                        rps_status._bg = Canvas.BGE_GREEN;
                    }
                    break;
                case 2:
                    if(x == 0)
                    {
                        rps_status._inner = "YOU WON";
                        rps_status._bg = Canvas.BGE_GREEN;
                    }else if(x == 1)
                    {
                        rps_status._inner = "YOU LOST";
                        rps_status._bg = Canvas.BGE_RED;
                    }
                    else
                    {
                        rps_status._inner = "TIE";
                        rps_status._bg = Canvas.BGE_BLUE;
                    }
                    break;
            }
            Canvas.drawGUI();
        }

        public static void rockPaperScissors()
        {
            GuiLayer main = new GuiLayer();
            Canvas.backgroundColor = uColor.fromHex("#000000");

            BGE_Text title = new BGE_Text("RPS", new SolidBrush(Canvas.BGE_WHITE));
            title.dock = GuiLayer.dock.TC;
            main.components.Add(title);

            BGE_ButtonFilled startGameBtn = new BGE_ButtonFilled(Canvas.BGE_WHITE, Canvas.BGE_BLUE_HOVER, "Start");
            startGameBtn.dock = GuiLayer.dock.C;
            startGameBtn.roundedRadius = 10;
            startGameBtn.trigger = () => { Canvas.activeLayer = 1; };
            main.components.Add(startGameBtn);

            Canvas.Layers.Add(main);
            Canvas.activeLayer = 0;

            GuiLayer game = new GuiLayer();

            rps_status = new BGE_Text("RPS", new SolidBrush(Canvas.BGE_WHITE));
            rps_status.dock = GuiLayer.dock.TC;
            game.components.Add(rps_status);

            BGE_ButtonFilled rockBtn = new BGE_ButtonFilled(Canvas.BGE_PURPLE, Canvas.BGE_YELLOW_HOVER, "ROCK");
            rockBtn.dock = GuiLayer.dock.CL;
            rockBtn.roundedRadius = 10;
            rockBtn.margin_L = 20;
            rockBtn.trigger = () => {
                setRpsRandom();
                RpsValidateWin(0);
            };
            game.components.Add(rockBtn);

            BGE_ButtonFilled paperBtn = new BGE_ButtonFilled(Canvas.BGE_PURPLE, Canvas.BGE_YELLOW_HOVER, "PAPER");
            paperBtn.dock = GuiLayer.dock.C;
            paperBtn.roundedRadius = 10;
            paperBtn.trigger = () => {
                setRpsRandom();
                RpsValidateWin(1);
            };
            game.components.Add(paperBtn);

            BGE_ButtonFilled scissorsBtn = new BGE_ButtonFilled(Canvas.BGE_PURPLE, Canvas.BGE_YELLOW_HOVER, "SCISSORS");
            scissorsBtn.dock = GuiLayer.dock.CR;
            scissorsBtn.roundedRadius = 10;
            scissorsBtn.margin_R = 20;
            scissorsBtn.trigger = () => {
                setRpsRandom();
                RpsValidateWin(2);
            };
            game.components.Add(scissorsBtn);

            rps_text = new BGE_Text("Choose", new SolidBrush(Canvas.BGE_WHITE));
            rps_text.dock = GuiLayer.dock.BC;
            game.components.Add(rps_text);

            Canvas.Layers.Add(game);
        }
    }
}

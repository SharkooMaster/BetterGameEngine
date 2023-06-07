using BetterGameEngine.Gui;
using BetterGameEngine.Input;
using BetterGameEngine.Src.Gui.Components;
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

            BGE_ButtonFilled bGE_ButtonFilled = new BGE_ButtonFilled(Canvas.BGE_RED, Canvas.BGE_RED_HOVER);
            bGE_ButtonFilled.dock = GuiLayer.dock.TL;

            BGE_ButtonFilled bGE_ButtonFilled4 = new BGE_ButtonFilled(Canvas.BGE_ORANGE, Canvas.BGE_ORANGE_HOVER);
            bGE_ButtonFilled4.dock = GuiLayer.dock.TL;
            bGE_ButtonFilled4.margin_T = 70;

            BGE_ButtonFilled bGE_ButtonFilled2 = new BGE_ButtonFilled(Canvas.BGE_YELLOW, Canvas.BGE_YELLOW_HOVER);
            bGE_ButtonFilled2.dock = GuiLayer.dock.TC;

            BGE_ButtonFilled bGE_ButtonFilled3 = new BGE_ButtonFilled(Canvas.BGE_GREEN, Canvas.BGE_GREEN_HOVER);
            bGE_ButtonFilled3.dock = GuiLayer.dock.TC;
            bGE_ButtonFilled3.margin_T = 70;

            BGE_ButtonFilled bGE_ButtonFilled5 = new BGE_ButtonFilled(Canvas.BGE_BLUE, Canvas.BGE_BLUE_HOVER);
            bGE_ButtonFilled5.dock = GuiLayer.dock.TR;

            BGE_ButtonFilled bGE_ButtonFilled6 = new BGE_ButtonFilled(Canvas.BGE_PINK, Canvas.BGE_PINK_HOVER);
            bGE_ButtonFilled6.dock = GuiLayer.dock.TR;
            bGE_ButtonFilled6.margin_T = 70;

            BGE_ButtonFilled bGE_ButtonFilled7 = new BGE_ButtonFilled(Canvas.BGE_PURPLE, Canvas.BGE_PURPLE_HOVER);
            bGE_ButtonFilled7.dock = GuiLayer.dock.CL;

            BGE_ButtonFilled bGE_ButtonFilled8 = new BGE_ButtonFilled(Canvas.BGE_WHITE, Canvas.BGE_WHITE_HOVER);
            bGE_ButtonFilled8.dock = GuiLayer.dock.C;
            bGE_ButtonFilled8.roundedRadius_TL = 10;
            bGE_ButtonFilled8.roundedRadius_TR = 10;

            menue.components.Add(bGE_ButtonFilled);
            menue.components.Add(bGE_ButtonFilled2);
            menue.components.Add(bGE_ButtonFilled3);
            menue.components.Add(bGE_ButtonFilled4);
            menue.components.Add(bGE_ButtonFilled5);
            menue.components.Add(bGE_ButtonFilled6);
            menue.components.Add(bGE_ButtonFilled7);
            menue.components.Add(bGE_ButtonFilled8);
            Canvas.Layers.Add(menue);

            GuiLayer settings = new GuiLayer();

            GuiComponent header = new GuiComponent();
            header.width = 300;
            header.height = 100;
            header.backgroundColor = Color.Blue;
            header.dock = GuiLayer.dock.BL;

            GuiComponent header2 = new GuiComponent();
            header2.width = 300;
            header2.height = 100;
            header2.backgroundColor = Color.Blue;
            header2.dock = GuiLayer.dock.C;
            header2.padding = 0;
            header2.trigger = () => { Canvas.ActiveLayer = 0; };
            header2.onHover = () => { header2.backgroundColor = Color.Red; };
            header2.onHoverEnd = () => { header2.backgroundColor = Color.Blue; };

            GuiComponent headerText = new GuiComponent();
            headerText.width = 100;
            headerText.height = 30;
            headerText.backgroundColor = Color.Transparent;
            headerText.dock = GuiLayer.dock.C;
            headerText.customDraw = () =>
            {
                Canvas.GRAPHICS.DrawString("Header", new Font(FontFamily.GenericSansSerif, 20.0f, FontStyle.Bold), Brushes.White, headerText.position.x, headerText.position.y);
            };
            header2.children.Add(headerText);

            settings.components.Add(header);
            settings.components.Add(header2);

            Canvas.Layers.Add(settings);
            Canvas.activeLayer = 0;
        }
    }
}

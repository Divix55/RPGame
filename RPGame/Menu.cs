using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace RPGame
{
	public class Menu
	{
		public void startMenu()
		{
			Game game = new Game();

			RenderWindow guiWindow = new RenderWindow(new SFML.Window.VideoMode(800, 600), "RPGame Menu");
			guiWindow.SetFramerateLimit(60);
			guiWindow.Closed += Window_Closed;

			Text titleText = new Text("RPGame", new Font("Fonts/Rolande.ttf"), 100);
			Text startText = new Text("Start Game", new Font("Fonts/Rolande.ttf"), 50);
			Text controlText = new Text("Control", new Font("Fonts/Rolande.ttf"), 50);
			Text exitText = new Text("Exit", new Font("Fonts/Rolande.ttf"), 50);

			titleText.Position = new SFML.System.Vector2f(250, 50);
			startText.Position = new SFML.System.Vector2f(300, 200);
			controlText.Position = new SFML.System.Vector2f(300, 250);
			exitText.Position = new SFML.System.Vector2f(300, 300);

			titleText.Color = new Color(0, 125, 125);

			while (guiWindow.IsOpen)
			{
				guiWindow.DispatchEvents();

				guiWindow.Clear();

				guiWindow.Draw(titleText);
				guiWindow.Draw(startText);
				guiWindow.Draw(controlText);
				guiWindow.Draw(exitText);

				//Vector2f vec = new Vector2f(localMousePosition.X, localMousePosition.Y); << usun to
				Vector2i localMousePosition = Mouse.GetPosition(guiWindow);

				if (startText.GetLocalBounds().Contains(localMousePosition.X - 300, localMousePosition.Y - 200))
				{
					startText.Color = new Color(255, 0, 0);
					if (Mouse.IsButtonPressed(Mouse.Button.Left))
					{
						guiWindow.Close();
						game.start();
					}
				}
				else if (controlText.GetLocalBounds().Contains(localMousePosition.X - 300, localMousePosition.Y - 250))
				{
					controlText.Color = new Color(255, 0, 0);
					if (Mouse.IsButtonPressed(Mouse.Button.Left))
					{
						Control(guiWindow, titleText);
					}
				}
				else if (exitText.GetLocalBounds().Contains(localMousePosition.X - 300, localMousePosition.Y - 300))
				{
					exitText.Color = new Color(255, 0, 0);
					if (Mouse.IsButtonPressed(Mouse.Button.Left))
					{
						guiWindow.Close();	
					}
				}
				else
				{
					startText.Color = new Color(255, 255, 255);
					controlText.Color = new Color(255, 255, 255);
					exitText.Color = new Color(255, 255, 255);
				}

				guiWindow.Display();
			}
		}

		void Control(RenderWindow window, Text titleText)
		{
			titleText.Position = new SFML.System.Vector2f(250, 50);

			Text text1 = new Text("Arrow - character control", new Font("Fonts/Rolande.ttf"), 30);
			Text text2 = new Text("Space - action", new Font("Fonts/Rolande.ttf"), 30);
			text1.Position = new SFML.System.Vector2f(270, 170);
			text2.Position = new SFML.System.Vector2f(270, 200);

			window.DispatchEvents();
			window.Clear();
			window.Draw(titleText);
			window.Draw(text1);
			window.Draw(text2);
		}

		void Window_Closed(object sender, EventArgs e)
		{
			Window guiWindow = (Window)sender;
			guiWindow.Close();
		}
}
}


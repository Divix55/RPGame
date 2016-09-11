using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace RPGame
{
	public class Game
	{
		public void start()
		{
			RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "RPGame");
			window.SetFramerateLimit(60);
			window.Closed += Window_Closed;

			Map map1 = new Map();
			View view = new View(new Vector2f(0, 0), new Vector2f(800, 600));
			Player player = new Player();
			Chicken kurczak = new Chicken();
			kurczak.Waypoints = new List<Waypoint>();

			kurczak.Waypoints.Add(new Waypoint(0, 0));
			kurczak.Waypoints.Add(new Waypoint(100, 0));
			kurczak.Waypoints.Add(new Waypoint(70, 40));
			kurczak.Waypoints.Add(new Waypoint(50, 100));

			Clock clock = new Clock();

			while (window.IsOpen)
			{
				window.DispatchEvents();

				float deltaTime = clock.Restart().AsSeconds();

				kurczak.Update(deltaTime);
				player.Update(deltaTime);

				view.Center = new Vector2f(player.xpos, player.ypos);
				window.SetView(view);

				window.Clear();

				map1.Draw(window);
				kurczak.Draw(window);
				player.Draw(window);

				window.Display();
			}
		}

		void Window_Closed(object sender, EventArgs e)
		{
			Window window = (Window)sender;
			window.Close();
		}
	}
}
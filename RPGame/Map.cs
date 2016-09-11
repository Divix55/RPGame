using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
	class Map
	{
		Sprite[,] tiles;
		int mapwidth = 100;
		int mapheight = 100;

		public Map()
		{
			int tilemapwidth = 32;
			int tilemapheight = 32;
			int tilesize = 32;

			Texture texture = new Texture("Map/terrain_atlas.png");
			Sprite[] tilemap = new Sprite[tilemapheight * tilemapwidth];

			for (int y = 0; y < tilemapheight; y++)
			{
				for (int x = 0; x < tilemapwidth; x++)
				{
					IntRect rect = new IntRect(x * tilesize, y * tilesize, tilesize, tilesize);
					tilemap[(y * tilemapheight) + x] = new Sprite(texture, rect);
				}
			}

			tiles = new Sprite[mapwidth, mapwidth];
			StreamReader reader = new StreamReader("Map/map.csv");

			for (int y = 0; y < mapheight; y++)
			{
				string line = reader.ReadLine();
				string[] items = line.Split(',');

				for (int x = 0; x < mapwidth; x++)
				{
					int id = Convert.ToInt32(items[x]);
					tiles[x, y] = new Sprite(tilemap[id]);
					tiles[x, y].Position = new SFML.System.Vector2f(tilesize * x, tilesize * y);
				}
			}

			reader.Close();
		}

		public void Draw(RenderWindow window)
		{
			for (int y = 0; y < mapheight; y++)
			{
				for (int x = 0; x < mapwidth; x++)
				{
					window.Draw(tiles[x, y]);
				}
			}
		}
	}
}

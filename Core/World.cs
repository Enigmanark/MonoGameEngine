using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collections;
using MonoGameEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine
{
	public class World
	{
		Bag<Sprite> sprites;
		public Sprite Player;

		public void Initialize(ContentManager content)
		{
			sprites = new Bag<Sprite>();

			Player = new Sprite();
			Player.Texture = content.evermore_cover;
			Player.Position = new Vector2(0, 0);
			Player.Speed = 50;
			sprites.Add(Player);
		}

		public void Draw(SpriteBatch batch)
		{
			foreach(Sprite sprite in sprites)
			{
				sprite.Draw(batch);
			}
		}
	}
}

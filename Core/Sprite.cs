using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine.Core
{
	public class Sprite
	{
		public Texture2D Texture { get; set; }
		public Vector2 Position { get; set; }

		public Sprite()
		{

		}

		public Sprite(Texture2D tex)
		{
			Texture = tex;
		}

		public Sprite(Texture2D tex, Vector2 pos)
		{
			Texture = tex;
			Position = pos;
		}

		public void Draw(SpriteBatch batch)
		{

		}
		
	}
}

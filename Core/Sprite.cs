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
		public float Speed { get; set; }

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

		public Rectangle GetRect()
		{
			return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
		}

		public void Draw(SpriteBatch batch)
		{
			batch.Draw(Texture, GetRect(), Color.White);
		}
		
	}
}

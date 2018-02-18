using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine
{
	public class DrawingController
	{
		SpriteBatch spriteBatch;


		public void LoadContent(GameCore game)
		{
			spriteBatch = new SpriteBatch(game.GraphicsDevice);
		}

		public void UnloadContent()
		{
			spriteBatch.Dispose();
		}
	}
}

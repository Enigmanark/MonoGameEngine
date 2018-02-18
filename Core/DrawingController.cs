using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
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
		Camera2D camera;

		//For GameState in STATE_GAME
		public void Draw(GameTime gameTime, World world, GuiController gui)
		{
			spriteBatch.Begin();
			world.Draw(spriteBatch);
			gui.Draw(gameTime);
			spriteBatch.End();
		}
		
		//For GameState in STATE_TITLE
		public void Draw(GameTime gameTime, GuiController gui)
		{
			gui.Draw(gameTime);
		}

		public void LoadContent(GameCore game)
		{
			spriteBatch = new SpriteBatch(game.GraphicsDevice);
		}

		public void UnloadContent()
		{
			spriteBatch.Dispose();
		}

		public void Initialize(Camera2D camera)
		{
			this.camera = camera;
		}
	}
}

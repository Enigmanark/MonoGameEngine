using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine
{
	public class InputManager
	{
		GameCore game;
		World world;

		public InputManager(GameCore game, World world)
		{
			this.game = game;
			this.world = world;
		}

		public void Update(GameTime gameTime)
		{
			var keyState = Keyboard.GetState();
			if (keyState.IsKeyDown(Keys.Escape))
			{
				game.UnloadGame();
			}
		}
	}
}

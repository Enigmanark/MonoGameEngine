using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine
{
	public class LogicController
	{
		private InputManager input;

		public void Initialize()
		{
			input = new InputManager();
		}

		public void Update(GameTime gameTime, GuiController guiController)
		{
			guiController.Update(gameTime);
		}

		public void Update(GameCore game, World world, GameTime gameTime, GuiController guiController)
		{
			input.Update(game, world, gameTime);
			guiController.Update(gameTime);
		}
	}
}

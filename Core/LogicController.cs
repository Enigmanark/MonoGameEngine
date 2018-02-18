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

		public void Initialize(GameCore game, World world)
		{
			input = new InputManager(game, world);
		}

		public void Update(GameTime gameTime)
		{
			input.Update(gameTime);
		}
	}
}

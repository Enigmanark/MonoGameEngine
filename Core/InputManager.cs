using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine
{
	public class InputManager
	{

		public InputManager()
		{
		}

		public void Update(GameCore game, World world, GameTime gameTime)
		{
			var keyState = Keyboard.GetState();
			var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
			var player = world.Player;
			if (game.State == GameCore.GameState.Game)
			{
				if (keyState.IsKeyDown(Keys.Escape))
				{
					game.ChangeState(GameCore.GameState.Title);
				}

				else if(keyState.IsKeyDown(Keys.W))
				{
					var y = player.Position.Y;
					player.Position = new Vector2(player.Position.X, y - (player.Speed * delta));
				}
				else if(keyState.IsKeyDown(Keys.S))
				{
					var y = player.Position.Y;
					player.Position = new Vector2(player.Position.X, y + (player.Speed * delta));
				}
				else if(keyState.IsKeyDown(Keys.A))
				{
					var x = player.Position.X;
					player.Position = new Vector2(x - (player.Speed * delta), player.Position.Y);
				}
				else if (keyState.IsKeyDown(Keys.D))
				{
					var x = player.Position.X;
					player.Position = new Vector2(x + (player.Speed * delta), player.Position.Y);
				}
			}
		}
	}
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine
{
	public class ContentManager
	{
		private Texture2D sprite;

		public void LoadContent(GameCore game)
		{
			sprite = game.Content.Load<Texture2D>("evermore_cover");
		}
	}
}

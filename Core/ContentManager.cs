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
		public Texture2D evermore_cover;

		public void LoadContent(GameCore game)
		{
			evermore_cover = game.Content.Load<Texture2D>("Sprites/sprite");
		}
	}
}

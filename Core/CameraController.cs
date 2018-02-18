using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine.Core
{
	public class CameraController
	{
		Camera2D camera;

		public void Initialize(BoxingViewportAdapter adapter)
		{
			camera = new Camera2D(adapter);
		}

		public Camera2D GetCamera()
		{
			return camera;
		}
	}
}

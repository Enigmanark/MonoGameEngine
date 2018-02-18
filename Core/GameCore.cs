using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;
using MonoGameEngine.Core;
using System;

namespace MonoGameEngine
{
	public class GameCore : Game
	{
		public static int WINDOW_WIDTH = 800;
		public static int WINDOW_HEIGHT = 600;
		public static int SCREEN_WIDTH = 480;
		public static int SCREEN_HEIGHT = 300;

		public static int STATE_TITLE = 1;
		public static int STATE_GAME = 2;
		public static int STATE_GAMEOVER = 3;
		public static int STATE_HIGHSCORES = 4;

		GraphicsDeviceManager graphics;
		BoxingViewportAdapter boxingViewportAdapter;

		GuiController guiController;
		ContentManager contentManager;
		DrawingController drawingController;
		LogicController logicController;
		CameraController cameraController;

		World world;

		public GameCore()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			base.Initialize();

			boxingViewportAdapter = new BoxingViewportAdapter(Window, graphics, SCREEN_WIDTH, SCREEN_HEIGHT);

			cameraController = new CameraController();
			cameraController.Initialize(boxingViewportAdapter);
			world = new World();
			guiController = new GuiController(this, world);

			Exiting += Close;
		}

		public void UnloadGame()
		{
			world = null;
		}

		protected override void LoadContent()
		{

			contentManager.LoadContent(this);
			drawingController.LoadContent(this, cameraController.GetCamera());
		}

		protected override void UnloadContent()
		{
			Content.Unload();
			drawingController.UnloadContent();
		}

		protected override void Update(GameTime gameTime)
		{
			logicController.Update(gameTime);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			base.Draw(gameTime);
		}

		public void Close(object Sender, EventArgs e)
		{
			UnloadContent();
			Exit();
		}
	}
}

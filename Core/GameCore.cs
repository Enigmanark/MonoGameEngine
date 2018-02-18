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

		public enum GameState { Title, Game, GameOver, HighScore};

		GraphicsDeviceManager graphics;
		BoxingViewportAdapter boxingViewportAdapter;

		GuiController guiController;
		ContentManager contentManager;
		DrawingController drawingController;
		LogicController logicController;
		CameraController cameraController;

		World world;

		public GameState State = GameState.Title;

		public GameCore()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			contentManager = new ContentManager();
			drawingController = new DrawingController();
			cameraController = new CameraController();
			logicController = new LogicController();
			guiController = new GuiController(this, world);
		}

		protected override void Initialize()
		{
			base.Initialize();

			boxingViewportAdapter = new BoxingViewportAdapter(Window, graphics, SCREEN_WIDTH, SCREEN_HEIGHT);
		
			cameraController.Initialize(boxingViewportAdapter);			
			drawingController.Initialize(cameraController.GetCamera());
			logicController.Initialize();
			guiController.Initialize();

			Exiting += Close;

			ChangeState(GameState.Title);
		}

		public void UnloadGame()
		{
			world = null;
		}

		public void LoadGame()
		{
			world = new World();
			world.Initialize(contentManager);
		}

		public void ChangeState(GameState state)
		{
			State = state;

			if (state == GameState.Title)
			{
				UnloadGame();
				IsMouseVisible = true;
				guiController.ChangeState(GameState.Title);
			}

			else if(state == GameState.Game)
			{
				IsMouseVisible = false;
				LoadGame();
				guiController.ChangeState(GameState.Game);
			}
		}

		protected override void LoadContent()
		{

			contentManager.LoadContent(this);
			drawingController.LoadContent(this);
		}

		protected override void UnloadContent()
		{
			Content.Unload();
			drawingController.UnloadContent();
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			if (State == GameState.Game) logicController.Update(this, world, gameTime, guiController);
			else logicController.Update(gameTime, guiController);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			base.Draw(gameTime);

			if (State == GameState.Title) drawingController.Draw(gameTime, guiController);
			else if (State == GameState.Game) drawingController.Draw(gameTime, world, guiController);
		}

		public void Close(object Sender, EventArgs e)
		{
			UnloadContent();
			Exit();
		}
	}
}

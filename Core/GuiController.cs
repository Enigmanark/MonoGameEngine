using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls.Desktop;
using System;

namespace MonoGameEngine
{
	public class GuiController
	{
		private GameCore game;
		private World world;
		private GuiManager titleGui;
		private InputListenerComponent inputListener;

		public GuiController(GameCore game, World world)
		{
			this.game = game;
			this.world = world;
			inputListener = new InputListenerComponent(game);
		}

		public void CreateTitleGui()
		{
			var guiInputService = new GuiInputService(inputListener);
			titleGui = new GuiManager(game.Services, guiInputService);

			titleGui.Screen = new GuiScreen(GameCore.SCREEN_WIDTH, GameCore.SCREEN_HEIGHT);

			titleGui.Screen.Desktop.Bounds = new UniRectangle(new UniScalar(0f, 0), new UniScalar(0f, 0), new UniScalar(1f, 0), new UniScalar(1f, 0));

			titleGui.Initialize();

			//Create buttons
			var buttonWidth = 150;
			var buttonHeight = 50;
			var buttonX = (GameCore.WINDOW_WIDTH / 2) - (buttonWidth / 2);
			var buttonY = 200;
			var buttonDivider = 100;
			var StartButton = new GuiButtonControl
			{
				Name = "Start",
				Bounds = new UniRectangle(new UniScalar(buttonX), new UniScalar(buttonY), new UniScalar(buttonWidth), new UniScalar(buttonHeight)),
				Text = "Start"
			};

			var HighScoresButton = new GuiButtonControl
			{
				Name = "HighScores",
				Bounds = new UniRectangle(new UniScalar(buttonX), new UniScalar(buttonY + buttonDivider),
					new UniScalar(buttonWidth), new UniScalar(buttonHeight)),
				Text = "High Scores"
			};

			var ExitButton = new GuiButtonControl
			{
				Name = "Exit",
				Bounds = new UniRectangle(new UniScalar(buttonX), new UniScalar(buttonY + (buttonDivider * 2)),
					new UniScalar(buttonWidth), new UniScalar(buttonHeight)),
				Text = "Exit"
			};

			//Add functon to pressed
			StartButton.Pressed += StartButtonPressed;
			HighScoresButton.Pressed += HighScoresButtonPressed;
			ExitButton.Pressed += ExitButtonPressed;

			//Add buttons to gui
			titleGui.Screen.Desktop.Children.Add(StartButton);
			titleGui.Screen.Desktop.Children.Add(HighScoresButton);
			titleGui.Screen.Desktop.Children.Add(ExitButton);
		}

		private void StartButtonPressed(object Sender, EventArgs e)
		{

		}

		private void HighScoresButtonPressed(object Sender, EventArgs e)
		{

		}

		private void ExitButtonPressed(object Sender, EventArgs e)
		{
			game.Close(Sender, e);
		}

		public void Update(GameTime gameTime)
		{
			inputListener.Update(gameTime);
			titleGui.Update(gameTime);
		}
	}
}

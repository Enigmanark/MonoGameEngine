using Microsoft.Xna.Framework;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls.Desktop;
using System;
using System.Diagnostics;

namespace MonoGameEngine
{
	public class GuiController
	{
		private GameCore game;
		private World world;
		private GuiManager gui;
		private InputListenerComponent inputListener;

		public GameCore.GameState State = 0;

		public GuiController(GameCore game, World world)
		{
			this.game = game;
			this.world = world;
			inputListener = new InputListenerComponent(game);
		}

		public void Initialize()
		{
			var guiInputService = new GuiInputService(inputListener);
			gui = new GuiManager(game.Services, guiInputService);

			gui.Screen = new GuiScreen(GameCore.SCREEN_WIDTH, GameCore.SCREEN_HEIGHT);

			gui.Screen.Desktop.Bounds = new UniRectangle(new UniScalar(0f, 0), new UniScalar(0f, 0), new UniScalar(1f, 0), new UniScalar(1f, 0));

			gui.Initialize();
		}

		public void CreateTitleGui()
		{
			gui.Screen.Desktop.Children.Clear();

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
			gui.Screen.Desktop.Children.Add(StartButton);
			gui.Screen.Desktop.Children.Add(HighScoresButton);
			gui.Screen.Desktop.Children.Add(ExitButton);
		}

		private void StartButtonPressed(object Sender, EventArgs e)
		{
			game.ChangeState(GameCore.GameState.Game);
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
			if (State == GameCore.GameState.Title)
			{
				inputListener.Update(gameTime);
				gui.Update(gameTime);
			}
		}

		public void ChangeState(GameCore.GameState state)
		{
			if (state == GameCore.GameState.Title)
			{
				CreateTitleGui();
				State = state;
			}

			else if(state == GameCore.GameState.Game)
			{
				gui.Screen.Desktop.Children.Clear();
				State = state;
			}
		}

		public void Draw(GameTime gameTime)
		{
			if(State == GameCore.GameState.Title) gui.Draw(gameTime);
		}
	}
}

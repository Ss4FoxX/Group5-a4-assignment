// include code libraries you need below (use the namespace).
using System;
using System.Numerics;
using Game10003;

// the namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        private string titleText = "SPACE INVADERS\nPress Enter to Start";
        private string winText = "YOU WIN!\nPress Enter to Restart";
        private string loseText = "YOU LOSE!\nPress Enter to Restart";

        private Color textColor = Color.White;  // text color for messages

        // manually controlling the game state with a boolean
        private bool isInTitleScreen = true;  // start at the title screen
        private bool isInWinScreen = false;  // initially not in win screen
        private bool isInLoseScreen = false; // initially not in lose screen

        // flag to track if Enter key has been pressed
        private bool isEnterPressed = false;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        ///     This is where you set up your game environment, window properties, etc.
        /// </summary>
        public void Setup()
        {
            // set up window size and title
            Window.SetTitle("Space Invaders");
            Window.SetSize(800, 600);  // set window size to 800x600

            // initialize Text for drawing
            Text.Initialize();
            Text.Color = textColor;  // set initial text color

            // clear the background initially
            Window.ClearBackground(Color.Black);

            // draw the initial title screen
            DrawCurrentScreen();
        }

        /// <summary>
        ///     Update runs every frame.
        ///     This is where the game logic, input handling, and drawing take place.
        /// </summary>
        public void Update()
        {
            // clear the background before drawing anything
            Window.ClearBackground(Color.Black);

            // handle input to switch screens when Enter is pressed
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter) && !isEnterPressed)
            {
                if (isInTitleScreen)
                {
                    isInTitleScreen = false;
                    isInWinScreen = true;
                }
                else if (isInWinScreen || isInLoseScreen)
                {
                    isInWinScreen = false;
                    isInLoseScreen = false;
                    isInTitleScreen = true;
                }
                isEnterPressed = true;
            }

            // reset Enter key state when released
            if (Input.IsKeyboardKeyReleased(KeyboardInput.Enter))
            {
                isEnterPressed = false;
            }

            // draw the current screen (title, win, or lose screen)
            DrawCurrentScreen();
        }

        /// <summary>
        ///     Helper method to draw the current screen.
        ///     This method will draw either the title, win, or lose screen based on the game state.
        /// </summary>
        private void DrawCurrentScreen()
        {
            if (isInTitleScreen)
            {
                Text.Color = Color.White;  // reset to white for title
                Text.Draw(titleText, 100, 250);
            }
            else if (isInWinScreen)
            {
                Text.Color = Color.Green;
                Text.Draw(winText, 100, 250);
            }
            else if (isInLoseScreen)
            {
                Text.Color = Color.Red;
                Text.Draw(loseText, 100, 250);
            }
        }
    }
}


// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;
using Game10003;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    /// Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // texts for the different screens
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
        /// Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // set up window size
            Window.SetTitle("Space Invaders");
            Window.SetSize(800, 600);  // set window size to 800x600

            // initialize Text for drawing
            Text.Initialize();

            // ensure that title screen is displayed immediately
            isInTitleScreen = true;  // set to true to show title screen initially
            isInWinScreen = false;   // make sure not in win screen initially
            isInLoseScreen = false;  // make sure not in lose screen initially
        }

        /// <summary>
        /// Update runs every frame.
        /// </summary>
        public void Update()
        {
            // handle input to switch screens when Enter is pressed
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter))  // check for key press (not hold)
            {
                if (isInTitleScreen)
                {
                    // change to win screen for now (you can switch this to Lose later)
                    isInTitleScreen = false;
                    isInWinScreen = true;  // for testing, switch to win screen
                }
                else if (isInWinScreen || isInLoseScreen)
                {
                    // after win or lose, return to the title screen
                    isInWinScreen = false;
                    isInLoseScreen = false;
                    isInTitleScreen = true;  // return to title screen
                }

                // ensure that we only change the state once per key press
                isEnterPressed = true;
            }

            // prevent state change if Enter key is held down
            if (Input.IsKeyboardKeyReleased(KeyboardInput.Enter))
            {
                isEnterPressed = false;  // allow the Enter key to be processed again
            }

            // clear the background before drawing anything
            Window.ClearBackground(Color.Black);  // reset background to black each frame

            // render the appropriate screen based on the current flags
            if (isInTitleScreen)  // title screen
            {
                Text.Draw(titleText, 100, 250);  // draw title text at position (100, 250)
            }
            else if (isInWinScreen)  // win screen
            {
                Text.Color = Color.Green;  // set color to green for win
                Text.Draw(winText, 100, 250);  // draw win text at position (100, 250)
            }
            else if (isInLoseScreen)  // lose screen
            {
                Text.Color = Color.Red;  // set color to red for lose
                Text.Draw(loseText, 100, 250);  // draw lose text at position (100, 250)
            }
        }
    }
}

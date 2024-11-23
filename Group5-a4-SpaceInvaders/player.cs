using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game10003
{
    public class player
    {
        // Initalize position
        int mainRectangleX = 400;


        public player()
        {
            drawPlayer();
            playerMovement();
        }

        private void drawPlayer()
        {
            Draw.LineSize = 3;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Blue;

            Draw.Rectangle(mainRectangleX, 450,100,100);
            Draw.Rectangle(mainRectangleX - 25, 400, 50, 50);
            Draw.Rectangle(mainRectangleX + 25, 400, 50, 50);

        }

        private void playerMovement()
        {
            if(Input.IsKeyboardKeyPressed(KeyboardInput.A)) {

                // Updates the x position dynamically to redraw the player 25 points to the left of the current position
                mainRectangleX -= 25;

            } else if (Input.IsKeyboardKeyPressed(KeyboardInput.D)) {

                // Updates the x position dynamically to redraw the player 25 points to the right of the current position
                mainRectangleX += 25;

            }
        }
        
    }
}

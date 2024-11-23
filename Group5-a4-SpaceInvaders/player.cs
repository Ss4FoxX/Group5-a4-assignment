using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game10003
{
    public class player
    {

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

            Draw.Rectangle(400, 450,100,100);
            Draw.Rectangle(375, 400, 50, 50);
            Draw.Rectangle(425, 400, 50, 50);

        }

        private void playerMovement()
        {

        }
        
    }
}

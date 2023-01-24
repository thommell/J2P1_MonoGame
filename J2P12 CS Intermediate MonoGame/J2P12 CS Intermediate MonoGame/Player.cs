using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J2P12_CS_Intermediate_MonoGame
{
    internal class Player
    {
        // Player Variables

        public float playerSpeed = 10f;

        public Texture2D playerTexture;

        public Vector2 playerPosition;


        // Screen Parameters

        public int screenWidth;
        public int screenHeight;


        public Player(Vector2 playerPosition, int screenWidth, int screenHeight)
        {
            this.playerPosition = playerPosition;
            this.screenWidth = screenWidth; 
            this.screenHeight = screenHeight;  

        }

        public SpriteBatch sb;

        // Update for the Player movement
        public void MovementUpdate(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                // Adds extra feature to 'Speed Up' when holding shift.
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    playerPosition.Y -= 5;
                }
                playerPosition.Y -= 5;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    playerPosition.Y += 5;
                }
                playerPosition.Y += 5;
            }
            // Makes it so u can't go through the border of the screen
            if(playerPosition.Y <= 35)
            {
                playerPosition.Y = 35;
            }
            if (playerPosition.Y + playerTexture.Height / 2 * 0.0575f >= screenHeight)
            {
                playerPosition.Y = screenHeight - playerTexture.Height * 0.0575f / 2;
            }
            
        }
        public void Draw()
        {
            sb.Draw(playerTexture, playerPosition, null, Color.White, 0f, new Vector2(playerTexture.Width / 2, playerTexture.Height / 2), 0.0575f, SpriteEffects.None, 0f);
        }

    }

}

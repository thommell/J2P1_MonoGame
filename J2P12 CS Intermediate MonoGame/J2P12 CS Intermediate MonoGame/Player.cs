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
    public class Player
    {
        // Player Variables

        public float playerSpeed = 10f;

        public Texture2D playerTexture;

        public Vector2 playerPosition;

        public float halfSize;
        public float imageScale = 0.0575f;

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
                    playerPosition.Y -= 10;
                }
                playerPosition.Y -= 5;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    playerPosition.Y += 10;
                    
                }
                playerPosition.Y += 5;
                
            }
            // Makes it so u can't go through the border of the screen.
            playerPosition.Y = Math.Clamp(playerPosition.Y, halfSize, screenHeight - halfSize);
        }

        public void SetPlayerSize()
        {
            halfSize = playerTexture.Width / 2 * imageScale;
        }
        public void Draw()
        {
            sb.Draw(playerTexture, playerPosition, null, Color.White, 0f, new Vector2(playerTexture.Width / 2, playerTexture.Height / 2), imageScale, SpriteEffects.None, 0f);
        }
    }
}

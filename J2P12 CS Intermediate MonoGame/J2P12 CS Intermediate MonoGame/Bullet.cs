using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography.X509Certificates;

namespace J2P12_CS_Intermediate_MonoGame
{
    public class Bullet
    {
        // Bullet variables
        public Player player;


        public float bulletImageScale = 0.06f;
        public float bulletSpeed = 5f;

        public Vector2 bulletPosition;

        public Texture2D bulletTexture;



        // Bullet constructor -- the vector2 basically makes the (new) bullet spawn on the player but just a bit in front.
        public Bullet(Player player, Texture2D texture)
        {
            bulletPosition = new Vector2(player.playerPosition.X + player.playerTexture.Width / 20, player.playerPosition.Y);
            bulletTexture = texture;
        }

        // Update bullets realtime
        public void BulletUpdate(GameTime gameTime)
        {
            // Input
            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    bulletPosition =  player.playerPosition;
            //}

            bulletPosition.X += bulletSpeed;
        }

        // Draw the bullets
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(bulletTexture, bulletPosition, null, Color.White, 0f, new Vector2(bulletTexture.Width / 2, bulletTexture.Height / 2), bulletImageScale, SpriteEffects.None, 0f);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J2P12_CS_Intermediate_MonoGame
{
    public class CollisionManager
    {
        public Rectangle ghostRectangle = new Rectangle();
        public List<Rectangle> bulletRectangles = new List<Rectangle>();
        public Rectangle bulletRectangle = new Rectangle();
        SpriteBatch sb;
        Enemy enemy;

        public CollisionManager(Enemy enemy, SpriteBatch sb)
        {
            this.enemy = enemy;
            this.sb = sb;
        }
        public void AssignRectangle()
        {
            ghostRectangle = new Rectangle((int)enemy.enemyPosition.X, (int)enemy.enemyPosition.Y, enemy.enemyTexture.Width, enemy.enemyTexture.Height);
        }

        public void CollisionCheck(GameTime gameTime, List<Bullet> bullets, Texture2D enemyTexture, Bullet bullet)
        {
            ghostRectangle.Y = (int)enemy.enemyPosition.Y;

            bulletRectangle = new Rectangle(0, 0, (int)bullet.bulletTexture.Width, (int)bullet.bulletTexture.Height);

            // add rectangle if bullet gets created
            for (int i = 0; i < bullets.Count; i++)
            {
                bulletRectangles.Add(bulletRectangle);
                Debug.WriteLine(bullets.Count);
            }
            // remove rectangle if bullet goes out of bounds
            for (int i2 = 0; i2 < bullet.bulletsToRemove.Count; i2++)
            {
                bulletRectangles.Remove(bulletRectangles[i2]);
            }
        }
        public void DrawHitboxes(SpriteBatch sb, Bullet bullet, SetTextureSizes sts, Player player)
        {
            // Draw Texture1 and texture2
            sb.Draw(enemy.enemyTexture, enemy.enemyPosition, ghostRectangle, Color.Red, 0f, new Vector2(enemy.enemyTexture.Width * sts.halfSizeEnemy, enemy.enemyTexture.Height * sts.halfSizeEnemy), player.imageScale, SpriteEffects.None, 0f);
            for (int i2 = 0; i2 < bulletRectangles.Count; i2++)
            {
                // move bullets hitbox along with the normal bullets
               // 

                
            }
            sb.Draw(bullet.bulletTexture, bullet.bulletPosition, bulletRectangle, Color.Red, 0f, new Vector2(bullet.bulletTexture.Width * sts.halfSizeBullet, bullet.bulletTexture.Height * sts.halfSizeBullet), player.imageScale, SpriteEffects.None, 0f);
        }
    }
}

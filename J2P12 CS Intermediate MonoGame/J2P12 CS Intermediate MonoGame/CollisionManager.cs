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
        public Rectangle tex1;
        public Rectangle tex2 = new Rectangle();
        public List<Rectangle> bulletRectangles = new List<Rectangle>();
        SpriteBatch sb;
        Enemy enemy;

        public CollisionManager(Enemy enemy, SpriteBatch sb)
        {
            this.enemy = enemy;
            this.sb = sb;
        }
        public void CollisionCheck(GameTime gameTime, List<Bullet> bullets, Texture2D enemyTexture)
        {
            //tex1.X = (float)enemy.enemyPosition.X;
            
            foreach (Bullet bullet in bullets)
            {
                Rectangle bulletRectangle = new Rectangle((int)bullet.bulletPosition.X, (int)bullet.bulletPosition.Y, bullet.bulletTexture.Width, bullet.bulletTexture.Height);
                bulletRectangles.Add(bulletRectangle);
            }
        }
        public void DrawHitboxes(SpriteBatch sb, Bullet bullet)
        {
            

        }
    }
}

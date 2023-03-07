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
        SpriteBatch sb;
        Enemy enemy;
        public CollisionManager(Enemy enemy, SpriteBatch sb)
        {
            this.enemy = enemy;
            this.sb = sb;
        }
        public void CollisionCheck(GameTime gameTime, List<Bullet> bullets, Texture2D enemyTexture)
        {
            tex1.X = (int)enemy.enemyPosition.X;
            tex2 = new Rectangle(0, 0, enemyTexture.Width / 20, enemyTexture.Height / 20);
            foreach (Bullet bullet in bullets)
            {
                if (bullet.bulletTexture != null)
                {
                    tex1 = new Rectangle(0, 0, bullet.bulletTexture.Width / 20, bullet.bulletTexture.Height / 20);
                    
                }
                
                if (tex1.Intersects(tex2))
                {
                    Debug.WriteLine(tex1.Intersects(tex2));
                    bullet.bulletTexture = null;
                }
            }
        }
        public void DrawHitboxes(SpriteBatch sb)
        {
            sb.Draw(enemy.enemyTexture, tex1, Color.White);
            Debug.WriteLine(tex2);
        }
    }
}
